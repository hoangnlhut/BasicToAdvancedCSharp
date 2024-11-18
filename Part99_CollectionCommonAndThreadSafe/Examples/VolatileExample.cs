using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part99_CollectionCommonAndThreadSafe.Examples
{
    public class VolatileExample
    {
        public static void MainVolatileExample()
        {
            // Create the worker thread object. This does not start the thread.
            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);

            // Start the worker thread.
            workerThread.Start();
            Console.WriteLine("Main thread: starting worker thread...");

            // Loop until the worker thread activates.
            while (!workerThread.IsAlive)
                ;

            // Put the main thread to sleep for 500 milliseconds to
            // allow the worker thread to do some work.
            Thread.Sleep(500);

            // Request that the worker thread stop itself.
            workerObject.RequestStop();

            // Use the Thread.Join method to block the current thread
            // until the object's thread terminates.
            workerThread.Join();
            Console.WriteLine("Main thread: worker thread has terminated.");
        }
    }

    public class Worker
    {
        // This method is called when the thread is started.
        public void DoWork()
        {
            bool work = false;
            while (!_shouldStop)
            {
                work = !work; // simulate some work
            }
            Console.WriteLine("Worker thread: terminating gracefully.");
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
        // Keyword volatile is used as a hint to the compiler that this data
        // member is accessed by multiple threads.
        private volatile bool _shouldStop;
    }
}
