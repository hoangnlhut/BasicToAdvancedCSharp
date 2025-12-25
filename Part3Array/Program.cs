 namespace Part3Array
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tìm Kiếm trong mảng");

            //TimKiemTrongMang do1 = new TimKiemTrongMang();
            //do1.TimKiem();


            Random ran = new Random();
            int[] arrInput = new int[10];
            for (int i = 0; i < 10; i++)
            {
                arrInput[i] = ran.Next() % 1000;
            }

            //Idea: so sánh các phân tử xem thằng nào lớn nhất thì vứt về cuối mảng và cứ như thế. Phẩn tử cuối cùng mảng là lớn nhất gọi là bubble
            Console.WriteLine("Tìm Kiếm Buble Sort");
            foreach (int item in GetBubleSort(arrInput))
            {
                Console.Write($"{item} \t");
            }
            Console.WriteLine($"------------------ \n \n");

            Console.WriteLine("Tìm Kiếm Selection");
            foreach (int item1 in GetSelectionSort(arrInput))
            {
                Console.Write($"{item1} \t");
            }
            Console.WriteLine($"------------------ \n \n");

        }

        private static int[] GetBubleSort(int[] arrInput)
        {
            int[] result = new int[arrInput.Length];
            arrInput.CopyTo(result, 0);

            for(int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length - i - 1; j++)
                {
                    if (result[j] > result[j + 1])
                    {
                        int temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

           return result;
        }

        private static int[] GetSelectionSort(int[] arrInput)
        {
            int[] result = new int[arrInput.Length];
            arrInput.CopyTo(result, 0);

            for (int i = 0; i < result.Length - 1; i++)
            {
                int minIndex = i;

                for(int j = i + 1; j < result.Length; j++)
                {
                    if (result[j] < result[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = result[i];
                result[i] = result[minIndex];
                result[minIndex] = temp;
            }

            return result;
        }
    }
}
