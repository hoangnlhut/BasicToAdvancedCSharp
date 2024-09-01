using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.Algorithm.Sort
{
    public class BubleSort
    {
        public void Implement()
        {
            var list = GenerateArrray();  // generate array

            Console.WriteLine("Before");
            DisplayList(list);

            BubleSortAlgorithm(list);

            Console.WriteLine();
            Console.WriteLine("After");
            DisplayList(list);
        }

        private void BubleSortAlgorithm(int[] list)
        {
            for (int i = 0; i < list.Length - 1; i++) 
            {
                for(int j = 0; j < list.Length - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        var temp = list[j];
                        list[j] =  list[j + 1 ];
                        list[j + 1] = temp;
                    }
                    DisplayList(list);
                }
            }

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
