using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DataStructure
{
    public class LinkedList
    {
        public void Test()
        {
            //create new LinkedList
            LinkedList<string> l = new LinkedList<string>();

            l.AddFirst("a"); // add first item
            l.AddLast("b");  // add last item
            var getLast = l.Last;
            l.AddAfter(getLast, "c");
            l.AddBefore(getLast, "d");

            // Display list
            DisplayLinkedList(l);

            l.RemoveFirst();
            DisplayLinkedList(l);

            l.RemoveLast();
            DisplayLinkedList(l);


        }

        public void DisplayLinkedList(LinkedList<string> list)
        {
            Console.WriteLine($"Print linked list {list.Count}");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
