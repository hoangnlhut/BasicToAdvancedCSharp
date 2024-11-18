using Part99_CollectionCommonAndThreadSafe.Examples.BlockingCollection;

namespace Part99_CollectionCommonAndThreadSafe
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            //Recheck to Reference And Value Type
            //ReferenceAndValueTypeExample.Main1();

            //ConcurrentBugDemo
            //ConcurrentBagDemo.MainConcurrentBagDemo();

            #region Blocking Collection Examples
            //BlockingCollection:  Add and Take Items Individually 
            //BlockingCollectionExample.MainAddAndTakeItems();

            // Blocking Collection with Cancellation
            //BlockingCollectionWithCancellation.MainBlockingCollectionWithCancellation();

            // Blocking Collection with Foreach
            await BlockingCollectionUsingForeach.MainBlockingCollectionUsingForeach();
            #endregion
            //Volatile Example
            //VolatileExample.MainVolatileExample();

        }
    }
}
