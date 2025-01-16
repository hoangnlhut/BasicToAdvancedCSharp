using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._1stTime.Creational
{
    public interface IBuilder
    {
        void Reset();
        void BuildStepA();
        void BuildStepB();
        void BuildStepZ();

    }

    public class Product
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;
            for (int i = 0; i < _parts.Count; i++)
            {
                str += _parts[i] + ", ";
            }
            str = str.Remove(str.Length - 2); // removing last ",c"
            return "Product parts: " + str;
        }
    }

    public class ConCreateBuilder : IBuilder
    {
        private Product? _product;
        public ConCreateBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _product = new Product();
        }
        public void BuildStepA()
        {
            _product!.Add("Step 1 - A");
        }

        public void BuildStepB()
        {
            _product!.Add("Step 2 - B");
        }

        public void BuildStepZ()
        {
            _product!.Add("Step 3 - C");
        }

        public Product GetProduct()
        {
            Product result = _product!;
            Reset();
            return result;
        }
    }

    public class Director 
    {
        private IBuilder _builder;
        public Director(IBuilder builder)
        {
            _builder = builder;
        }

        public void BuildMinimalViableProduct()
        {
            _builder.BuildStepA();
        }

        public void BuildFullFeaturedProduct()
        {
            _builder.BuildStepA();
            _builder.BuildStepB();
            _builder.BuildStepZ();
        }
    }
}
 