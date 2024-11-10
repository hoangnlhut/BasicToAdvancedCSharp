using Part30Thread.CancelThread.ListenMultipleCancellationRequest;
using Part30Thread.DebuggingThread;
using Part30Thread.PrioritizationScheduleThread;
using Part30Thread.SynchronizationThreads;
using System.Drawing;
using System.Security.Principal;

namespace Part30Thread
{
    internal partial class Program
    {
        
        static void Main(string[] args)
        {
            #region basics
            ////cách 2: sử dụng biến để check
            //bool isFinished = false;

            //Thread t1 = new Thread(() =>
            //{
            //    while (!isFinished)
            //    {
            //        Console.WriteLine("Hello 1111!");
            //        Thread.Sleep(1000);
            //    }
            //});

            //Thread t2 = new Thread(() =>
            //{
            //    while (!isFinished)
            //    {
            //        Console.WriteLine("Hello 2222!");
            //        Thread.Sleep(3000);
            //    }
            //});

            ////Cách 1: không nên dùng vì bị phụ thuộc vào foreground 
            //// và background bị ép buộc dựng
            ////Background and Foreground ve co bản là giống nhau
            //// chỉ khác là nếu foreground mà kết thúc
            //// thì background thread sẽ kết thúc
            ////t1.IsBackground = true;
            ////t2.IsBackground = true;

            //t1.Start();
            //t2.Start();

            //Console.ReadLine();
            //isFinished = true;
            #endregion

            #region Tái sử dụng qua một hàm
            //CancellationTokenSource cts = new CancellationTokenSource();

            //var t1 = new Thread(new ParameterizedThreadStart(Print));
            //var t2 = new Thread(new ParameterizedThreadStart(Print));
            //var t3 = new Thread(new ParameterizedThreadStart(Print));

            //// hoặc có thể tạo lớp model để định nghĩa params
            ////t1.Start( new { Name = "hoang", Address = "1"});
            ////t2.Start(new { Name = "trang", Address = "2" });
            ////t3.Start(new { Name = "viet", Address = "3" }); 
            //t1.Start( new ThreadInputModel  { Name = "hoang", Address = "1", Cts = cts.Token});
            //t2.Start(new ThreadInputModel { Name = "trang", Address = "2", Cts = cts.Token });
            //t3.Start(null);

            //Console.ReadLine();
            ////cts.Cancel(); // cancel ngay sau lệnh nhập
            //cts.CancelAfter(10000); // cancel sau 10 giây sau lệnh nhập
            // Call Dispose when we're done with the CancellationTokenSource.
            //cts.Dispose();
            #endregion

            #region Đồng bộ dũ liệu giữa các thread
            #region using EventWaitHandle
            //EventWaitHandleDemo.Run();
            #endregion
            #endregion

            #region Scheduling threads with prioritization
            //SchedulingThreads sche = new SchedulingThreads();
            //sche.RunMultipleThreadsOnDifferentPriorities();
            #endregion

            #region Cancel Thread
            #region Listen for Cancellation Requests by Polling
            //var tokenSource = new CancellationTokenSource();
            //// Toy object for demo purposes
            //Rectangle rect = new Rectangle() { columns = 1000, rows = 500 };

            //// Simple cancellation scenario #1. Calling thread does not wait
            //// on the task to complete, and the user delegate simply returns
            //// on cancellation request without throwing.
            //Task.Run(() => NestedLoops(rect, tokenSource.Token), tokenSource.Token);

            //// Simple cancellation scenario #2. Calling thread does not wait
            //// on the task to complete, and the user delegate throws
            //// OperationCanceledException to shut down task and transition its state.
            //// Task.Run(() => PollByTimeSpan(tokenSource.Token), tokenSource.Token);

            //Console.WriteLine("Press 'c' to cancel");
            //if (Console.ReadKey(true).KeyChar == 'c')
            //{
            //    tokenSource.Cancel();
            //    Console.WriteLine("Press any key to exit.");
            //}

            //Console.ReadKey();
            //tokenSource.Dispose();
            #endregion

            #region Listen for multiple Cancellation Request
            //ListenMultipleCancellationRequest.Run();
            #endregion

            #endregion

            #region Debug a parallel application
            //1
            //DebugAParrallelApplication.MainDebug();

            //2 
            MyThreadWalkthroughApp.MainExample();   
            #endregion
        }

        public struct Rectangle
        {
            public int columns;
            public int rows;
        }

        static void NestedLoops(Rectangle rect, CancellationToken token)
        {
            for (int col = 0; col < rect.columns && !token.IsCancellationRequested; col++)
            {
                // Assume that we know that the inner loop is very fast.
                // Therefore, polling once per column in the outer loop condition
                // is sufficient.
                for (int row = 0; row < rect.rows; row++)
                {
                    // Simulating work.
                    Thread.SpinWait(5_000);
                    Console.Write("{0},{1} ", col, row);
                }
                Thread.Sleep(1000);
            }

            if (token.IsCancellationRequested)
            {
                // Cleanup or undo here if necessary...
                Console.WriteLine("\r\nOperation canceled");
                Console.WriteLine("Press any key to exit.");

                // If using Task:
                // token.ThrowIfCancellationRequested();
            }
        }

        public static void Print(object? p)
        {
            var newP= p is ThreadInputModel; // trả về bool
            var newP2 = p as ThreadInputModel; // trả về object? 

            Thread currentThread = Thread.CurrentThread;
            // có 2 cách ép kiểu
            // Cách 1 : (model)p => nếu p ko phải kiểu model muốn ép nó sẽ bắn ra exception
            // Cách 2: p as model => nó sẽ kiểm tra xem có phải kiểu ép ko nếu không phải sẽ trả về null

            if (newP2 is not null)
            {
                while (!newP2.Cts.IsCancellationRequested)
                {
                    Console.WriteLine($"Hello {newP2.Name} in Address : {newP2.Address}! with Id: {currentThread.ManagedThreadId} with Name : {currentThread.Name}");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
