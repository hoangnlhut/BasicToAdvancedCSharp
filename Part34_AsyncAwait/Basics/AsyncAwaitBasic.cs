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

            #region using Task.Run() to creat new task run parralle / concurrent with other task
            var tr = Task.Run(RunMethod);
            #endregion

            #region run as SYNCHRONOUS: dong bo
            //stopwatch.Start();
            //await Wait1();
            //await Wait2();
            //await Wait3();
            //stopwatch.Stop();
            #endregion


            #region run as ASYNCHRONOUS: BAT dong bo
            stopwatch.Start();
            var t1 = Wait1Async();
            var t2 = Wait2Async();
            var t3 = Wait3Async();

            //Cach 1: WaitAll giong WhenAll: tat ca 
            //cac task hoan thanh thi chay tiep
            //Task.WaitAll(t1, t2, t3);

            //Cach 2
            //await t1;
            //await t2;
            //await t3;

            //Cach 3
            var task123 = Task.WhenAll(t1, t2, t3, tr);
            await task123;

            //WaitAny tuong tu nhu WhenAny: 1 trong cac
            // task hoan thanh thi chay tiep

            stopwatch.Stop();
            #endregion


            

            Console.WriteLine($"Elapsed time..... : {stopwatch.Elapsed}");
        }

        public static async Task Wait1Async() 
        {
            Console.WriteLine("Wait1 running......");
            await Task.Delay(1000);
            Console.WriteLine("Wait1 done......");
        }

        public static async Task Wait2Async()
        {
            Console.WriteLine("Wait2 running......");
            await Task.Delay(2000);
            Console.WriteLine("Wait2 done......");
        }

        public static async Task Wait3Async()
        {
            Console.WriteLine("Wait3 running......");
            await Task.Delay(3000);
            Console.WriteLine("Wait3 done......");
        }


        // muon thang nay chay song song voi cac thanh khac
        // thi dung task.Run() de chay
        static void RunMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"i = {i}");
                Task.Delay(500).Wait();
            }
        }
    }
}
