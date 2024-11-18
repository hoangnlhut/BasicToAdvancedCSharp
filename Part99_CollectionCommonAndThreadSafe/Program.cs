using Part99_CollectionCommonAndThreadSafe.Examples;

namespace Part99_CollectionCommonAndThreadSafe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Recheck to Reference And Value Type
            //ReferenceAndValueTypeExample.Main1();

            //ConcurrentBugDemo
            //ConcurrentBagDemo.MainConcurrentBagDemo();

            //BlockingCollection:  Add and Take Items Individually 
            //BlockingCollectionExample.MainAddAndTakeItems();

            //Volatile Example
            VolatileExample.MainVolatileExample();
        }
    }
}
