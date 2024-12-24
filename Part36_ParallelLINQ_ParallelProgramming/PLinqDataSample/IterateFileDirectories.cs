using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part36_ParallelLINQ_ParallelProgramming.PLinqDataSample
{
    // reference: https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-iterate-file-directories-with-plinq
    public class IterateFileDirectories
    {
        //First way: The first query uses the GetFiles method to populate an array of file names in a directory and all subdirectories. This method can introduce latency at the beginning of the operation, because it doesn't return until the entire array is populated. However, after the array is populated, PLINQ can process it in parallel quickly.
        // Use Directory.GetFiles to get the source sequence of file names.
        public static void FileIterationOne(string path)
        {
            Console.WriteLine("First way");

            var sw = Stopwatch.StartNew();
            int count = 0;
            string[]? files = null;
            try
            {
                files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to access one or more folders in this directory tree.");
                return;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"The specified directory {path} was not found.");
            }

            var fileContents =
                from FileName in files?.AsParallel()
                let extension = Path.GetExtension(FileName)
                where extension == ".txt" || extension == ".htm"
                let Text = File.ReadAllText(FileName)
                select new
                {
                    Text,
                    FileName
                };

            try
            {
                foreach (var item in fileContents)
                {
                    Console.WriteLine($"{Path.GetFileName(item.FileName)}:{item.Text.Length}");
                    count++;
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex =>
                {
                    if (ex is UnauthorizedAccessException uae)
                    {
                        Console.WriteLine(uae.Message);
                        return true;
                    }
                    return false;
                });
            }

            Console.WriteLine($"FileIterationOne processed {count} files in {sw.ElapsedMilliseconds} milliseconds");
            Console.WriteLine("End First way");
            Console.WriteLine();
            Console.WriteLine();
        }

        // Second way: The second query uses the static EnumerateDirectories and EnumerateFiles methods, which begin returning results immediately. This approach can be faster when you're iterating over large directory trees, but the processing time compared to the first example depends on many factors.

        public static void FileIterationTwo(string path) //225512 ms
        {
            Console.WriteLine("Second way");

            var count = 0;
            var sw = Stopwatch.StartNew();
            var fileNames =
                from dir in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                select dir;

            var fileContents =
                from FileName in fileNames.AsParallel()
                let extension = Path.GetExtension(FileName)
                where extension == ".txt" || extension == ".htm"
                let Text = File.ReadAllText(FileName)
                select new
                {
                    Text,
                    FileName
                };
            try
            {
                foreach (var item in fileContents)
                {
                    Console.WriteLine($"{Path.GetFileName(item.FileName)}:{item.Text.Length}");
                    count++;
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex =>
                {
                    if (ex is UnauthorizedAccessException uae)
                    {
                        Console.WriteLine(uae.Message);
                        return true;
                    }
                    return false;
                });
            }

            Console.WriteLine($"FileIterationTwo processed {count} files in {sw.ElapsedMilliseconds} milliseconds");
            Console.WriteLine("End Second way");

        }
    }
}
