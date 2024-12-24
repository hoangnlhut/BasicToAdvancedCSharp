using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part36_ParallelLINQ_ParallelProgramming.PLinqDataSample
{
    public class UsingStopWatchToMeasureQueryPerformance
    {
        public static void MainUsingStopWatchToMeasureQueryPerformance()
        {
            var source = Enumerable.Range(0, 100000);

            var queryToMeasure =
                 from num in source.AsParallel()
                 where num % 3 == 0
                 select Math.Sqrt(num);

            Console.WriteLine("Measuring...");

            // The query does not run until it is enumerated.
            // Therefore, start the timer here.
            var sw = Stopwatch.StartNew();

            // For pure query cost, enumerate and do nothing else.
            foreach (var n in queryToMeasure) { Console.WriteLine(n); }

            sw.Stop();
            long elapsed = sw.ElapsedMilliseconds; // or sw.ElapsedTicks
            Console.WriteLine("Total query time: {0} ms", elapsed);
            Console.WriteLine("Total query time: {0} ms", sw.Elapsed);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
