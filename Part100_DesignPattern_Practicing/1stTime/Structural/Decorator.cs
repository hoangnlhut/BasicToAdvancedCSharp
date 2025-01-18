using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._1stTime.Structural
{
    // Decorator Pattern is a structural design pattern that lets you attach new behaviors to objects by placing these objects inside special wrapper objects that contain the new behaviors.

    #region example same as tutorial
    public interface IComponent
    {
        string Execute();
    }

    public class ConcreteComponent : IComponent
    {
        public string Execute()
        {
            return "ConcreteComponent";
        }
    }

    public class BaseDecorator : IComponent
    {
        private IComponent _component;
        public BaseDecorator(IComponent component)
        {
            _component = component;
        }

        public virtual string Execute()
        {
            return _component.Execute();
        }
    }

    public class ConcreteDecoratorA : BaseDecorator
    {
        public ConcreteDecoratorA(IComponent component) : base(component)
        {
        }
        public override string Execute()
        {
            return $"ConcreteDecoratorA - {base.Execute()}";
        }
    }

    public class ConcreteDecoratorB : BaseDecorator
    {
        public ConcreteDecoratorB(IComponent component) : base(component)
        {
        }
        public override string Execute()
        {
            return $"ConcreteDecoratorB - {base.Execute()}";
        }
    }

    #endregion

    #region example with pizza
    public abstract class Pizza
    {
        public abstract void DoPizza();

    }

    public class ThickBasePizza : Pizza
    {
        public override void DoPizza()
        {
            Console.WriteLine("Thick Base Pizza");
        }
    }

    public class ThinBasePizza : Pizza
    {
        public override void DoPizza()
        {
            Console.WriteLine("Thin Base Pizza");
        }
    }


    public class PizzaDecorator : Pizza
    {
        private Pizza _pizza;
        public PizzaDecorator(Pizza pizza)
        {
            _pizza = pizza;
        }
        public override void DoPizza()
        {
            _pizza.DoPizza();
        }
    }

    public class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(Pizza pizza) : base(pizza)
        {
        }
        public override void DoPizza()
        {
            base.DoPizza();
            Console.WriteLine("Add more Cheese");
        }
    }

    public class TomatoDecorator : PizzaDecorator
    {
        public TomatoDecorator(Pizza pizza) : base(pizza)
        {
        }
        public override void DoPizza()
        {
            base.DoPizza();
            Console.WriteLine("Add more Tomato");
        }
       
    }

    public class OnionDecorator : PizzaDecorator
    {
        public OnionDecorator(Pizza pizza) : base(pizza)
        {
        }
        public override void DoPizza()
        {
            base.DoPizza();
            Console.WriteLine("Add more Onion");
        }
    }

    public class BaconDecorator : PizzaDecorator
    {
        public BaconDecorator(Pizza pizza) : base(pizza)
        {
        }
        public override void DoPizza()
        {
            base.DoPizza();
            Console.WriteLine("Add more Bacon");
        }
    }


    #endregion
}