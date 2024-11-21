using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part34_AsyncAwait.Basics
{
    public class AsycnAwaitUnderThehood
    {
        public static async Task MainUnderTheHood()
        {
            Console.WriteLine($"MainUnderTheHood - 1 - Thread ID = {Environment.CurrentManagedThreadId}");

            Task t = Task.Run(AsyncFunc1);
            await AsyncFunc2();

            Console.WriteLine($"MainUnderTheHood - 2 - Thread ID = {Environment.CurrentManagedThreadId}");

            t.Wait();
        }

        private static int AsyncFunc1()
        {
            Console.WriteLine($"AsyncFunc1 - Thread ID = {Environment.CurrentManagedThreadId}");

            return 0;
        }

        private static async Task<int> AsyncFunc2()
        {
            Console.WriteLine($"AsyncFunc2 - 1 - Thread ID = {Environment.CurrentManagedThreadId}");

            var r = (await ReadAllText()).Length;

            Console.WriteLine($"AsyncFunc2 - 2 - Thread ID = {Environment.CurrentManagedThreadId}");

            return r;
        }

        private static async Task<string> ReadAllText()
        {
            Console.WriteLine($"ReadAllText - 1 - Thread ID = {Environment.CurrentManagedThreadId}");

            await Task.Delay(1000);

            Console.WriteLine($"ReadAllText - 2 - Thread ID = {Environment.CurrentManagedThreadId}");

            return  "Content";
        }
    }
}
