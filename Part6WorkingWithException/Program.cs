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
        }
    }
}
