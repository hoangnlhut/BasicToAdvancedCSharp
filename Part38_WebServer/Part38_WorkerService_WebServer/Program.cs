using System.Collections.Generic;
using static Part38_WorkerService_WebServer.Program;

namespace Part38_WorkerService_WebServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var builder = Host.CreateApplicationBuilder(args);
            //builder.Services.AddHostedService<Worker>();

            //var host = builder.Build();
            //host.Run();


            //TestReferenceParameter();
            //TestParamSring();
            //TestParamClassObject();

            //TestPolymorphism();

            //int i = 10;
            //object o = i; // boxing 
            //int j = (int)o; // unboxing
        }


        public class HoangModel
        {
            public readonly int numberTwo;

            public string? OnlyGet { get; } = "hahaha";
            public string? OnlySet
            {
                set
                {
                    _onlySet = value;

                }
            }


            public HoangModel() {
                numberTwo = 100;
                OnlySet = "hoang dep trai";
                //OnlyInitSet = "hahaha";
            }
            public string? Name { get; set; }
            public int Age { get; set; }

            private int _money;
            private string? _onlySet;

            public int Money
            {
                get
                {
                    _money = _money > 0 ? _money : 10000;
                    return  _money;
                }

                set
                {
                    _money = value;
                }

            }
        }

        private static void TestReferenceParameter()
        {
            int a = 1;
            int b = 2;
            int c = 3;
            NonRef(a, b, c);
            Console.WriteLine($"NonRef Method: a={a}, b={b}, c={c}"); // Outputs: a=1, b=2, c=3
            HaveRef(ref a, ref b, ref c);
            Console.WriteLine($"HaveRef Method: a={a}, b={b}, c={c}"); // Outputs: a=10, b=20, c=30
        }

        private static void NonRef(int a, int b, int c)
        {
            a = 10;
            b = 20;
            c = 30;
        }

        private static void HaveRef(ref int x, ref int y, ref int z)
        {
            x = 10;
            y = 20;
            z = 30;
        }

        private static void TestParamSring()
        {
            // do not change value because of value type of string is primitive
            var a = new string("hoang");
            Console.WriteLine($"BEFORE CALL TestRefStringObj Method: a={a}");
            TestRefStringObj(ref a);
            Console.WriteLine($"AFTER CALL TestRefStringObj Method: a={a}");

        }


        private static void TestRefStringObj(ref string x)
        {
            x = "Changed Value";
        }

        private static void TestParamClassObject()
        {
            // do not change value because of value type of string is primitive
            HoangModel test = new HoangModel() { Name = "hoang", Age = 10 };

            Console.WriteLine($"Number Two: {test.numberTwo}");
            Console.WriteLine($"OnlyGet: {test.OnlyGet}");

            Console.WriteLine($"Init money of HoangModel is {test.Money}");
            test.Money = 1000000;
            Console.WriteLine($"After get good job so money of HoangModel is {test.Money}");


            Console.WriteLine($"BEFORE CALL ParamClassObject Method: Name={test.Name} - Age={test.Age}"); // BEFORE CALL ParamClassObject Method: Name=hoang - Age=10
            ParamClassObject(test);
            Console.WriteLine($"AFTER CALL ParamClassObject Method: Name={test.Name} - Age={test.Age}"); // AFTER CALL ParamClassObject Method: Name=Changed Name - Age=30

        }

        private static void ParamClassObject(HoangModel model)
        {
            model.Name = "Changed Name";
            model.Age = 30;
        }

        private static int CalculateSum(int a, int b)
        {
            return a + b;
        }

        private static int CalculateSum(int a, int b, int c)
        {
            return a + b + c;
        }
    }
}