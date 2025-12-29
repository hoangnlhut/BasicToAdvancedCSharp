using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part11_12OOP.PolymorphismT
{
    public class Animal1
    {
        public void A()
        {
            Console.WriteLine("Animal.A");
        }
    }

    public class Bird : Animal1
    {
        public new void A()
        {
            Console.WriteLine("Bird.A");
        }
    }
}
