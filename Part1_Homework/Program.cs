namespace Part1_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tạo một chương trình dạng Console, sử dụng.NET 8, cho phép nhập vào 5 số nguyên và in ra số lớn nhất trong 5 số(sử dụng cấu trúc if ()).
            //int[] list = new int[5];
            //for (int i = 1; i < 6; i++)
            //{
            //    Console.WriteLine($"Nhập sô thứ {i}: ");
            //    var x = Console.ReadLine();

            //    int result = 0;
            //    if (int.TryParse(x, out result))
            //    {
            //        list[i - 1] = result;
            //    }
            //    else
            //    {
            //        throw new Exception("Invalid value");
            //    }
            //}

            // cách dùng linq
            //Console.WriteLine($"Số lơn nhất trong 5 số là số {list.Max()}");

            // cách 2
            //for(int i = 0; i < list.Length - 1; i++)
            //{
            //    if (list[i] < list[i + 1]) list[0] = list[i + 1];
            //}
            //Console.WriteLine($"Số lơn nhất trong 5 số là số {list[0]}");


            // cách 3
            //int max = int.MinValue;
            //foreach (int i in list)
            //{
            //    if (max < i) max = i;
            //}
            //Console.WriteLine($"Số lơn nhất trong 5 số là số {max}");

            string s = "abc.ToUpper()";
            Console.WriteLine(s);
        }
    }
}
