using Part13Static.SingletonPattern;
using System;
using System.Text.RegularExpressions;

namespace Part13Static
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestMethod();
            //TestRegex();
            //Console.WriteLine(Singleton.Instance);
            TestAccessCouterThreadSafe();
        }

        private static void TestMethod()
        {
            ClassC a = new() { };
            a.CountClassC();
            a.CountClassC();
            a.PrintParams();

            ClassC b = new ClassC() { };
            b.SetStaticCount(400);
            b.CountClassC();
            b.PrintParams();

            a.PrintParams();

            Console.WriteLine($"Set static count variable of class ClassC to 900");
            ClassC.count = 900;

            a.PrintParams();
            b.PrintParams();

            Console.WriteLine($"print static count variable of class ClassC : {ClassC.count}");
        }

        private static void TestRegex()
        {
            string pattern = @"^([a-zA-Z]:)?(\\[^\\/:*?""<>|\r\n]+)*\\?([^\\/:*?""<>|\r\n]+)$";
            Regex regex = new Regex(pattern);

            string[] testPaths = {
            @"C:\folder\file.txt",
            @"file.txt",
            @"\folder\file.txt",
            @"C:file.txt",
            @"C:\folder\subfolder\file.txt",
            @"\\server\share\file.txt",
            @"C:\Users\Hoang\Downloads\test\hoang.txt",
            @"hoang.txt"
            };

            foreach (string path in testPaths)
            {
                if (regex.IsMatch(path))
                {
                    Console.WriteLine($"Valid: {path}");
                }
                else
                {
                    Console.WriteLine($"Invalid: {path}");
                }
            }
        }

        private static void TestAccessCouterThreadSafe() {
            //example 1 non thread
            //AccessCouterThreadSafe bar = AccessCouterThreadSafe.GetInstance("BAR....");
            //AccessCouterThreadSafe foo = AccessCouterThreadSafe.GetInstance("FOO....");

            //Console.WriteLine(bar.Name);
            //Console.WriteLine(foo.Name);

            // example of thread safe
            Console.WriteLine(
             "{0}\n{1}\n\n{2}\n",
             "If you see the same value, then singleton was reused (yay!)",
             "If you see different values, then 2 singletons were created (booo!!)",
             "RESULT:"
         );

            Thread process1 = new Thread(() =>
            {
                TestSingleton("FOO");
            });
            Thread process2 = new Thread(() =>
            {
                TestSingleton("BAR");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
        }

        public static void TestSingleton(string value)
        {
            AccessCouterThreadSafe singleton = AccessCouterThreadSafe.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }
    }
}
