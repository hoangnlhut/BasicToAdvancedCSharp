using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Part32Semaphore.Basics
{

    //code from recommendation of Chat GPT
    //A semaphore is a synchronization mechanism in programming that helps control access to a shared resource by multiple threads, preventing issues like race conditions and ensuring orderly access.It essentially maintains a count of "permits" or "tokens" that represent the availability of the resource.

    //Types of Semaphores:
    //Counting Semaphore: Allows multiple threads to access a resource up to a specified count.
    //Binary Semaphore: Similar to a mutex, it allows only one thread to access a resource at a time (count = 1).
    //In.NET, you can use the Semaphore or SemaphoreSlim classes to implement semaphores.SemaphoreSlim is a lightweight version and is often used for in-process synchronization(within the same application).

    //Explanation:
    //SemaphoreSlim(2) : We initialize the semaphore with a count of 2, which means up to two threads can access the AccessResource method concurrently.
    //semaphore.Wait(): Each thread requests a "permit" to access the shared resource.
    //semaphore.Release(): Once a thread is done, it releases its permit, allowing other waiting threads to enter.

    //Why Use Semaphores?
    //In cases where a limited resource should not be accessed by more than a specific number of threads(like database connections), a semaphore provides a controlled way of granting access to prevent conflicts and improve performance.
    public class SemaphoreSimple
    {
        static SemaphoreSlim semaphore = new SemaphoreSlim(3); // Allow up to 2 threads

        public static void MainSimple()
        {
            for (int i = 1; i <= 5; i++)
            {
                int threadNum = i;
                Thread thread = new Thread(() => AccessResource(threadNum));
                thread.Start();
            }
        }

        static void AccessResource(int threadNum)
        {
            Console.WriteLine($"Thread {threadNum} is waiting to access the resource...");

            semaphore.Wait(); // Request permission to access the resource
            try
            {
                Console.WriteLine($"Thread {threadNum} has entered the resource.");
                Thread.Sleep(2000); // Simulate resource use
                Console.WriteLine($"Thread {threadNum} is leaving the resource.");
            }
            finally
            {
                semaphore.Release(); // Release the permission
            }
        }
    }
}
