using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part13Static
{
    public class ClassC
    {
        public static int count = 21;
        public int nonStaticCount;

        public void SetStaticCount(int valueToSet) 
        {
            count = valueToSet;
        }
        public void CountClassC()
        {
            count++;
            nonStaticCount++;
        }

        public static void A()
        {
            count = 600;
            //nonStaticCount = 800; error: static method only access to Static members - not non-static members
        }

        public void PrintParams()
        {
            Console.WriteLine($"Count : {count}");
            Console.WriteLine($"Non Static Count : {nonStaticCount}");

        }
    }
}
