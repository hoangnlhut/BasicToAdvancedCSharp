
namespace Part32Semaphore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Non using Semaphore......");
            //NonUsingSemaphore();

            Console.WriteLine("Using Semaphore......");
            UsingSemaphore();
        }

        #region USING Semaphore
        private static Random r = new();
        private static int ItemsBox = 0;
        private const int MAX = 10;

        private static Semaphore semaphore = new Semaphore(MAX, MAX);
        private static AutoResetEvent fullEvent = new AutoResetEvent(false);

        public static void UsingSemaphore()
        {
            for (int i = 1; i <= 8; i++)
            {
                var t = new Thread(new ParameterizedThreadStart(MoveItemThread))
                {
                    IsBackground = true

                };
                t.Start(i.ToString());
            }


            var t10 = new Thread(ReplaceBox) { IsBackground = true };
            t10.Start();

            Console.ReadLine();
        }

        private static void MoveItemThread(object? obj)
        {
            var armNumber = obj?.ToString() ?? "-";

            while (true)
            {
                semaphore.WaitOne();
                MoveItem(armNumber);
            }
        }

        private static void MoveItem(string? armNumber)
        {
            Console.WriteLine($"{armNumber} - Moving Item.....");
            Thread.Sleep(r.Next(100, 400));

            ItemsBox++;
            Console.WriteLine($"Current ItemBox :{ItemsBox}");
            if (ItemsBox == MAX)
            {
                fullEvent.Set();
            }

            Thread.Sleep(r.Next(1000, 2000));

            Console.WriteLine($"{armNumber} - Moving DONEEEEEEE.....");
        }

        private static void ReplaceBox()
        {
           while(true)
            {
                if (ItemsBox == MAX)
                {
                    fullEvent.WaitOne();
                    Console.WriteLine("Replace with a new box");

                    ItemsBox = 0;
                    semaphore.Release(MAX);
                }
            }
        }
        #endregion

        #region non-using Semaphore
        //private static Random r = new();
        //private static int ItemsBox = 0;
        //private const int MAX = 10;

        //public static void NonUsingSemaphore()
        //{
        //    for (int i = 1; i <= 8; i++)
        //    {
        //        var t = new Thread(new ParameterizedThreadStart(MoveItemThread))
        //        {
        //            IsBackground = true

        //        };
        //        t.Start(i.ToString());
        //    }

        //    Console.ReadLine();
        //}

        //private static void MoveItemThread(object? obj)
        //{
        //    var armNumber = obj?.ToString() ?? "-";

        //    while (true)
        //    {
        //        if (ItemsBox < MAX)
        //        {
        //            Console.WriteLine($"{armNumber} - Moving Item.....");
        //            Thread.Sleep(r.Next(100, 400));

        //            MoveItem();

        //            Thread.Sleep(r.Next(1000, 2000));

        //            Console.WriteLine($"{armNumber} - Moving DONEEEEEEE.....");
        //        }
        //    }
        //}

        //private static void MoveItem()
        //{
        //    ItemsBox++;
        //    Console.WriteLine($"Current ItemBox :{ItemsBox}");
        //}
        #endregion
    }
}
