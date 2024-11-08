using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part30Thread.PrioritizationScheduleThread
{
    public class SchedulingThreads
    {
        #region examples from https://learn.microsoft.com/en-us/dotnet/standard/threading/scheduling-threads
        //public void RunMultipleThreadsOnDifferentPriorities()
        //{
        //    var threadsList = new List<Thread>(9);

        //    // Initialize 9 threads. 5 with Highest priority, and the first 4 from Lowest to Normal range.
        //    for (int i = 0; i < 9; i++)
        //    {
        //        var thread = new Thread(() => { new ThreadWithCallback(Callback).Process(); });

        //        if (i > 3)
        //            thread.Priority = ThreadPriority.Highest;
        //        else
        //            thread.Priority = (ThreadPriority)i;

        //        threadsList.Add(thread);
        //    }

        //    threadsList.ForEach(thread => thread.Start());
        //}

        //public void Callback(ThreadPriority threadPriority)
        //{
        //    Console.WriteLine($"Callback in {threadPriority} priority. \t\t ThreadId: {Thread.CurrentThread.ManagedThreadId}.");
        //}

        //public class ThreadWithCallback
        //{
        //    public ThreadWithCallback(Action<ThreadPriority> callback)
        //    {
        //        this.callback = callback;
        //    }

        //    public Action<ThreadPriority> callback;

        //    public void Process()
        //    {
        //        Console.WriteLine($"Entered process in {Thread.CurrentThread.Priority} priority.  \t\t ThreadId: {Thread.CurrentThread.ManagedThreadId}.");
        //        Thread.Sleep(1000);
        //        Console.WriteLine($"Finished process in {Thread.CurrentThread.Priority} priority. \t\t ThreadId: {Thread.CurrentThread.ManagedThreadId}.");

        //        if (callback != null)
        //        {
        //            callback(Thread.CurrentThread.Priority);
        //        }
        //    }
        //}
        #endregion

        #region Examples from chatGPT
        public void RunMultipleThreadsOnDifferentPriorities()
        {
            // Create threads
            Thread lowPriorityThread = new Thread(PrintNumbers) { Name = "LowPriority" };
            Thread normalPriorityThread = new Thread(PrintNumbers) { Name = "NormalPriority" };
            Thread highPriorityThread = new Thread(PrintNumbers) { Name = "HighPriority" };

            // Set thread priorities
            lowPriorityThread.Priority = ThreadPriority.Lowest;
            normalPriorityThread.Priority = ThreadPriority.Normal;
            highPriorityThread.Priority = ThreadPriority.Highest;

            // Start threads
            lowPriorityThread.Start();
            normalPriorityThread.Start();
            highPriorityThread.Start();

            // Wait for all threads to complete
            lowPriorityThread.Join();
            normalPriorityThread.Join();
            highPriorityThread.Join();

            Console.WriteLine("All threads completed.");
        }

        private void PrintNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
                // Simulate work with a small delay
                Thread.Sleep(10); // 10ms sleep to visualize thread switching
            }
        }
        #endregion

    }
}
