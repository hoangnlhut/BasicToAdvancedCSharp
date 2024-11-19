using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part34_AsyncAwait.Basics
{
    public class AsyncAwaitBasic
    {
        public static async Task MainAsyncAwaitBaic()
        {
            Stopwatch stopwatch = new Stopwatch();

            #region run as SYNCHRONOUS: dong bo
            stopwatch.Start();
            await Wait1();
            await Wait2();
            await Wait3();
            stopwatch.Stop();
            #endregion

            Console.WriteLine($"Elapsed time..... : {stopwatch.ElapsedMilliseconds}");
        }

        public static async Task Wait1() 
        {
            Console.WriteLine("Wait1 running......");
            await Task.Delay(1000);
            Console.WriteLine("Wait1 done......");
        }

        public static async Task Wait2()
        {
            Console.WriteLine("Wait2 running......");
            await Task.Delay(2000);
            Console.WriteLine("Wait2 done......");
        }

        public static async Task Wait3()
        {
            Console.WriteLine("Wait3 running......");
            await Task.Delay(3000);
            Console.WriteLine("Wait3 done......");
        }

    }
}
