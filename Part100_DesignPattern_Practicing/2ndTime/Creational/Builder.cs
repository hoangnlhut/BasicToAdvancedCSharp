using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._2ndTime.Creational
{
    //Builder là một lớp trừu tượng để xây dựng các bước lần lượt thực hiện. Chúng ta có thể tạo nhiều phương thức với mỗi phương thức sẽ có các bước cần thiết chứ ko phải bắt buộc tất cả các bước
    // In Builder we have an abstract class contains all step that a class inherits from it to define content of action of all step and we have director class can have many methods which contain some method that act some actions in all action of early abstract parent class.
    public interface IBuilder
    {
        void Reset();
        void StepAddBread(string nameOfBread);
        void StepAddVeggies(string nameOfVeggies);
        void StepAddSauces(string nameOfSauces);
        void StepAddMeat(string nameOfMeat);
        Product GetProduct();
    }

    public class Product
    {
        public string Bread { get; set; }
        public string Veggies { get; set; }
        public string Sauces { get; set; }
        public string Meat { get; set; }

        public override string ToString()
        => $"Your product is {Bread}, {Veggies} {Meat} and {Sauces}";
    }

    public class ConcreateProduct2 : IBuilder
    {
        private Product? _product = null;
        public ConcreateProduct2()
        {
            Reset();
        }

        public void Reset()
        {
            _product = new Product();
        }

        public void StepAddBread(string nameOfBread)
        {
            _product.Bread = nameOfBread;
        }

        public void StepAddMeat(string nameOfMeat)
        {
            _product.Meat = nameOfMeat;
        }

        public void StepAddSauces(string nameOfSauces)
        {
            _product.Sauces = nameOfSauces;
        }

        public void StepAddVeggies(string nameOfVeggies)
        {
            _product.Veggies = nameOfVeggies;
        }

        public Product GetProduct()
        {
            var latestProduct = _product;
            Reset();
            return latestProduct!;
        }
    }

    public class Director2
    {
        private IBuilder? _builder = null;
        public Director2(IBuilder builder)
        {
            _builder = builder;
        }

        public void VegetarianBread()
        {
            _builder.StepAddBread("Plain bread");
            _builder.StepAddSauces("Tomato sauces");
            _builder.StepAddVeggies("green vegetable");
            Console.WriteLine(_builder.GetProduct().ToString());
            Console.WriteLine("Completing Vegetarian Bread");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void GymerBread()
        {
            _builder.StepAddBread("Black bread");
            _builder.StepAddSauces("Tomato and chilli sauces");
            _builder.StepAddVeggies("more green vegetable");
            _builder.StepAddMeat("half kg steak");
            Console.WriteLine(_builder.GetProduct().ToString());
            Console.WriteLine("Completing Gymer Bread");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
