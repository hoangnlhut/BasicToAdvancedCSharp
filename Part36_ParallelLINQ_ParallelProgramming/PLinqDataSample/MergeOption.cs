using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part36_ParallelLINQ_ParallelProgramming.PLinqDataSample
{
    public class MergeOption
    {
        public static void MainMergeOptionNotBuffer()
        {
            Console.WriteLine("Starting Not Buffer");
            var nums = Enumerable.Range(1, 1000);

            // Replace NotBuffered with AutoBuffered
            // or FullyBuffered to compare behavior.
            var scanLines = from n in nums.AsParallel()
                                .WithMergeOptions(ParallelMergeOptions.NotBuffered)
                            where n % 2 == 0
                            select ExpensiveFunc(n);

            Stopwatch sw = Stopwatch.StartNew();
            foreach (var line in scanLines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("Elapsed time: {0} ms. Press any key to exit.",
                            sw.ElapsedMilliseconds);
            Console.WriteLine("Finishing Not Buffer");
            Console.WriteLine();
            Console.WriteLine();
            //Console.ReadKey();
        }

        public static void MainMergeOptionAutoBuffer()
        {
            Console.WriteLine("Starting Auto Buffer");
            var nums = Enumerable.Range(1, 1000);

            // Replace NotBuffered with AutoBuffered
            // or FullyBuffered to compare behavior.
            var scanLines = from n in nums.AsParallel()
                                .WithMergeOptions(ParallelMergeOptions.AutoBuffered)
                            where n % 2 == 0
                            select ExpensiveFunc(n);

            Stopwatch sw = Stopwatch.StartNew();
            foreach (var line in scanLines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("Elapsed time: {0} ms. Press any key to exit.",
                            sw.ElapsedMilliseconds);
            Console.WriteLine("Finishing Auto Buffer");
            Console.WriteLine();
            Console.WriteLine();
            //Console.ReadKey();
        }

        public static void MainMergeOptionFullyBuffer()
        {
            Console.WriteLine("Starting Fully Buffer");
            var nums = Enumerable.Range(1, 1000);

            // Replace NotBuffered with AutoBuffered
            // or FullyBuffered to compare behavior.
            var scanLines = from n in nums.AsParallel()
                                .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
                            where n % 2 == 0
                            select ExpensiveFunc(n);

            Stopwatch sw = Stopwatch.StartNew();
            foreach (var line in scanLines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("Elapsed time: {0} ms. Press any key to exit.",
                            sw.ElapsedMilliseconds);
            Console.WriteLine("Finishing Fully Buffer");
            //Console.ReadKey();
        }

        // A function that demonstrates what a fly
        // sees when it watches television :-)
        static string ExpensiveFunc(int i)
        {
            Thread.SpinWait(2000000);
            return string.Format("{0} *****************************************", i);
        }
    }
}
