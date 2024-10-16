using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part29_Reflection.GeneticType
{
    public interface ITestArgument { }

    // Define an example base class.
    public class TestBase { }

    // Define a generic class with one parameter. The parameter
    // has three constraints: It must inherit TestBase, it must
    // implement ITestArgument, and it must have a parameterless
    // constructor.
    public class Test<T> where T : TestBase, ITestArgument, new() { }

    // Define a class that meets the constraints on the type
    // parameter of class Test.
    public class TestArgument : TestBase, ITestArgument
    {
        public TestArgument() { }
    }

}
