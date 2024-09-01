using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part8Collection
{
    public static class Helper
    {
        //TODO: do later whenever think new algorithm
        public static void PrintWordFromCharacters()
        {
            string[] characters = new string[4] { "a", "b", "c", "d" };

            List<string> words = new List<string>();
            
            foreach (var charac in characters)
            {
                var newString = characters.ToList();
                foreach (var item in newString)
                {

                }
            }

        }

        public static void PrintSortStringFromInput()
        {
            List<string> words = new List<string>();
            ReadWords(words);
            PrintWords(words);
            Sort(words);
            PrintWords(words);
        }

        private static void Sort(List<string> words)
        {
            //words.Sort(); using LINQ

            // bubble sort: sap xep noi bot
            for (int i = 0; i < words.Count - 1; i++)
            {
                for(int j = 0; j < words.Count - i - 1; j++)
                {
                    if (words[j].CompareTo(words[j + 1]) > 0)
                    {
                        var temp = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = temp;
                    }
                }
            }

        }

        private static List<string> ReadWords(List<string> words)
        {
            var input  = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Nhập vào màn hình các chuỗi");
                input = Console.ReadLine();
                words.Add(input);
            }

            return words;
        }

        private static void PrintWords(List<string> words)
        {
            Console.WriteLine("------------------------------------");
            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}
