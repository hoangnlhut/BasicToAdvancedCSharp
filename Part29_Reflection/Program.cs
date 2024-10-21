using Part29_CustomBinding;
using Part29_Reflection.Basics;
using Part29_Reflection.GeneticType;
using Part29_Reflection.MemberInvocation;
using Part29_Reflection.NamnetReflection;
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
            #region Reflection Basics

            #region  Discovering Module Information
            //// Get the current assembly
            //Assembly assembly = Assembly.GetExecutingAssembly();

            //// Display the assembly name
            //Console.WriteLine($"Assembly Name: {assembly.FullName}");

            //// Display the modules name in the assembly
            //Module[] modules = assembly.GetModules();
            //foreach (Module module in modules)
            //{
            //    Console.WriteLine($"Module Name: {module.Name}");
            //}
            #endregion

            #region Understanding Constructors and Methods
            //Type type = typeof(DemoClass);

            //// Instantiate an object using the constructor
            //object instance = Activator.CreateInstance(type, new object[] { 42 });

            //// Invoke a method on the object
            //MethodInfo method = type.GetMethod("DemoMethod");
            //method.Invoke(instance, new object[] { "Hello, reflection!" });
            #endregion

            #region Accessing Fields and Properties
            //DemoClass demoObject = new DemoClass(50);
            //Type type = demoObject.GetType();

            //// Access and set the value of a field
            //FieldInfo field = type.GetField("DemoField");
            //field.SetValue(demoObject, 42);

            //// Access and get the value of a property
            //PropertyInfo property = type.GetProperty("DemoProperty");
            //property.SetValue(demoObject, "Hello, reflection!");

            //// Display the values
            //Console.WriteLine($"Field : {demoObject.DemoField}");
            //Console.WriteLine($"Property : {property.GetValue(demoObject)}");
            #endregion

            #region Working with Events
            //DemoClass demoObject = new DemoClass(65);
            //Type type = demoObject.GetType();

            //// Attach an event handler dynamically
            //EventInfo demoEvent = type.GetEvent("DemoEvent");
            //MethodInfo eventHandler = typeof(Program).GetMethod("DemoEventHandler", BindingFlags.Static | BindingFlags.NonPublic);
            //Delegate handler = Delegate.CreateDelegate(demoEvent.EventHandlerType, eventHandler);
            //demoEvent.AddEventHandler(demoObject, handler);

            //// Raise the event
            //demoObject.RaiseEvent("Hello, reflection!");
            #endregion

            #region  Understanding Parameters
            //DemoClass demoObject = new DemoClass(90);
            //Type type = demoObject.GetType();

            //// Invoke a method with parameters dynamically
            //MethodInfo[] multiMethod = type.GetMethods();
            //foreach (var item in multiMethod)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //display demomethod with 2 parameters
            // MethodInfo? method = type.GetMethod("DemoMethod", new Type[] { typeof(int), typeof(string) });

            // object[] parameters = new object[] { 42, "Hello, reflection!" };
            // method?.Invoke(demoObject, parameters);

            // //display demomethod with 2 parameters
            //method = type.GetMethod("DemoMethod", new Type[] { typeof(string) });

            // parameters = new object[] { "aaaaaaaa anh em oi!" };
            // method?.Invoke(demoObject, parameters);
            #endregion

            #region Exploring Custom Attributes
            //Type type = typeof(DemoClass);

            //// Check if the class has a custom attribute
            //bool hasAttribute = type.IsDefined(typeof(CustomAttribute), inherit: false);
            //if (hasAttribute)
            //{
            //    // Retrieve the custom attribute
            //    CustomAttribute attribute = (CustomAttribute)type.GetCustomAttribute(typeof(CustomAttribute));
            //    string description = attribute.Description;
            //    Console.WriteLine($"Custom Attribute Description: {description}");
            //}
            #endregion

            #endregion

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
            //args = new string[] { "/Out:<file name>", "/Help", "/Priority:High" };
            //DisplayInvocation(args);
            #endregion

            #region Determining Whether a Class or Method Supports Generics
            //Type type;
            //type = typeof(System.Nullable<>);
            //Console.WriteLine(type.ContainsGenericParameters);
            //Console.WriteLine(type.IsGenericType);

            //type = typeof(System.Nullable<DateTime>);
            //Console.WriteLine(type.ContainsGenericParameters);
            //Console.WriteLine(type.IsGenericType);
            #endregion

            #region invoking reflection using dynamic
            //dynamic data1 = new object();
            //Console.WriteLine($"This type of dynamic data now is {data1.GetType()}");

            //dynamic data = "Hello!  My name is Inigo Montoya";
            //Console.WriteLine(data);
            //Console.WriteLine($"This type of dynamic data now is {data.GetType()}");

            //data = (double)data.Length;
            //data = data * 3.5 + 28.6;
            //if (data == 2.4 + 112 + 26.2)
            //// The distance (in miles) for the swim, bike, and
            //// run portions of an Ironman triathlon, respectively
            //{
            //    Console.WriteLine(
            //        $"{data} makes for a long triathlon.");
            //    Console.WriteLine($"This type of dynamic data now is {data.GetType()}");
            //}
            //else
            //{
            //    data.NonExistentMethodCallStillCompiles();
            //}
            #endregion


            #region nam .net
            var dll = @"E:\LEARNING\SELF_TRAINING_FOLDER\C#Nam.NETFrom0To1\Basic\Part29MyAssembly\bin\Debug\net8.0\Part29MyAssembly.dll";
            args = new string[] { dll };
            NamReflection.NamDotNetReflection(args);
            #endregion


        }

        

        private static void DemoEventHandler(object sender, EventArgs e)
        {
            DemoEventArgs demoEventArgs = (DemoEventArgs)e;
            Console.WriteLine($"Event raised with message: {demoEventArgs.Message}");
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
