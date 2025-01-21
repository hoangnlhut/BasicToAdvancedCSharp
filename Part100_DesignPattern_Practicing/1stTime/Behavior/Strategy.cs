using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._1stTime.Behavior
{
    //Strategy pattern is a behavioral design pattern that lets you define a family of algorithms, put each of them into a separate class, and make their objects interchangeable.
    public interface IStrategyMoving
    {
        void Move();
    }

    public class Walking : IStrategyMoving
    {
        public void Move()
        {
            Console.WriteLine("Walking");
        }
    }

    public class Running : IStrategyMoving
    {
        public void Move()
        {
            Console.WriteLine("Running");
        }
    }

    public class CarMoving : IStrategyMoving
    {
        public void Move()
        {
            Console.WriteLine("Moving by Car");
        }
    }
    public class PublicTransportation : IStrategyMoving
    {
        public void Move()
        {
            Console.WriteLine("Moving by Bus");
        }
    }

    public class ContextStrategy
    {
        private IStrategyMoving _strategyMoving;
        public ContextStrategy(IStrategyMoving strategyMoving)
        {
            _strategyMoving = strategyMoving;
        }
        public void SetStrategy(IStrategyMoving strategyMoving)
        {
            _strategyMoving = strategyMoving;
        }
        public void Move()
        {
            _strategyMoving.Move();
        }
    }
}
