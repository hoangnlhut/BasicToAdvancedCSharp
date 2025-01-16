using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._1stTime.Creational
{
    public abstract class Creator
    {
        //Factory Method
        public abstract IProduct FactoryMethod();
        
        public void SomeOperation()
        {
            var product = FactoryMethod();
            product.DoStuff();
        }   
    }

    public class CreatorProductA : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ProductA();
        }
    }

    public class CreatorProductB : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ProductB();
        }
    }

    public interface IProduct
    {
        void DoStuff();
    }

    public class ProductA : IProduct
    {
        public void DoStuff()
        {
            Console.WriteLine("Product A");
        }
    }

    public class ProductB : IProduct
    {
        public void DoStuff()
        {
            Console.WriteLine("Product B");
        }
    }
}
