using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.Algorithm.Sort
{
    public class SelectionSort
    {
        public void Implement()
        {
            var list = GenerateArrray();  // generate array

            Console.WriteLine("Before");
            DisplayList(list);

            SelectionSortAlgorithm(list);

            Console.WriteLine();
            Console.WriteLine("After");
            DisplayList(list);
        }

        private void SelectionSortAlgorithm(int[] list)
        {

            for (int i = 0; i < list.Length - 1 ; i++)
            {
                var minIdex = i;

                for (int j = i + 1; j < list.Length ; j++)
                {
                    if (list[minIdex] > list[j])
                    {
                        minIdex = j;
                    }
                }

                var temp = list[i];
                list[i] = list[minIdex];
                list[minIdex] = temp;
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
