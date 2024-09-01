namespace Part5_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Bài tập:
            #region -Viết hàm tráo đổi 2 số a và b, sử dụng tham số kiểu ref.
            //Console.WriteLine("Nhap vao so a");
            //var a = Console.ReadLine();
            //Console.WriteLine("Nhap vao so b");
            //var b = Console.ReadLine();

            //int newA = Int32.Parse(a!.ToString());
            //int newB = Int32.Parse(b!.ToString());

            //Console.WriteLine($"So a la {newA} va So b la {newB}");
            //Console.WriteLine("Chuyen a va b");
            //SwitchTwoNumberUsingRef.Implement(ref newA, ref newB);
            //Console.WriteLine($"Sau Khi Chuyen: So a la {newA} va So b la {newB}");
            #endregion

            #region Viết hàm in ra dãy số Fibonacci dùng List
            //Console.WriteLine("Nhập độ dài chuối Fibonaci");
            //int length = int.Parse(Console.ReadLine()!);


            //var list = new List<int>() { 1, 1};
            //for (int i = 2; list.Count <= length; i++)
            //{
            //    list.Add(list[i - 1] + list[i - 2]);
            //}

            //Console.WriteLine("Chuối Fibonaci là");
            //foreach (var item in list)
            //{
            //    Console.Write($"{item} ");
            //}
            #endregion

            #region Viết hàm in ra dãy số Fibonacci dùng Đệ Quy
            //Console.WriteLine("Nhập độ dài chuối Fibonaci dùng Đệ Quy");
            //int length = int.Parse(Console.ReadLine()!);

            //Console.WriteLine("Chuối Fibonaci là");
            //for (int i = 0; i < length; i++)
            //{
            //    Console.Write(ExtentionLibrary.FibonacciDeQuy(i) + " ");
            //}
            #endregion

            #region Viết hàm Tính Giai Thừa dùng Đệ Quy
            //Console.WriteLine();
            //Console.WriteLine("------------------------------");
            //Console.WriteLine("Tính Giai Thừa của: ");
            //int input = int.Parse(Console.ReadLine()!);
            //Console.WriteLine("Kết Quả giai thừa của " + input + " là " + ExtentionLibrary.GiaiThuaDeQuy(input));
            //Console.WriteLine();
            //Console.WriteLine("------------------------------");
            #endregion

            //-Tìm hiểu từ khóa out. : từ khóa out giống ref đều thay đổi được giá trị khi hàm kết thúc nhưng khác ref là 
            // ref thì phải khởi tạo giá trị khi truyền vào hàm còn out thì không phải khởi tạo giá trị khi truyền vào hàm

            #region -Tìm hiểu từ khóa params: khi truyền vào một danh sách các tham số có cùng kiểu thì ta có thể dùng từ khóa params
            Console.WriteLine("Tính tổng các số sau");
            Random randomNum = new Random();

            var list = new List<int>(); 
            for (int i = 0; i < 5; i++) 
            {
                var item = randomNum.Next() % 100;
                list.Add(item);
                Console.WriteLine(item + " ");
            }

            Console.WriteLine("Tong :" + ExtentionLibrary.AddNumbers(list[0], list[1], list[2], list[3], list[4]));

            #endregion
        }
    }
}
