namespace Part33_LockMonitor
{
    internal class Program
    {
        static int x = 10;
        static int y = 20;

        static object lockObject = new object();

        static void Main(string[] args)
        {
            Thread t = new Thread(ThreadPrint)
            {
                IsBackground = true
            };
            t.Start();

            Print();
            Swap();
            Print();
        }

        static void Swap()
        {
            lock (lockObject)
            {
                var t = x;
                Thread.Sleep(100);
                x = y;
                Thread.Sleep(200);
                y = t;
            }
        }

        static void Print()
        {
            lock(lockObject)
            {
                Console.WriteLine($"X: {x}  Y: {y}");
            }
        }


        static void ThreadPrint()
        {
            while(true)
            {
                Print();
            }
        }

    }
}
