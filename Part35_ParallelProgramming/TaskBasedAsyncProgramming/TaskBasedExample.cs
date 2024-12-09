using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part35_ParallelProgramming.TaskBasedAsyncProgramming
{
    public class TaskBasedExample
    {
        public static void MainTestTaskFactoryWithObjectInConstruction()
        {
            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) =>
                {
                    CustomData data = obj as CustomData;
                    if (data == null)
                        return;

                    data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                    Console.WriteLine("Task #{0} created at {1} on thread #{2}.",
                                     data.Name, data.CreationTime, data.ThreadNum);
                }, new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks });
            }
            Task.WaitAll(taskArray);
        }

        public static void MainThreadWithCulture()
        {

            decimal[] values = { 163025412.32m, 18905365.59m };
            string formatString = "C2";
            Func<String> formatDelegate = () =>
            {
                string output = String.Format("Formatting using the {0} culture on thread {1}.\n",
                                                                                CultureInfo.CurrentCulture.Name,
                                                                                Thread.CurrentThread.ManagedThreadId);
                foreach (var value in values)
                    output += String.Format("{0}   ", value.ToString(formatString));

                output += Environment.NewLine;
                return output;
            };

            Console.WriteLine("The example is running on thread {0}",
                              Thread.CurrentThread.ManagedThreadId);
            // Make the current culture different from the system culture.
            Console.WriteLine("The current culture is {0}",
                              CultureInfo.CurrentCulture.Name);
            if (CultureInfo.CurrentCulture.Name == "fr-FR")
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            else
                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

            Console.WriteLine("Changed the current culture to {0}.\n",
                              CultureInfo.CurrentCulture.Name);

            // Execute the delegate synchronously.
            Console.WriteLine("Executing the delegate synchronously:");
            Console.WriteLine(formatDelegate());

            // Call an async delegate to format the values using one format string.
            Console.WriteLine("Executing a task asynchronously:");
            var t1 = Task.Run(formatDelegate);
            Console.WriteLine(t1.Result);

            Console.WriteLine("Executing a task synchronously:");
            var t2 = new Task<String>(formatDelegate);
            t2.RunSynchronously();
            Console.WriteLine(t2.Result);
        }

        public static void MainContinueWithInTask()
        {
            var displayData = Task.Factory.StartNew(() =>
            {
                Random rnd = new Random();
                int[] values = new int[100];
                var upperBound = values.GetUpperBound(0);

                for (int ctr = 0; ctr <= upperBound; ctr++)
                    values[ctr] = rnd.Next();

                return values;
            }).
            ContinueWith((x) =>
            {
                int n = x.Result.Length;
                long sum = 0;
                double mean;

                for (int ctr = 0; ctr <= x.Result.GetUpperBound(0); ctr++)
                    sum += x.Result[ctr];

                mean = sum / (double)n;
                return Tuple.Create(n, sum, mean);
            }).
            ContinueWith((x) =>
            {
                return String.Format("N={0:N0}, Total = {1:N0}, Mean = {2:N2}",
                                      x.Result.Item1, x.Result.Item2,
                                      x.Result.Item3);
            });
            Console.WriteLine(displayData.Result);
        }

        #region Cancellation With ContinueWith()
        public async static Task MainCancellationWithContinueWith()
        {
            using var cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            var timer = new Timer(Elapsed, cts, 5000, Timeout.Infinite);

            var task = Task.Run(
                async () =>
                {
                    var product33 = new List<int>();
                    for (int index = 1; index < short.MaxValue; index++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            Console.WriteLine("\nCancellation requested in antecedent...\n");
                            token.ThrowIfCancellationRequested();
                        }
                        if (index % 2000 == 0)
                        {
                            int delay = s_random.Next(16, 501);
                            await Task.Delay(delay);
                        }
                        if (index % 33 == 0)
                        {
                            product33.Add(index);
                        }
                    }

                    return product33.ToArray();
                }, token);

            Task<double> continuation = task.ContinueWith(
                async antecedent =>
                {
                    Console.WriteLine("Multiples of 33:\n");
                    int[] array = antecedent.Result;
                    for (int index = 0; index < array.Length; index++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            Console.WriteLine("\nCancellation requested in continuation...\n");
                            token.ThrowIfCancellationRequested();
                        }
                        if (index % 100 == 0)
                        {
                            int delay = s_random.Next(16, 251);
                            await Task.Delay(delay);
                        }

                        Console.Write($"{array[index]:N0}{(index != array.Length - 1 ? ", " : "")}");

                        if (Console.CursorLeft >= 74)
                        {
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                    return array.Average();
                }, token).Unwrap();

            try
            {
                await task;
                double result = await continuation;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nAntecedent Status: {0}", task.Status);
            Console.WriteLine("Continuation Status: {0}", continuation.Status);
        }

        static void Elapsed(object? state)
        {
            if (state is CancellationTokenSource cts)
            {
                cts.Cancel();
                Console.WriteLine("\nCancellation request issued...\n");
            }
        }

        public static readonly Random s_random = new Random((int)DateTime.Now.Ticks);
        #endregion

        #region Cancel a Task and It's Child
        public static async Task MainCanCelATaskAndItChild()
        {
            // Cancellation token source for cancellation. Make sure to dispose after use (which is done here through the using expression).
            using var tokenSource = new CancellationTokenSource();

            // The cancellation token will be used to communicate cancellation to tasks
            var token = tokenSource.Token;

            Console.WriteLine("Main: Press any key to begin tasks...");
            Console.ReadKey(true);
            Console.WriteLine("Main: To terminate the example, press 'c' to cancel and exit...");
            Console.WriteLine();

            // Store references to the tasks so that we can wait on them and
            // observe their status after cancellation.
            var tasks = new ConcurrentBag<Task>();

            // Pass the token to the user delegate so it can cancel during execution,
            // and also to the task so it can cancel before execution starts.
            var cancellableTask = Task.Run(() =>
            {
                DoSomeWork(token);
                Console.WriteLine("Cancellable: Task {0} ran to completion", Task.CurrentId);
            }, token);
            Console.WriteLine("Main: Cancellable Task {0} created", cancellableTask.Id);
            tasks.Add(cancellableTask);

            var parentTask = Task.Run(() =>
            {
                for (int i = 0; i <= 7; i++)
                {
                    // If cancellation was requested we don't need to start any more
                    // child tasks (that would immediately cancel) => break out of loop
                    if (token.IsCancellationRequested) break;

                    // For each child task, pass the same token
                    // to each user delegate and to Task.Run.
                    var childTask = Task.Run(() =>
                    {
                        DoSomeWork(token);
                        Console.WriteLine("Child: Task {0} ran to completion", Task.CurrentId);
                    }, token);
                    Console.WriteLine("Parent: Task {0} created", childTask.Id);
                    tasks.Add(childTask);

                    DoSomeWork(token, maxIterations: 1);
                }

                Console.WriteLine("Parent: Task {0} ran to completion", Task.CurrentId);
            }, token);
            Console.WriteLine("Main: Parent Task {0} created", parentTask.Id);
            tasks.Add(parentTask);

            // Request cancellation from the UI thread.
            char ch = Console.ReadKey().KeyChar;
            if (ch == 'c' || ch == 'C')
            {
                tokenSource.Cancel();
                Console.WriteLine("\nMain: Task cancellation requested.");

                // Optional: Observe the change in the Status property on the task.
                // It is not necessary to wait on tasks that have canceled. However,
                // if you do wait, you must enclose the call in a try-catch block to
                // catch the OperationCanceledExceptions that are thrown. If you do
                // not wait, no exception is thrown if the token that was passed to the
                // Task.Run method is the same token that requested the cancellation.
            }

            try
            {
                // Wait for all tasks before disposing the cancellation token source
                await Task.WhenAll(tasks);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"\nMain: {nameof(OperationCanceledException)} thrown\n");
            }

            // Display status of all tasks.
            foreach (var task in tasks)
            {
                Console.WriteLine("Main: Task {0} status is now {1}", task.Id, task.Status);
            }
        }

        static void DoSomeWork(CancellationToken ct, int maxIterations = 10)
        {
            // Was cancellation already requested?
            if (ct.IsCancellationRequested)
            {
                Console.WriteLine("Task {0} was cancelled before it got started.", Task.CurrentId);
                ct.ThrowIfCancellationRequested();
            }

            // NOTE!!! A "TaskCanceledException was unhandled
            // by user code" error will be raised here if "Just My Code"
            // is enabled on your computer. On Express editions JMC is
            // enabled and cannot be disabled. The exception is benign.
            // Just press F5 to continue executing your code.
            for (int i = 0; i <= maxIterations; i++)
            {
                // Do a bit of work. Not too much.
                var sw = new SpinWait();
                for (int j = 0; j <= 100; j++)
                    sw.SpinOnce();

                if (ct.IsCancellationRequested)
                {
                    Console.WriteLine("Task {0} work cancelled", Task.CurrentId);
                    ct.ThrowIfCancellationRequested();
                }
            }
        }
        #endregion

        #region Unwrap a nested data
        public static void MainUnwrapANestedData()
        {
            // An arbitrary threshold value.
            byte threshold = 0x40;

            // data is a Task<byte[]>
            var data = Task<byte[]>.Factory.StartNew(() =>
            {
                return GetData();
            });

            // We want to return a task so that we can
            // continue from it later in the program.
            // Without Unwrap: stepTwo is a Task<Task<byte[]>>
            // With Unwrap: stepTwo is a Task<byte[]>
            var stepTwo = data.ContinueWith((antecedent) =>
            {
                return Task<byte>.Factory.StartNew(() => Compute(antecedent.Result));
            })
                .Unwrap();

            // Without Unwrap: antecedent.Result = Task<byte>
            // and the following method will not compile.
            // With Unwrap: antecedent.Result = byte and
            // we can work directly with the result of the Compute method.
            var lastStep = stepTwo.ContinueWith((antecedent) =>
            {
                if (antecedent.Result >= threshold)
                {
                    return Task.Factory.StartNew(() => Console.WriteLine("Program complete. Final = 0x{0:x} threshold = 0x{1:x}", stepTwo.Result, threshold));
                }
                else
                {
                    return DoSomeOtherAsynchronousWork(stepTwo.Result, threshold);
                }
            });

            lastStep.Wait();
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        #region Dummy_Methods
        private static byte[] GetData()
        {
            Random rand = new Random();
            byte[] bytes = new byte[64];
            rand.NextBytes(bytes);
            return bytes;
        }

        static Task DoSomeOtherAsynchronousWork(int i, byte b2)
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.SpinWait(500000);
                Console.WriteLine("Doing more work. Value was <= threshold");
            });
        }
        static byte Compute(byte[] data)
        {

            byte final = 0;
            foreach (byte item in data)
            {
                final ^= item;
                Console.WriteLine("{0:x}", final);
            }
            Console.WriteLine("Done computing");
            return final;
        }
        #endregion
        #endregion

        #region Prevent a child task from attaching to its parent
        public static void MainPreventChildTaskToAttachToParent(string[] args)
        {
            Contoso.Widget w = new Contoso.Widget();

            // Perform the same operation two times. The first time, the operation
            // is performed by using the default task creation options. The second
            // time, the operation is performed by using the DenyChildAttach option
            // in the parent task.

            Console.WriteLine("Demonstrating parent/child tasks with default options...");
            DenyChildAttach.RunWidget(w, TaskCreationOptions.None);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Demonstrating parent/child tasks with the DenyChildAttach option...");
            DenyChildAttach.RunWidget(w, TaskCreationOptions.DenyChildAttach);
        }



        // Demonstrates how to prevent a child task from attaching to the parent.
        public class DenyChildAttach
        {
            public static void RunWidget(Contoso.Widget widget,
               TaskCreationOptions parentTaskOptions)
            {
                // Record the time required to run the parent
                // and child tasks.
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                Console.WriteLine("Starting widget as a background task...");

                // Run the widget task in the background.
                Task<Task> runWidget = Task.Factory.StartNew(() =>
                {
                    Task widgetTask = widget.Run();

                    // Perform other work while the task runs...
                    Thread.Sleep(1000);

                    return widgetTask;
                }, parentTaskOptions);

                // Wait for the parent task to finish.
                Console.WriteLine("Waiting for parent task to finish...");
                runWidget.Wait();
                Console.WriteLine("Parent task has finished. Elapsed time is {0} ms.",
                   stopwatch.ElapsedMilliseconds);

                // Perform more work...
                Console.WriteLine("Performing more work on the main thread...");
                Thread.Sleep(2000);
                Console.WriteLine("Elapsed time is {0} ms.", stopwatch.ElapsedMilliseconds);

                // Wait for the child task to finish.
                Console.WriteLine("Waiting for child task to finish...");
                runWidget.Result.Wait();
                Console.WriteLine("Child task has finished. Elapsed time is {0} ms.",
                  stopwatch.ElapsedMilliseconds);
            }
            #endregion
        }

        class CustomData
        {
            public long CreationTime;
            public int Name;
            public int ThreadNum;
        }
    }
}

namespace Contoso
{
    public class Widget
    {
        public Task Run()
        {
            // Create a long-running task that is attached to the
            // parent in the task hierarchy.
            return Task.Factory.StartNew(() =>
            {
                // Simulate a lengthy operation.
                Thread.Sleep(5000);
            }, TaskCreationOptions.AttachedToParent);
        }
    }
}
