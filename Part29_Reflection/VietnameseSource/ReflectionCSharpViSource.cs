using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Part29_Reflection.VietnameseSource
{
    public class ReflectionCSharpViSource
    {
        public void Run()
        {
            var fullName = string.Empty;
            var assemblyName = string.Empty;
            var constructors = new List<string>();

            var type = typeof(int);
            fullName = type.FullName;
            assemblyName = type.Assembly.FullName;
            var listConstructors = type.GetConstructors().ToList();
            foreach (var item in listConstructors) constructors.Add(item.Name);

            Console.WriteLine("Type.FullName: " + fullName);
            Console.WriteLine("Type.Assembly.FullName: " + assemblyName);
            Console.WriteLine("Type.GetConstructors: " + string.Join(", ", constructors));
            Console.WriteLine("==============================");

            double i = 100d;
            type = i.GetType();
            fullName = type.FullName;
            assemblyName = type.Assembly.FullName;
            constructors.Clear();
            listConstructors = type.GetConstructors().ToList();
            foreach (var item in listConstructors) constructors.Add(item.Name);

            Console.WriteLine("Type.FullName: " + fullName);
            Console.WriteLine("Type.Assembly.FullName: " + assemblyName);
            Console.WriteLine("Type.GetConstructors: " + string.Join(", ", constructors));
            Console.WriteLine("==============================");

            var reflectionInfo = new ReflectionInformation("Name", "Value");
            type = reflectionInfo.GetType();
            fullName = type.FullName;
            assemblyName = type.Assembly.FullName;
            constructors.Clear();
            listConstructors = type.GetConstructors().ToList();
            foreach (var item in listConstructors) constructors.Add(item.ToString());

            Console.WriteLine("Type.FullName: " + fullName);
            Console.WriteLine("Type.Assembly.FullName: " + assemblyName);
            Console.WriteLine("Type.Assembly.FullName using type.Assembly.GetName(): " + type.Assembly.GetName());
            Console.WriteLine("Type.GetConstructors: " + string.Join(", ", constructors));


            #region Example Module Class
            ReflectionInformation c1 = new ReflectionInformation(1);
            //  Show the current module.
            Module m = c1.GetType().Module;
            Console.WriteLine("The current module is {0}.", m.Name);

            //  List all modules in the assembly.
            Assembly curAssembly = typeof(Program).Assembly;
            Console.WriteLine("The current executing assembly is {0}.", curAssembly);

            Module[] mods = curAssembly.GetModules();
            foreach (Module md in mods)
            {
                Console.WriteLine("This assembly contains the {0} module", md.Name);
            }
            Console.ReadLine();
            #endregion
        }
    }
}
