using Part29_CustomBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Part29_Reflection.NamnetReflection
{
    public class NamReflection
    {
        public static void NamDotNetReflection(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: typeloader.exe <dll file name>");
            }
            else
            {
                var fileName = args[0];

                if (!File.Exists(fileName))
                {
                    Console.WriteLine("The library to load is not existed");
                    return;
                }

                Console.WriteLine($"Loading {fileName}");

                var assem = InspectAssembly(fileName);

                if (assem != null)
                {
                    LoadObjectFromAssembly(assem);
                }
            }
        }

        private static void LoadObjectFromAssembly(Assembly assem)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Loading OBJECT from Assembly");

            string nameSpace = assem.GetModules()[0].Name.Replace(".dll", "");

            Type type = assem.GetType(nameSpace + ".MyClass");

            //1.  create object from type of assembly
            object instance = Activator.CreateInstance(type);
            Console.WriteLine(instance);

            //2. call method Add static in MyClass class
            var addResult = type.InvokeMember("Add", BindingFlags.InvokeMethod, null
                 , instance,
                 new Object[] { (int)2, (int)3 });

            Console.WriteLine($"Test Add method of instance: 2 + 3 =  {addResult}");

            //3. Call all constructor of MyClass class
            // 3.1 call default parameterless constructor
            var constructorParameterless = type.GetConstructor([]);
            Console.WriteLine($"Parameterless Constructor : {constructorParameterless.Name}");

            dynamic initiateConstructorParameterless = type.InvokeMember(constructorParameterless.Name, BindingFlags.CreateInstance, null
                 , instance,
                 new object[] {});
            Console.WriteLine($"Call parameterless constructor : {initiateConstructorParameterless.Address} - Name: {initiateConstructorParameterless.Name} - {initiateConstructorParameterless.a} - {initiateConstructorParameterless.b} ");


            // 3.2 call another constructor  
            var constructorSecond = type.GetConstructor([typeof(int), typeof(int)]);
            Console.WriteLine($"Another Constructor : {constructorSecond.Name}");
            dynamic invokeSecond = constructorSecond.Invoke(new object[] { 2, 3 });

            Console.WriteLine($"Call second constructor : {invokeSecond.Address} - Name: {invokeSecond.Name} - {invokeSecond.a} - {invokeSecond.b} ");

        }

        private static Assembly InspectAssembly(string fileName)
        {
            var assem = Assembly.LoadFrom(fileName);

            if (assem == null) ArgumentException.ThrowIfNullOrEmpty(nameof(fileName));

            PrintModuleInfo(assem);
            PrintTypeInfo(assem);

            return assem;
        }

        private static void PrintModuleInfo(Assembly assem)
        {
            Console.WriteLine("MODULES:-----------------------------------");
            foreach (var module in assem.GetModules())
            {
                Console.WriteLine($"Module: {module.Name}");
            }
        }

        private static void PrintTypeInfo(Assembly assem)
        {
            Console.WriteLine("TYPES:-----------------------------------");
            foreach (var type in assem.GetTypes())
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"Type: {type.Name}");

                PrintConstructionInfo(type);
                PrintMethodInfo(type);
                PrintPropertyInfo(type);
                PrintFieldInfo(type);
            }
        }

        private static void PrintConstructionInfo(Type type)
        {
            Console.WriteLine("CONSTRUCTORS:-----------------------------------");
            foreach (var constructor in type.GetConstructors())
            {
                if (constructor.DeclaringType == type)
                {
                    Console.WriteLine($"Constructor: {constructor.Name}");
                    foreach (var param in constructor.GetParameters())
                    {
                        Console.WriteLine($"--------parameter Name: {param.Name} -type : {param.ParameterType}");
                    }
                }
            }
        }

        private static void PrintPropertyInfo(Type type)
        {
            Console.WriteLine("PROPERTIES:-----------------------------------");
            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                if (property.DeclaringType == type)
                {
                    Console.WriteLine($"Property: {property.Name}");
                }
            }
        }

        private static void PrintFieldInfo(Type type)
        {
            Console.WriteLine("FIELDS:-----------------------------------");
            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                if (field.DeclaringType == type)
                {
                    Console.WriteLine($"Field: {field.Name}");
                }
            }
        }

        private static void PrintMethodInfo(Type type)
        {
            Console.WriteLine("METHODS:-----------------------------------");
            foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                if (method.DeclaringType == type)
                {
                    Console.WriteLine($"Method: {method.Name}");

                    // get custome attributes of each method
                    var customAttributes = method.CustomAttributes;
                    foreach (var custom in customAttributes)
                    {
                        Console.WriteLine($"Custom Attribute : {custom.AttributeType}");
                    }

                }
            }
        }
    }
}
