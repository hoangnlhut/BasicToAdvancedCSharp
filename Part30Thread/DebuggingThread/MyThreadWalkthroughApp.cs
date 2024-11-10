using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part30Thread.DebuggingThread
{
    public class MyThreadWalkthroughApp
    {
        public static void MainExample()
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    CreateThreads();
            //}

            CreateThreads();
        }
        public static void CreateThreads()
        {
            ServerClass serverObject = new ServerClass();

            var list = new List<Thread>()
            {
                new Thread(new ThreadStart(serverObject.InstanceMethod)),
                new Thread(new ThreadStart(serverObject.InstanceMethod)),
                new Thread(new ThreadStart(serverObject.InstanceMethod)),
                new Thread(new ThreadStart(serverObject.InstanceMethod)),
                new Thread(new ThreadStart(serverObject.InstanceMethod)),
                new Thread(new ThreadStart(serverObject.InstanceMethod)),
                new Thread(new ThreadStart(serverObject.InstanceMethod)),
                new Thread(new ThreadStart(serverObject.InstanceMethod)),
                new Thread(new ThreadStart(serverObject.InstanceMethod)),
                new Thread(new ThreadStart(serverObject.InstanceMethod))
            };


            // Start the thread.
            list.ForEach(x => x.Start());
            //list.ForEach(x => x.Join());

            Console.WriteLine("The Main() thread calls this after "
                + "starting the new InstanceCaller thread.");

        }
    }
    public class ServerClass
    {
        private static object _obj = new object();
        static int count = 0;
        // The method that will be called when the thread is started.
        public void InstanceMethod()
        {
            Console.WriteLine(
                "ServerClass.InstanceMethod is running on another thread.");
            int data = 0;
            lock (_obj)
            {
                data = count++;
            }
            // Pause for a moment to provide a delay to make 
            // threads more apparent.
            Thread.Sleep(3000);
            Console.WriteLine(
                "The instance method called by the worker thread has ended. " + data);
        }
    }
}
