using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.Algorithm.Sort
{
    public class NormalSort
    {
        public void SortAscending(int ascOrDesc)
        {
            string print = ascOrDesc > 0 ? "ascending" : "decsending";
            Console.WriteLine($"Normal sort to {print}");

            var list = GenerateArrray();
            Console.WriteLine($"Normal sort BEFORE {print}");
            DisplayList(list);

            var count = list.Count();

            if (ascOrDesc > 0)
            {
                for (int i = 0; i <= count - 2; i++)
                {
                    for (int j = i + 1; j <= count - 1; j++)
                    {
                        if (list[i] > list[j])
                        {
                            var switchValue = list[i];
                            list[i] = list[j];
                            list[j] = switchValue;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i <= count - 2; i++)
                {
                    for (int j = i + 1; j <= count - 1; j++)
                    {
                        if (list[i] < list[j])
                        {
                            var switchValue = list[i];
                            list[i] = list[j];
                            list[j] = switchValue;
                        }
                    }
                }
            }
           

            Console.WriteLine($"Normal sort AFTER {print}");
            DisplayList(list);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
        }

        private void DisplayList(int[] list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public int[] GenerateArrray()
        {
            Random random = new Random();

            Console.WriteLine("10 number random");
            var list = new int[10];

            for (int i = 0; i < 10; i++)
            {
                list[i] = random.Next() % 1000;
            }

            return list;
        }
    }
}
