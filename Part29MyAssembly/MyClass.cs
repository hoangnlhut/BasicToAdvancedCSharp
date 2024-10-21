using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part29MyAssembly
{
    public class MyClass
    {
        public static int Count = 0;
        public int a = 10;
        public int b = 20;
        public string Name = "Hoang";

        public string Address { get; set; } = "41 tho nhuom";

        public MyClass()
        {
                
        }

        public MyClass(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public void MyPublicMethod() { }

        private void MyPrivateMethod() { }

        public static int Add(int a, int b) => a + b; 
    }
}
