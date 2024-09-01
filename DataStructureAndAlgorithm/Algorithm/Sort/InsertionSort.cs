using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.Algorithm.Sort
{
    public class InsertionSort
    {
        public void Implement()
        {
            var list = GenerateArrray();  // generate array

            Console.WriteLine("Before");
            DisplayList(list);

            InsertionSortAlgorithm(list);

            Console.WriteLine();
            Console.WriteLine("After");
            DisplayList(list);
        }

        private void InsertionSortAlgorithm(int[] list)
        {
           for (int i = 1; i < list.Length; i++)
            {
                var value = list[i];
                int j = i - 1;

                while (j >= 0 && list[j] > value)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = value;
                DisplayList(list);
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
