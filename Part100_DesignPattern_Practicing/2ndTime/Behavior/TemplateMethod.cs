using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._2ndTime.Behavior
{
    //Template method is define a skeleton of an algoritham and then sub-class inherits this template method will have each specific step for implementation

    // with this pattern: you can define core steps of an algorithm in a method butallow subclasses to override specific steps without changing the overall structure
    //Algorithm()
    //{
    //   Step1 ( can change in subclass)
    //   Step2 (Core - immutable)
    //   Step3 (Core - immutable)
    //   Step4 (Core - immutable)
    //   Step5 ( can change in subclass)
    //   Step6 ( can change in subclass)
    //}


    public abstract class CarProducer
    {
        // this is template method
        public void BuildCar()
        {
            Start();  // common step that all sub-class must have
            BuildCarFramework();
            BuildEngine();
            BuildInterior();
            BuildExterior();
            Done(); // common step that all sub-class must have
        }

        private void Done()
        {
            Console.WriteLine("A car was completely done.");
        }

        private void Start()
        {
            Console.WriteLine("A car is going to build in a few minutes.....");
        }

        public abstract void BuildCarFramework();
        public abstract void BuildEngine();
        public abstract void BuildInterior();
        public abstract void BuildExterior();
    }

    public class HyperCar : CarProducer
    {
        public override void BuildCarFramework()
        {
            Console.WriteLine("Building hypercar framework.....");
        }

        public override void BuildEngine()
        {
            Console.WriteLine("Building hypercar V8 engine.....");
        }

        public override void BuildExterior()
        {
            Console.WriteLine("Building sport and swag exterior for hypercar.....");
        }

        public override void BuildInterior()
        {
            Console.WriteLine("Building sport and strong interior for hypercar.....");
        }
    }

    public class VintageCar : CarProducer
    {
        public override void BuildCarFramework()
        {
            Console.WriteLine("Building vintage framework.....");
        }

        public override void BuildEngine()
        {
            Console.WriteLine("Building vintage V6 engine.....");
        }

        public override void BuildExterior()
        {
            Console.WriteLine("Building classical exterior for hypercar.....");
        }

        public override void BuildInterior()
        {
            Console.WriteLine("Building luxury and classical interior for hypercar.....");
        }
    }

    public class MainTemplateMethod
    {
        public static void Main2()
        {
            List<CarProducer> list = new List<CarProducer>
            {
                new HyperCar(),
                new VintageCar()
            };

            foreach (var item in list)
            {
                item.BuildCar();
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
