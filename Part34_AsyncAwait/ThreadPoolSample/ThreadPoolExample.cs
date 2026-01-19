using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part34_AsyncAwait.ThreadPoolSample
{
    public class ThreadPoolExample
    {
        public static void MainThreadPoolExample() { 
            for (int i = 1; i <= 100; i++)
            {
                int capturedId = i;
                //Thread.Sleep(2000);
                ThreadPoolExample.QueueUserWorkItem(() =>
                {
                    Thread.Sleep(5000);
                    Console.WriteLine($"{capturedId} (thread #{Environment.CurrentManagedThreadId})");
                });
            }

            Console.ReadLine();

        }
        private static ulong currentId = 0;

        // this is command queue(hang doi lenh) 
        // each time we take item in blockingCollection
        // if the collection is empty, it will block until it can continue to have item to get .
        private static readonly BlockingCollection<(ulong, Action, ExecutionContext?)> actions = [];

        public static void QueueUserWorkItem(Action action) => actions.Add((Interlocked.Increment(ref currentId), action, ExecutionContext.Capture()));

        static ThreadPoolExample()
        {
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                var t = new Thread(() =>
                {
                    Console.WriteLine($"Thread #{Environment.CurrentManagedThreadId} started! ");
                    while (true)
                    {
                        (ulong id, Action action, ExecutionContext? context) = actions.Take();

                        Console.WriteLine($"Thread #{Environment.CurrentManagedThreadId} executes task #{id}");

                        if (context is null)
                        {
                            action();
                        }
                        else
                        {
                            ExecutionContext.Run(context, state => ((Action)state!).Invoke(),action);
                        }
                    }
                })
                {
                    IsBackground = true
                };
                t.Start();
            }
        }
    }
}
