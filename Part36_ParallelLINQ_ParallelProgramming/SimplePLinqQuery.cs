using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part36_ParallelLINQ_ParallelProgramming
{
    //reference: https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-create-and-execute-a-simple-plinq-query
    public class SimplePLinqQuery
    {
        public static void MainSimplePLinqQuery()
        {
            var source = Enumerable.Range(100, 20000000);

            Stopwatch stopwatch = new Stopwatch();


            stopwatch.Start();
            // Result sequence might be out of order.
            var parallelQuery =
                from num in source.AsParallel()
                where num % 2 == 0
                select num;
            stopwatch.Stop();
            Console.WriteLine($"parallelQuery finish in {stopwatch.Elapsed}");


            stopwatch.Start();
            List<int> list =new List<int>();
            foreach( int num in source)
            {
                if (num % 2 == 0) list.Add(num);
            }
            stopwatch.Stop();
            Console.WriteLine($"asEnumerable finish in {stopwatch.Elapsed}");

            #region other ways
            //// Process result sequence in parallel
            //parallelQuery.ForAll((e) => DoSomething(e));

            //// Or use foreach to merge results first.
            //foreach (var n in parallelQuery)
            //{
            //    Console.WriteLine(n);
            //}

            //// You can also use ToArray, ToList, etc as with LINQ to Objects.
            //var parallelQuery2 =
            //    (from num in source.AsParallel()
            //     where num % 10 == 0
            //     select num).ToArray();

            //foreach (var n in parallelQuery2)
            //{
            //    DoSomething(n);
            //}

            //// Method syntax is also supported
            //var parallelQuery3 =
            //    source.AsParallel()
            //        .Where(n => n % 10 == 0)
            //        .Select(n => n);
            //Console.WriteLine(parallelQuery3);
            #endregion

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }

        static void DoSomething(int nunber) {
            Console.WriteLine($"Do something number {nunber}");
        }
    }
}
