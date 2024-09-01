using DataStructureAndAlgorithm.Algorithm.Sort;
using DataStructureAndAlgorithm.DataStructure;

namespace DataStructureAndAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Data Structure
            //Console.WriteLine("Test Dictionary Data Type");
            //DictionarySample dictionarySample = new DictionarySample();
            //dictionarySample.TestDictionary();

            //Console.WriteLine("Test HashSet Data Type");
            //HashSetSample hashSetSample = new HashSetSample();
            //hashSetSample.Test();

            //Console.WriteLine("Test Stack Data Type");
            //StackSample stackSample = new StackSample();
            //stackSample.Test();

            //Console.WriteLine("Test Queue Data Type");
            //QueueSample queueSample = new QueueSample();
            //queueSample.Test();

            //Console.WriteLine("Test Linked List Data Type");
            //LinkedList listSample = new LinkedList();
            //listSample.Test();
            #endregion

            #region Algorithms
            //NormalSort bubbleSort = new NormalSort();
            //bubbleSort.SortAscending(1); // ascending
            //bubbleSort.SortAscending(0); // decending

            //BubleSort bubleSort = new BubleSort();
            //bubleSort.Implement();

            //Console.WriteLine("Insert Sort");
            //InsertionSort insertionSort = new InsertionSort();
            //insertionSort.Implement();

            Console.WriteLine("Selection Sort");
            SelectionSort selectionSort = new SelectionSort();
            selectionSort.Implement();
            #endregion
        }
    }
}
