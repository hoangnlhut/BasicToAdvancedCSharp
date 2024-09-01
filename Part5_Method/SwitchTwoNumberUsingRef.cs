using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part5_Method
{
    public static class SwitchTwoNumberUsingRef
    {
        public static void Implement(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
