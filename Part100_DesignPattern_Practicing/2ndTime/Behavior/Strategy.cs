using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._2ndTime.Behavior
{
    public interface IStrategyRouting
    {
        void RoutingExecute();
    }

    public class RoutingWalk : IStrategyRouting
    {
        public void RoutingExecute()
        {
            Console.WriteLine("Routing to the destination by walking");
        }
    }

    public class RoutingCar : IStrategyRouting
    {
        public void RoutingExecute()
        {
            Console.WriteLine("Routing to the destination by car");
        }
    }

    public class RoutingTrain : IStrategyRouting
    {
        public void RoutingExecute()
        {
            Console.WriteLine("Routing to the destination by train");
        }
    }

    public class ContextRoutingApp
    {
        private IStrategyRouting _strategy;
        public ContextRoutingApp(IStrategyRouting strategy)
        {
            SetContext(strategy);
        }

        public void SetContext(IStrategyRouting strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteRouting()
        {
            _strategy.RoutingExecute();
        }
    }

    public class ClientStrategy2
    {
        public static void Main2()
        {
            ContextRoutingApp context = new ContextRoutingApp(new RoutingTrain());
            context.ExecuteRouting();

            context.SetContext(new RoutingWalk());
            context.ExecuteRouting();
        }
    }

}
