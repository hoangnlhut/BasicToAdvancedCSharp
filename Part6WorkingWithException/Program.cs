

namespace Part6WorkingWithException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tóm tắt:
            //-Exception là cách thức.NET thông báo lỗi chương trình, chúng có thể được phát ra khi gặp một lỗi(ví dụ như chia cho 0, truy cập vào phần tử null...), hoặc cũng có thể do chương trình phát ra(dùng throw).
            //- Ta có thể bắt các exception bằng cách đặt đoạn lệnh sinh ra lỗi trong khối try ... catch ... finally.
            //-Một khối try có thể có nhiều khối catch để bắt các loại exception khác nhau.
            //- Khối finally luôn luôn được thực hiện, kể cả khi một exception khác xảy ra khi đang thực hiện catch.
            //-Exception tốn kém chi phí để tạo ra nên khi cần hiệu năng cao ta nên tránh dùng nó(ví dụ nên dùng int.TryParse thay vì int.Parse).
            //CommonExeption.TestCommonExeption();
            //Divide2Number();
            TestOpenText();
        }



        public static void Divide2Number()
        {
            Console.WriteLine("Bắt đầu phép chia");
            try
            {
                uint so1 = 0;
                int so2, so3;
                so2 = -10;
                so3 = 0;
                // tính giá trị lại
                so1 -= 5;
                so2 = 5 / so3;
                // xuất kết quả
                Console.WriteLine("So 1: {0}, So 2:{1}", so1, so2);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Lỗi: Chia cho số 0");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Lỗi: Tràn số khi chuyển đổi kiểu dữ liệu");
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi khác: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Kết thúc phép chia");
            }

        }

        public static void TestOpenText()
        {
            string fname = "test3.txt";
            string buffer;
            try
            {
                StreamReader sReader = File.OpenText(fname);
                while ((buffer = sReader.ReadLine()) != null)
                {
                    Console.WriteLine(buffer);
                }
                sReader.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Lỗi: Không tìm thấy file " + fname);
            }
            catch (Exception)
            {
                Console.WriteLine("Lỗi");
            }
            
        }

    }
}
