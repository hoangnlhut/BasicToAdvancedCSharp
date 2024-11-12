using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part99_CollectionCommonAndThreadSafe.Examples
{
    public class ReferenceAndValueTypeExample
    {
        public static void Main1()
        {
            int a = 10;
            MyClass classMy = new MyClass() { Age = 10, Address = "41 Tho nhuom" };

            Console.WriteLine($"a in Main() BEFORE is {a}");
            Console.WriteLine($"classMy in Main() BEFORE is Age is {classMy.Age}, Address is {classMy.Address}");
            Console.WriteLine();
            Console.WriteLine("----------------------------");

            ChangeValue(a, classMy);

            
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine($"a in Main() AFTER is {a}");
            Console.WriteLine($"classMy in Main() AFTER is Age is {classMy.Age}, Address is {classMy.Address}");
        }

        private static void ChangeValue(int a, MyClass classMy)
        {
            a = 50;
            Console.WriteLine($"a in changeValue() is {a}");

            classMy.Age = 20;
            classMy.Address = "Phu Tho";
            Console.WriteLine($"classMy in changeValue() is Age is {classMy.Age}, Address is {classMy.Address}");
        }
    }

    public class MyClass
    {
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
