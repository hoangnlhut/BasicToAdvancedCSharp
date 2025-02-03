using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._2ndTime.Creational
{
  
    public interface IChair
    {
        public void BuildChair();
    }

    public class ModernChair : IChair
    {
        public void BuildChair()
        {
            Console.WriteLine("Building Modern Chair");
        }
    }

    public class AntiqueChair : IChair
    {
        public void BuildChair()
        {
            Console.WriteLine("Building Antique Chair");
        }
    }

    public interface IEngine
    {
        public void BuildEngine();

    }

    public class ModernEngine : IEngine
    {
        public void BuildEngine()
        {
            Console.WriteLine("Building Speed Engine for Super Car");
        }
    }

    public class AntiqueEngine : IEngine
    {
        public void BuildEngine()
        {
            Console.WriteLine("Building Ordinary Engine for Antique Car");
        }
    }

    public abstract class AbstracFactoryCar
    {
        public abstract IChair CreateChair();
        public abstract IEngine CreateEngine();

        public virtual void BuilingCompleteCar()
        {
            Console.WriteLine("Starting Building car.....");
            CreateChair().BuildChair();
            CreateEngine().BuildEngine();
            Console.WriteLine("Complete your car.....");
        }
    }

    public class SuperCarFactory : AbstracFactoryCar
    {
        public override IChair CreateChair() => new ModernChair();
        public override IEngine CreateEngine() => new ModernEngine();
    }

    public class VintageCarFactory : AbstracFactoryCar
    {
        public override IChair CreateChair() => new AntiqueChair();
        public override IEngine CreateEngine() => new AntiqueEngine();
    }

    public class AbstractFactoryClient
    {
        public static void RunFactory(AbstracFactoryCar factory) => factory.BuilingCompleteCar();
    }
}
