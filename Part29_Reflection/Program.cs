using Part29_CustomBinding;
using Part29_Reflection.GeneticType;
using Part29_Reflection.MemberInvocation;
using Part29_Reflection.VietnameseSource;
using System.Diagnostics;
using System.Reflection;

namespace Part29_Reflection
{
    [Example(StringValue ="This is a string")]
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Vietnamese source
            //var newVietSource = new ReflectionCSharpViSource();
            //newVietSource.Run();
            #endregion

            #region Custom Binding
            //CustomBinding();
            //CustomBinder();
            #endregion

            #region Examine and instantiate generic types with reflection
            //GenericTypeWithReflection();
            #endregion

            #region Access Custom Attributes
            //AccessCustomeAttributes();
            #endregion

            #region Display Invocation
            DisplayInvocation(args);
            #endregion
        }

        private static void DisplayInvocation(string[] args)
        {
            CommandLineInfo commandLine = new();
            if (!CommandLineHandler.TryParse(args, commandLine, out string? errorMessage))
            {
                Console.WriteLine(errorMessage);
                DisplayHelp();
            }
            else if (commandLine.Help || string.IsNullOrWhiteSpace(commandLine.Out))
            {
                DisplayHelp();
            }
            else
            {
                if (commandLine.Priority !=
                    ProcessPriorityClass.Normal)
                {
                    // Change thread priority
                }
                // ...
            }
        }

        private static void DisplayHelp()
        {
            // Display the command-line help.
            Console.WriteLine(
                "Compress.exe /Out:< file name > /Help "
                + "/Priority:RealTime | High | "
                + "AboveNormal | Normal | BelowNormal | Idle");

        }

        private static void AccessCustomeAttributes()
        {
            MemberInfo info = typeof(Program);
            foreach (var item in info.GetCustomAttributes(true))
            {
                Console.WriteLine(item + " with value is: " + item.GetType());
            }
        }

        private static void GenericTypeWithReflection()
        {
            // Two ways to get a Type object that represents the generic
            // type definition of the Dictionary class.
            //
            // Use the typeof operator to create the generic type
            // definition directly. To specify the generic type definition,
            // omit the type arguments but retain the comma that separates
            // them.
            Type d1 = typeof(Dictionary<,>);

            // You can also obtain the generic type definition from a
            // constructed class. In this case, the constructed class
            // is a dictionary of Example objects, with String keys.
            Dictionary<string, Example> d2 = new Dictionary<string, Example>();
            // Get a Type object that represents the constructed type,
            // and from that get the generic type definition. The
            // variables d1 and d4 contain the same type.
            Type d3 = d2.GetType();
            Type d4 = d3.GetGenericTypeDefinition();

            // Display information for the generic type definition, and
            // for the constructed type Dictionary<String, Example>.
            Example.DisplayGenericType(d1);
            Example.DisplayGenericType(d2.GetType());

            // Construct an array of type arguments to substitute for
            // the type parameters of the generic Dictionary class.
            // The array must contain the correct number of types, in
            // the same order that they appear in the type parameter
            // list of Dictionary. The key (first type parameter)
            // is of type string, and the type to be contained in the
            // dictionary is Example.
            Type[] typeArgs = { typeof(string), typeof(Example) };

            // Construct the type Dictionary<String, Example>.
            Type constructed = d1.MakeGenericType(typeArgs);

            Example.DisplayGenericType(constructed);

            object o = Activator.CreateInstance(constructed);

            Console.WriteLine("\r\nCompare types obtained by different methods:");
            Console.WriteLine("   Are the constructed types equal? {0}",
                (d2.GetType() == constructed));
            Console.WriteLine("   Are the generic definitions equal? {0}",
                (d1 == constructed.GetGenericTypeDefinition()));

            // Demonstrate the DisplayGenericType and
            // DisplayGenericParameter methods with the Test class
            // defined above. This shows base, interface, and special
            // constraints.
            Example.DisplayGenericType(typeof(Test<>));
        }
        private static void CustomBinding()
        {
            // Get the type of MySimpleClass.
            Type myType = typeof(MySimpleClass);

            // Get an instance of MySimpleClass.
            MySimpleClass myInstance = new MySimpleClass();
            MyCustomBinder myCustomBinder = new MyCustomBinder();

            // Get the method information for the particular overload
            // being sought.
            MethodInfo myMethod = myType.GetMethod("MyMethod", BindingFlags.Public | BindingFlags.Instance, myCustomBinder, new Type[] { typeof(string), typeof(int) }, null);
            Console.WriteLine(myMethod.ToString());

            // Invoke the overload.
            myType.InvokeMember("MyMethod", BindingFlags.InvokeMethod,
                myCustomBinder, myInstance,
                new Object[] { "Testing...", (int)32 });
        }

        private static void CustomBinder()
        {
            Type t = typeof(CustomBinderDriver);
            MyCustomBinder binder = new MyCustomBinder();
            BindingFlags flags = BindingFlags.InvokeMethod | BindingFlags.Instance |
                BindingFlags.Public | BindingFlags.Static;
            object[] args;

            // Case 1. Neither argument coercion nor member selection is needed.
            args = new object[] { };
            t.InvokeMember("PrintBob", flags, binder, null, args);

            // Case 2. Only member selection is needed.
            args = new object[] { (long)42 };
            t.InvokeMember("PrintValue", flags, binder, null, args);

            // Case 3. Only argument coercion is needed.
            args = new object[] { "5.5" };
            t.InvokeMember("PrintNumber", flags, binder, null, args);
        }
    }
}
