using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._1stTime.Behavior
{
    // Template Method is a behavioral design pattern that defines the skeleton of an algorithm in the superclass but lets subclasses override specific steps of the algorithm without changing its structure.
    public abstract class HouseBuildingTemplateMethod
    {
        public void BuildHouse()
        {
            BuildFoundation();
            BuildPillars();
            BuildWalls();
            BuildWindows();
            BuildRooftop();
            Console.WriteLine("House is built.");
        }
        protected virtual void BuildFoundation()
        {
            Console.WriteLine("Building foundation with cement, iron rods and sand");
        }
        protected virtual void BuildPillars()
        {
            Console.WriteLine("Building Pillars with cement and iron rods");
        }
        protected abstract void BuildWalls();
       
        protected abstract void BuildWindows();

        protected abstract void BuildRooftop();
    }

    public class WoodenHouse : HouseBuildingTemplateMethod
    {
        protected override void BuildWalls()
        {
            Console.WriteLine("Building Wooden Walls");
        }
        protected override void BuildWindows()
        {
            Console.WriteLine("Building Wooden Windows");
        }
        protected override void BuildRooftop()
        {
            Console.WriteLine("Building Wooden Rooftop");
        }
    }

    public class GlassHouse : HouseBuildingTemplateMethod
    {
        protected override void BuildWalls()
        {
            Console.WriteLine("Building Glass Walls");
        }
        protected override void BuildWindows()
        {
            Console.WriteLine("Building Glass Windows");
        }
        protected override void BuildRooftop()
        {
            Console.WriteLine("Building Glass Rooftop");
        }
    }

    public class SimenHouse : HouseBuildingTemplateMethod
    {
        protected override void BuildWalls()
        {
            Console.WriteLine("Building Simen Walls");
        }
        protected override void BuildWindows()
        {
            Console.WriteLine("Building Simen Windows");
        }
        protected override void BuildRooftop()
        {
            Console.WriteLine("Building Simen Rooftop");
        }
    }
}
