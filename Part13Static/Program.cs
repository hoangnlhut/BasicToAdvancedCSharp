using System;
using System.Text.RegularExpressions;

namespace Part13Static
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ClassC a = new() { };
            //a.CountClassC();
            //a.CountClassC();
            //a.PrintParams();

            //ClassC b = new ClassC() { };
            //b.SetStaticCount(400);
            //b.CountClassC();
            //b.PrintParams();

            //a.PrintParams();

            //Console.WriteLine($"Set static count variable of class ClassC to 900");
            //ClassC.count = 900;

            //a.PrintParams();
            //b.PrintParams();

            //Console.WriteLine($"print static count variable of class ClassC : {ClassC.count}");

            string pattern = @"^([a-zA-Z]:)?(\\[^\\/:*?""<>|\r\n]+)*\\?([^\\/:*?""<>|\r\n]+)$";
            Regex regex = new Regex(pattern);

            string[] testPaths = {
            @"C:\folder\file.txt",
            @"file.txt",
            @"\folder\file.txt",
            @"C:file.txt",
            @"C:\folder\subfolder\file.txt",
            @"\\server\share\file.txt",
            @"C:\Users\Hoang\Downloads\test\hoang.txt",
            @"hoang.txt"
        };

            foreach (string path in testPaths)
            {
                if (regex.IsMatch(path))
                {
                    Console.WriteLine($"Valid: {path}");
                }
                else
                {
                    Console.WriteLine($"Invalid: {path}");
                }
            }
        }
    }
}
