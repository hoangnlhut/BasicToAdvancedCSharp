using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace Part99_CollectionCommonAndThreadSafe.Examples.BlockingCollection
{
    public class BlockingCollectionExample
    {
        //https://learn.microsoft.com/en-us/dotnet/standard/collections/thread-safe/how-to-add-and-take-items
        #region How to: Add and Take Items Individually from a BlockingCollection
        public static void MainAddAndTakeItems()
        {
            // Increase or decrease this value as desired.
            int itemsToAdd = 500;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                int width = Math.Max(Console.BufferWidth, 80);
                int height = Math.Max(Console.BufferHeight, itemsToAdd * 2 + 3);

                // Preserve all the display output for Adds and Takes
                Console.SetBufferSize(width, height);
            }

            // A bounded collection. Increase, decrease, or remove the
            // maximum capacity argument to see how it impacts behavior.
            var numbers = new BlockingCollection<int>(50);

            // A simple blocking consumer with no cancellation.
            Task.Run(() =>
            {
                int i = -1;
                while (!numbers.IsCompleted)
                {
                    try
                    {
                        i = numbers.Take();
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Adding was completed!");
                        break;
                    }
                    Console.WriteLine("Take:{0} ", i);

                    // Simulate a slow consumer. This will cause
                    // collection to fill up fast and thus Adds wil block.
                    Thread.SpinWait(100000);
                }

                Console.WriteLine("\r\nNo more items to take. Press the Enter key to exit.");
            });

            // A simple blocking producer with no cancellation.
            Task.Run(() =>
            {
                for (int i = 0; i < itemsToAdd; i++)
                {
                    numbers.Add(i);
                    Console.WriteLine("Add:{0} Count={1}", i, numbers.Count);
                }

                // See documentation for this method.
                numbers.CompleteAdding();
            });

            // Keep the console display open in debug mode.
            Console.ReadLine();
        }
        #endregion

    }
}
