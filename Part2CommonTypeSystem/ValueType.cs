using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2CommonTypeSystem
{
    public class ValueType
    {
        public void Assign()
        {
            int a = 10;
            int b = a;

            Console.WriteLine($"print a: {a}");
            Console.WriteLine($"print b: {b}");

            a = 20;
            Console.WriteLine($"print new value 1 a: {a}");
            Console.WriteLine($"print  new value 1 b: {b}");

            b = 30;
            Console.WriteLine($"print new value 2 a: {a}");
            Console.WriteLine($"print  new value 2 b: {b}");
        }
    }
}
