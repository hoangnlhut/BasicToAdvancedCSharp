using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DataStructure
{
    public class QueueSample
    {
        public void Test()
        {
            //create new Stack
            Queue<int?> queueSample = new Queue<int?>();
            queueSample.Enqueue(1);
            queueSample.Enqueue(2);
            queueSample.Enqueue(3);
            queueSample.Enqueue(4);
            queueSample.Enqueue(5);
            queueSample.Enqueue(null);

            //display item in the peak of queue
            Console.WriteLine($"Item in the peak of queue now is : {queueSample.Peek}");
            //display item in the last of queue
            Console.WriteLine($"Item in the Last of queue now is : {queueSample.Last()}");

            DisplayQueue(queueSample);

            queueSample.Dequeue();
            queueSample.Dequeue();
            queueSample.Dequeue();
            queueSample.Dequeue();
            var dequeuedItem = queueSample.Dequeue();
            Console.WriteLine($"The last popped item is {dequeuedItem}");
        }

        private void DisplayQueue(Queue<int?> queueSample)
        {
            Console.WriteLine($"Print {queueSample.Count} item in Queue");
            foreach (var item in queueSample)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------------");
        }
    }
}
