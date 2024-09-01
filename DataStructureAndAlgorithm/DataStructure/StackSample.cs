using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DataStructure
{
    public class StackSample
    {
        public void Test()
        {
            //create new Stack
            Stack<int?> stackSample = new Stack<int?>();
            stackSample.Push(1);
            stackSample.Push(2);
            stackSample.Push(3);
            stackSample.Push(4);
            stackSample.Push(5);
            stackSample.Push(null);

            DisplayStack(stackSample);

            stackSample.Pop();
            stackSample.Pop();
            stackSample.Pop();
            stackSample.Pop();
            var poppedItem = stackSample.Pop();
            Console.WriteLine($"The last popped item is {poppedItem}");
        }

        private void DisplayStack(Stack<int?> stackSample)
        {
            Console.WriteLine($"Print {stackSample.Count} item in Stack");
            foreach (var item in stackSample)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------------");
        }
    }
}
