using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part32Semaphore.Basics
{
    // Link Reference: https://learn.microsoft.com/en-us/dotnet/api/system.threading.semaphore.-ctor?view=net-8.0

    #region How to use : Semaphore(Int32, Int32)
    public class SemaphoreExample2
    {
        // A semaphore that simulates a limited resource pool.
        //
        private static Semaphore _pool;

        // A padding interval to make the output more orderly.
        private static int _padding;

        public static void MainSemaphore()
        {
            // Create a semaphore that can satisfy up to three
            // concurrent requests. Use an initial count of zero,
            // so that the entire semaphore count is initially
            // owned by the main program thread.
            //
            _pool = new Semaphore(initialCount: 3, maximumCount: 3);

            // Create and start five numbered threads. 
            //
            for (int i = 1; i <= 5; i++)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Worker));

                // Start the thread, passing the number.
                //
                t.Start(i);
            }

            // Wait for half a second, to allow all the
            // threads to start and to block on the semaphore.
            //
            Thread.Sleep(500);

            // The main thread starts out holding the entire
            // semaphore count. Calling Release(3) brings the 
            // semaphore count back to its maximum value, and
            // allows the waiting threads to enter the semaphore,
            // up to three at a time.
            //
            Console.WriteLine("Main thread calls Release(3).");
            _pool.Release(releaseCount: 3);

            Console.WriteLine("Main thread exits.");
        }

        private static void Worker(object num)
        {
            // Each worker thread begins by requesting the
            // semaphore.
            Console.WriteLine("Thread {0} begins " +
                "and waits for the semaphore.", num);
            _pool.WaitOne();

            // A padding interval to make the output more orderly.
            int padding = Interlocked.Add(ref _padding, 100);


            Console.WriteLine("Thread {0} enters the semaphore.", num);

            // The thread's "work" consists of sleeping for 
            // about a second. Each thread "works" a little 
            // longer, just to make the output more orderly.
            //
            Thread.Sleep(1000 + padding);

            Console.WriteLine("Thread {0} releases the semaphore.", num);
            Console.WriteLine("Thread {0} previous semaphore count: {1}",
                num, _pool.Release());
        }
    }
    #endregion


    #region How to use  Semaphore(Int32, Int32, string? name)
    public class SemaphoreExample3
    {
        public static void MainExample3()
        {
            // Create a Semaphore object that represents the named 
            // system semaphore "SemaphoreExample3". The semaphore has a
            // maximum count of five. The initial count is also five. 
            // There is no point in using a smaller initial count,
            // because the initial count is not used if this program
            // doesn't create the named system semaphore, and with 
            // this method overload there is no way to tell. Thus, this
            // program assumes that it is competing with other
            // programs for the semaphore.
            //
            Semaphore sem = new Semaphore(5, 5, "SemaphoreExample3");

            // Attempt to enter the semaphore three times. If another 
            // copy of this program is already running, only the first
            // two requests can be satisfied. The third blocks. Note 
            // that in a real application, timeouts should be used
            // on the WaitOne calls, to avoid deadlocks.
            //
            sem.WaitOne();
            Console.WriteLine("Entered the semaphore once.");
            sem.WaitOne();
            Console.WriteLine("Entered the semaphore twice.");
            sem.WaitOne();
            Console.WriteLine("Entered the semaphore three times.");

            // The thread executing this program has entered the 
            // semaphore three times. If a second copy of the program
            // is run, it will block until this program releases the 
            // semaphore at least once.
            //
            Console.WriteLine("Enter the number of times to call Release.");
            int n;
            if (int.TryParse(Console.ReadLine(), out n))
            {
                sem.Release(n);
            }

            int remaining = 3 - n;
            if (remaining > 0)
            {
                Console.WriteLine("Press Enter to release the remaining " +
                    "count ({0}) and exit the program.", remaining);
                Console.ReadLine();
                sem.Release(remaining);
            }
        }
    }
    #endregion

    #region How to use  Semaphore(Int32, Int32, String, Boolean)
    public class SemaphoreExample4
    {
        public static void MainExample4()
        {
            // The value of this variable is set by the semaphore
            // constructor. It is true if the named system semaphore was
            // created, and false if the named semaphore already existed.
            //
            bool semaphoreWasCreated;

            // Create a Semaphore object that represents the named 
            // system semaphore "SemaphoreExample". The semaphore has a
            // maximum count of five, and an initial count of two. The
            // Boolean value that indicates creation of the underlying 
            // system object is placed in semaphoreWasCreated.
            //
            Semaphore sem = new Semaphore(2, 5, "SemaphoreExample",
                out semaphoreWasCreated);

            if (semaphoreWasCreated)
            {
                // If the named system semaphore was created, its count is
                // set to the initial count requested in the constructor.
                // In effect, the current thread has entered the semaphore
                // three times.
                // 
                Console.WriteLine("Entered the semaphore three times.");
            }
            else
            {
                // If the named system semaphore was not created,  
                // attempt to enter it three times. If another copy of
                // this program is already running, only the first two
                // requests can be satisfied. The third blocks.
                //
                sem.WaitOne();
                Console.WriteLine("Entered the semaphore once.");
                sem.WaitOne();
                Console.WriteLine("Entered the semaphore twice.");
                sem.WaitOne();
                Console.WriteLine("Entered the semaphore three times.");
            }

            // The thread executing this program has entered the 
            // semaphore three times. If a second copy of the program
            // is run, it will block until this program releases the 
            // semaphore at least once.
            //
            Console.WriteLine("Enter the number of times to call Release.");
            int n;
            if (int.TryParse(Console.ReadLine(), out n))
            {
                sem.Release(n);
            }

            int remaining = 3 - n;
            if (remaining > 0)
            {
                Console.WriteLine("Press Enter to release the remaining " +
                    "count ({0}) and exit the program.", remaining);
                Console.ReadLine();
                sem.Release(remaining);
            }
        }
    }
    #endregion
}
