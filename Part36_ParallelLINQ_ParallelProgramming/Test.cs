using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part36_ParallelLINQ_ParallelProgramming
{
    public abstract class Test
    {
        protected string Name = string.Empty;
        protected Test(string name)
        {
            Name = name;
        }

        public abstract void Print();
    }

    public class MyClass : Test
    {
        public MyClass(string name) : base(name)
        {
        }

        public override void Print()
        {
            Console.WriteLine("Name: " + base.Name);

        }
    }

    public interface ITest
    {
        public string FirstName { get; set; }
        void Print();
    }
}
