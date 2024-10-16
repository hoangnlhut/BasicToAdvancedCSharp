using System.Reflection;

namespace Part29_Reflection.GeneticType
{
    public class Example
    {
        // The following method displays information about a generic
        // type.
        public static void DisplayGenericType(Type t)
        {
            Console.WriteLine("\r\n {0}", t);
            Console.WriteLine("   Is this a generic type? {0}",
                t.IsGenericType);
            Console.WriteLine("   Is this a generic type definition? {0}",
                t.IsGenericTypeDefinition);

            // Get the generic type parameters or type arguments.
            Type[] typeParameters = t.GetGenericArguments();

            Console.WriteLine("   List {0} type arguments:",
                typeParameters.Length);
            foreach (Type tParam in typeParameters)
            {
                if (tParam.IsGenericParameter)
                {
                    DisplayGenericParameter(tParam);
                }
                else
                {
                    Console.WriteLine("      Type argument: {0}",
                        tParam);
                }
            }
        }

        // The following method displays information about a generic
        // type parameter. Generic type parameters are represented by
        // instances of System.Type, just like ordinary types.
        public static void DisplayGenericParameter(Type tp)
        {
            Console.WriteLine("      Type parameter: {0} position {1}",
                tp.Name, tp.GenericParameterPosition);

            Type classConstraint = null;

            foreach (Type iConstraint in tp.GetGenericParameterConstraints())
            {
                if (iConstraint.IsInterface)
                {
                    Console.WriteLine("         Interface constraint: {0}",
                        iConstraint);
                }
            }

            if (classConstraint != null)
            {
                Console.WriteLine("         Base type constraint: {0}",
                    tp.BaseType);
            }
            else
            {
                Console.WriteLine("         Base type constraint: None");
            }

            GenericParameterAttributes sConstraints =
                tp.GenericParameterAttributes &
                GenericParameterAttributes.SpecialConstraintMask;

            if (sConstraints == GenericParameterAttributes.None)
            {
                Console.WriteLine("         No special constraints.");
            }
            else
            {
                if (GenericParameterAttributes.None != (sConstraints &
                    GenericParameterAttributes.DefaultConstructorConstraint))
                {
                    Console.WriteLine("         Must have a parameterless constructor.");
                }
                if (GenericParameterAttributes.None != (sConstraints &
                    GenericParameterAttributes.ReferenceTypeConstraint))
                {
                    Console.WriteLine("         Must be a reference type.");
                }
                if (GenericParameterAttributes.None != (sConstraints &
                    GenericParameterAttributes.NotNullableValueTypeConstraint))
                {
                    Console.WriteLine("         Must be a non-nullable value type.");
                }
            }
        }
    }

}
