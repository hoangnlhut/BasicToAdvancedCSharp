using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part35_ParallelProgramming.AISampleCodeInParrallelForAndForEach
{
    public class ParallelFor
    {
        // Helper methods (mock implementations)
        private static bool SomeCondition(int i) => i > 500;
        private static void ProcessItem(int i) => Console.WriteLine($"Processing {i}");
        private static bool SomeSpecialConditionMet(int i) => i % 7 == 0;

        public static void MainParallelFor()
        {
            // Demonstrate different breaking strategies

            Console.WriteLine("Starting Stop Using CancellationToken");
            StopUsingCancellationToken();
            Console.WriteLine("Ending Stop Using CancellationToken");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Starting Breaking Using LoopState");
            BreakUsingLoopState();
            Console.WriteLine("Ending Breaking Using LoopState");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Starting ConditionalBreak With Share flag");
            ConditionalBreakWithSharedFlag(); 
            Console.WriteLine("Ending ConditionalBreak With Share flag");
            Console.WriteLine();
            Console.WriteLine();
            
            
        }
        public static void StopUsingCancellationToken()
        {
            // Method 1: Using CancellationToken
            var cancellationTokenSource = new CancellationTokenSource();
            var option = new ParallelOptions { 
                CancellationToken = cancellationTokenSource.Token 
            };

            try
            {
                Parallel.For(0, 1000, option,
                    (i, state) =>
                    {
                        // Some condition to break
                        if (i > 500)
                        {
                            // Stop all iterations
                            state.Stop();

                            // Or cancel the entire operation
                            cancellationTokenSource.Cancel();
                            return
                            ;
                        }

                        // Normal processing
                        Console.WriteLine($"Processing item {i}");
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
            // Method 2: Using ParallelLoopState to break specific iterations
            Parallel.For(0, 1000, (i, state) =>
            {
                // Conditional breaking
                if (SomeCondition(i))
                {
                    // Break the current iteration and subsequent iterations
                    state.Break();
                    return;
                }

                // Normal processing
                ProcessItem(i);
            });
        }

        public static void ConditionalBreakWithSharedFlag()
        {
            // Method 3: Using a shared flag for coordination
            bool shouldStop = false;
            object lockObject = new object();

            Parallel.For(0, 1000, (i, state) =>
            {
                lock (lockObject)
                {
                    if (shouldStop)
                    {
                        state.Stop();
                    }
                }

                //Some processing that might set the flag
                if (SomeSpecialConditionMet(i))   // SomeSpecialConditionMet(int i) => i % 7 == 0;
                {
                    lock (lockObject)
                    {
                        shouldStop = true;
                    }
                    state.Stop();
                }

                #region try other way
                //// Check shared flag in a thread-safe manner
                //if (state.ShouldExitCurrentIteration)
                //{
                //    if (state.LowestBreakIteration < i)
                //        return;
                //}

                //if (SomeSpecialConditionMet(i))   // SomeSpecialConditionMet(int i) => i % 7 == 0;
                //{
                //    state.Stop();
                //}
                #endregion

                ProcessItem(i);
            });
        }

       
    }
}
