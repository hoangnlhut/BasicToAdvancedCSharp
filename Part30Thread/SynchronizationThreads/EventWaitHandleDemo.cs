using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Part30Thread.SynchronizationThreads
{
    
    // Bài toán: có 1 hàng đợi chứa kiểu dữ liệu string có 2 thread
    // 1 thread từ chương trình chính đọc dữ liệu từ bàn phím vào hàng đợi
    //thread 2 : đợi có dữ liệu trong hàng đợi thì nó lấy ra in ra màn hình
    public static class EventWaitHandleDemo
    {
        public static BlockingQueue<string> _queue = new BlockingQueue<string>();
        public static void Run()
        {
            // cho thread này chạy trước nếu không thì 2 thread sẽ không chạy đồng thời
            Thread t = new Thread(DequeueThread) { IsBackground = true};
            t.Start();

            Thread t2 = new Thread(DequeueThread) { IsBackground = true };
            t2.Start();

            string? s = null;
            do
            {
                Console.Write("S: ");
                s = Console.ReadLine();

                if (!string.IsNullOrEmpty(s))
                {
                    _queue.EnQueue(s);
                }
            }
            while (!string.IsNullOrEmpty(s));
        }

        //Cách kém hiệu quả vì dùng một vòng lặp chạy mãi tiêu tốn CPU
        public static void DequeueThread()
        {
            //while (true)
            //{
            //    if (!_queue.IsOutOfQueue)
            //    {
            //        var s = _queue.DeQueue();
            //        Console.WriteLine($"Dequeue : {s}");
            //    }

            //    // để vòng lặp thế này cực kỳ kém hiệu quả vì thread sẽ chạy liên tục
            //    //Console.WriteLine("Running");
            //}
            while(true)
            {
                var s = _queue.DeQueue();
                Console.WriteLine($"Dequeue : {s}");
            }
        }
    }

}
