using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part36_ParallelLINQ_ParallelProgramming.PLinqDataSample
{
    public class CancelAQuery
    {
        public static void MainCancelAQuery_1()
        {
            int[] source = Enumerable.Range(1, 10000000).ToArray();
            using CancellationTokenSource cts = new();

            // Start a new asynchronous task that will cancel the
            // operation from another thread. Typically you would call
            // Cancel() in response to a button click or some other
            // user interface event.
            Task.Factory.StartNew(() =>
            {
                UserClicksTheCancelButton1(cts);
            });

            int[]? results = null;
            try
            {
                results =
                    (from num in source.AsParallel().WithCancellation(cts.Token)
                     where num % 3 == 0
                     orderby num descending
                     select num).ToArray();
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (AggregateException ae)
            {
                if (ae.InnerExceptions != null)
                {
                    foreach (Exception e in ae.InnerExceptions)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            foreach (var item in results ?? Array.Empty<int>())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        static void UserClicksTheCancelButton1(CancellationTokenSource cts)
        {
            // Wait between 150 and 500 ms, then cancel.
            // Adjust these values if necessary to make
            // cancellation fire while query is still executing.
            Random rand = new();
            var ran = rand.Next(150,3000);
            Thread.Sleep(ran);
            cts.Cancel();
        }


        public static void MainancelAQuery_2()
        {
            int[] source = Enumerable.Range(1, 10000).ToArray();
            using CancellationTokenSource cts = new();

            // Start a new asynchronous task that will cancel the
            // operation from another thread. Typically you would call
            // Cancel() in response to a button click or some other
            // user interface event.
            Task.Factory.StartNew(() =>
            {
                UserClicksTheCancelButton(cts);
            });

            double[]? results = null;
            try
            {
                results =
                    (from num in source.AsParallel().WithCancellation(cts.Token)
                     where num % 3 == 0
                     select Function(num, cts.Token)).ToArray();
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (AggregateException ae)
            {
                if (ae.InnerExceptions != null)
                {
                    foreach (Exception e in ae.InnerExceptions)
                        Console.WriteLine(e.Message);
                }
            }

            foreach (var item in results ?? Array.Empty<double>())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        // A toy method to simulate work.
        public static double Function(int n, CancellationToken ct)
        {
            // If work is expected to take longer than 1 ms
            // then try to check cancellation status more
            // often within that work.
            for (int i = 0; i < 5; i++)
            {
                // Work hard for approx 1 millisecond.
                Thread.SpinWait(50000);

                ct.ThrowIfCancellationRequested();
            }
            // Anything will do for our purposes.
            return Math.Sqrt(n);
        }

        static void UserClicksTheCancelButton(CancellationTokenSource cts)
        {
            // Wait between 150 and 500 ms, then cancel.
            // Adjust these values if necessary to make
            // cancellation fire while query is still executing.
            Random rand = new();
            Thread.Sleep(rand.Next(150, 500));
            //Thread.Sleep(3000);
            //cts.Cancel();
            Console.WriteLine("Press 'c' to cancel");
            if (Console.ReadKey().KeyChar == 'c')
            {
                cts.Cancel();
            }
        }
    }
}
