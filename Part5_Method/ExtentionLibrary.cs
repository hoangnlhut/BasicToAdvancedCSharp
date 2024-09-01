using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part5_Method
{
    public static class ExtentionLibrary
    {
        public static int FibonacciDeQuy(int n)
        {
            if (n <= 1) return n;

            return FibonacciDeQuy(n - 1) + FibonacciDeQuy(n - 2);
        }

        public static int GiaiThuaDeQuy(int n)
        {
            if (n <= 1) return 1;

            return n * GiaiThuaDeQuy(n - 1);
        }

        public static int AddNumbers(params int[] values) => values.Sum();        
    }
}
