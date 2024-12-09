using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Part35_ParallelProgramming.AISampleCodeInParrallelForAndForEach
{
    public class ParallelForEach
    {
        private static string ProcessAndTransform(string item)
        {
            return item.ToUpper();
        }

        private static bool ShouldBreak(int item) => item > 5;
        private static bool ShouldStopProcessing(int item) => item % 3 == 0;

        public static void MainParallelForEach()
        {
            // Demonstrate different breaking strategies
            //Console.WriteLine("Starting Stop Using CancellationToken");
            //StopUsingCancellationToken();
            //Console.WriteLine("Ending Stop Using CancellationToken");
            //Console.WriteLine();
            //Console.WriteLine();

            //Console.WriteLine("Starting Break Using LoopState");
            //BreakUsingLoopState();
            //Console.WriteLine("Ending Break Using LoopState");
            //Console.WriteLine();
            //Console.WriteLine();

            Console.WriteLine("Starting CollectResultsWithEarlyExit");
            CollectResultsWithEarlyExit();
            Console.WriteLine("Ending CollectResultsWithEarlyExit");
            Console.WriteLine();
            Console.WriteLine();

            //Console.WriteLine("Starting SharedStateCoordination");
            //SharedStateCoordination();
            //Console.WriteLine("Ending SharedStateCoordination");
            //Console.WriteLine();
            //Console.WriteLine();

        }

        public static void StopUsingCancellationToken()
        {
            // Method 1: Using CancellationToken
            var items = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var cancellationTokenSource = new CancellationTokenSource();
            var option = new ParallelOptions
            {
                CancellationToken = cancellationTokenSource.Token,
                MaxDegreeOfParallelism = 4  // 2 tasks are run parallel
            };

            try
            {
                Parallel.ForEach(items, option
                    ,
                    (item, state) =>
                    {
                        // Condition to stop processing
                        if (item > 5)
                        {
                            // Stop all iterations
                            state.Stop();

                            // Or cancel the entire operation
                            cancellationTokenSource.Cancel();
                        }

                        ProcessItem(item);
                    }
                );
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation was canceled.");
            }
        }

        public static void BreakUsingLoopState()
        {
            // Method 2: Using ParallelLoopState to break iterations
            var items = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var option = new ParallelOptions
            {
                MaxDegreeOfParallelism = 4  // 2 tasks are run parallel
            };

            Parallel.ForEach(items, option, (item, state) =>
            {
                // Conditional breaking
                if (ShouldBreak(item))  // ShouldBreak(int item) => item > 5;
                {
                    // Break the current iteration and subsequent iterations
                    state.Break();
                    return;
                }

                ProcessItem(item);
            });
        }

        public static void CollectResultsWithEarlyExit()
        {
            // Method 3: Collecting results with potential early exit
            var items = new List<string> { "apple", "banana", "cherry", "date", "elderberry" };
            var results = new ConcurrentBag<string>();
            var cancellationTokenSource = new CancellationTokenSource();

            var option = new ParallelOptions
            {
                CancellationToken = cancellationTokenSource.Token,
                MaxDegreeOfParallelism = 2  // 2 tasks are run parallel
            };

            Parallel.ForEach(items,
                option,
                (item, state) =>
                {
                    try
                    {
                        // Process and potentially collect results
                        string processedItem = ProcessAndTransform(item);

                        // Example condition for early exit
                        if (processedItem.Length > 4)
                        {
                            results.Add(processedItem);
                            state.Stop(); // Stop further processing
                        }
                    }
                    catch (Exception)
                    {
                        // Handle or log exception
                        Console.WriteLine("Exceptions");
                        state.Stop();
                    }
                }
            );

            // Work with collected results
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        public static void SharedStateCoordination()
        {
            // Method 4: Coordination with shared state
            var items = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            bool shouldStop = false;
            object lockObject = new object();

            Parallel.ForEach(items, (item, state) =>
            {
                // Check shared flag in a thread-safe manner
                lock (lockObject)
                {
                    if (shouldStop)
                    {
                        state.Stop();
                        return;
                    }
                }

                // Process item
                ProcessItem(item);

                // Potentially set stop condition
                if (ShouldStopProcessing(item))
                {
                    lock (lockObject)
                    {
                        shouldStop = true;
                    }
                    state.Stop();
                }
            });
        }

        // Helper methods (mock implementations)
        private static void ProcessItem(int item)
        {
            Console.WriteLine($"Processing {item}");
            // Simulate some work
            Thread.Sleep(100);
        }

        
    }
}
