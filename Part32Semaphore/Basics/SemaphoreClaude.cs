using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Part32Semaphore.Basics
{
//Let me break down how this example works:

//We create a SemaphoreSlim with initial count of 3, meaning only 3 threads can access the critical section simultaneously
//We spawn 6 tasks that try to access a shared resource
//Each task must:

//Wait to acquire a permit using WaitAsync()
//Do its work(simulated with delay)
//Release the permit using Release()



//When you run this code, you'll see that:

//Only 3 tasks can execute simultaneously
//The other 3 tasks will wait until a permit becomes available
//Output will show tasks entering and leaving in groups of 3

//Key points about semaphores:

//Unlike locks, semaphores allow multiple threads (up to the count) to access the resource
//They're great for resource pools or rate limiting
//SemaphoreSlim is the modern, lightweight version recommended for most scenarios
//Always release the semaphore in a finally block to prevent deadlocks
    public class SemaphoreClaude
    {
        // Creating a semaphore with 3 initial permits and maximum 3 permits
        private static SemaphoreSlim _semaphore = new SemaphoreSlim(2, 2);

        public static async Task MainClaude()
        {
            // Create multiple tasks trying to access the shared resource
            var tasks = new List<Task>();

            for (int i = 1; i <= 6; i++)
            {
                int taskId = i;
                tasks.Add(Task.Run(() => ProcessRequest(taskId)));
            }

            await Task.WhenAll(tasks);
        }

        private static async Task ProcessRequest(int taskId)
        {
            Console.WriteLine($"Task {taskId} is waiting to enter the critical section...");

            try
            {
                // Try to enter the critical section
                await _semaphore.WaitAsync();

                Console.WriteLine($"Task {taskId} has entered the critical section");

                // Simulate some work
                await Task.Delay(2000);

                Console.WriteLine($"Task {taskId} is leaving the critical section");
            }
            finally
            {
                // Release the semaphore
                _semaphore.Release();
            }
        }
    }
}
