using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._2ndTime.Creational
{
    #region first way
    public class FactoryMethod2
    {
        public static IPizza PizzaFactory(string country) =>
            country switch
            {
                "USA" => new PizzaHut(),
                "JP" => new Pizza4P(),
                _ => new PizzaNothing()
            };
    }

    public class PizzaNothing : IPizza
    {
        public void DoPizza()
        {
            Console.WriteLine("You selected wrong country to eat pizza");
        }
    }
    #endregion


    #region Second Way
    public abstract class Creator2
    {
        public abstract IPizza FactoryMethod();

        public virtual void DoOperation() => FactoryMethod().DoPizza();
       
    }

    public class CreatorHut : Creator2
    {
        public override IPizza FactoryMethod()
        {
            return new PizzaHut();
        }
    }

    public class Creator4P : Creator2
    {
        public override IPizza FactoryMethod()
        {
            return new Pizza4P();
        }
    }

    public class CreatorNothing : Creator2
    {
        public override IPizza FactoryMethod()
        {
            return new PizzaNothing();
        }
    }


    #endregion
    public interface IPizza
    {
        public void DoPizza();
    }

    public class PizzaHut : IPizza
    {
        public void DoPizza()
        {
            Console.WriteLine("Welcome to Pizzahut");
        }
    }
    public class Pizza4P : IPizza
    {
        public void DoPizza()
        {
            Console.WriteLine("Welcome to Pizza 4P");
        }
    }
}
