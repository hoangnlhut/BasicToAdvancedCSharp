using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Part29_Reflection.Pluralsight.IoCContainer
{
    public class IoCContainer
    {
        Dictionary<Type, Type> _map = new Dictionary<Type, Type>();
        MethodInfo? _resolveMethod;

        public void Register<TContract, TImplement>()
        {
            //register in the mapping dictionary
            if (!_map.ContainsKey(typeof(TContract)))
            {
                _map.Add(typeof(TContract), typeof(TImplement));
            }
        }

        public void Register(Type contract, Type implement)
        {
            //register in the mapping dictionary
            if (!_map.ContainsKey(contract))
            {
                _map.Add(contract, implement);
            }
        }

        public TContract Resolve<TContract>()
        {
            Type? getGenericTypeDefinition = null;
            var isGenericType = typeof(TContract).IsGenericType;
            if (isGenericType)
            {
                getGenericTypeDefinition = typeof(TContract).GetGenericTypeDefinition();
            }
            

            // check whether we're trying to resolve a generic type
            if (isGenericType && _map.ContainsKey(getGenericTypeDefinition) )
            {
                var openImplementation = _map[getGenericTypeDefinition];
                var closedImpimentation = openImplementation.MakeGenericType(typeof(TContract).GenericTypeArguments);
                return Create<TContract>(closedImpimentation);
            }

            if (!_map.ContainsKey(typeof(TContract)))
                throw new ArgumentException($"No registration found for {typeof(TContract)}");
            
            // create an instance and return it
            return Create<TContract>(_map[typeof(TContract)]);
        }

        private TContract Create<TContract>(Type implementationType)
        {
            // get the resolve method
            if (_resolveMethod is null)
            {
                _resolveMethod = typeof(IoCContainer).GetMethod("Resolve");
            }

            //var constructorParameters = implementationType.GetConstructors().OrderByDescending(c => c.GetParameters().Length).First().GetParameters()
            //    .Select(p =>
            //    {
            //        // make the resolve method generic and invoke it
            //        var genericResolveMethod = _resolveMethod?.MakeGenericMethod(p.ParameterType);
            //        return genericResolveMethod?.Invoke(this, null);
            //    }
            //).ToArray();

            //return (TContract)Activator.CreateInstance(implementationType, constructorParameters);


            List<object> a = new List<object>();

            var constructors = implementationType.GetConstructors();
            foreach (var constructor in constructors.OrderByDescending(c => c.GetParameters().Length))
            {
                var onlyOne = constructor.GetParameters();
                foreach (var one in onlyOne)
                {
                    var genericResolveMethod = _resolveMethod?.MakeGenericMethod(one.ParameterType);
                    a.Add(genericResolveMethod?.Invoke(this, null));
                }
                break;
            }

            return (TContract)Activator.CreateInstance(implementationType, a.ToArray());
        }
    }
}
