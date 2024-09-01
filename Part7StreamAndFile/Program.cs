using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace Part7StreamAndFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Viết lệnh Dir như CMD
            //LibraryHelper.DirThroughSystemIo();

            //Thao tác copy file
            //LibraryHelper.CopyFile(args);

            //            Tóm tắt:
            //-Stream(https://learn.microsoft.com/en-us/dot...) là kiểu dùng để đọc hoặc ghi dữ liệu lưu trữ trong các thiết bị ngoại vi, ví dụ như để đọc/ghi file hoặc socket mạng.
            //-Một số kiểu stream chỉ pho phép ghi, một số chỉ cho phép đọc, và một số cho phép cả hai.
            //- Để làm việc với file ta dùng FileStream.
            //- Các thao tác làm việc với file bao gồm: mở, đọc / ghi, đóng.
            //- Thao tác đóng luôn phải được thực hiện để giải phóng các tài nguyên chiếm giữ khi mở, đồng thời đẩy dữ liệu còn lại trong bộ đệm ra file.Để đảm bảo thao tác này luôn được thực hiện, ta có thể sử dụng cấu trúc try...catch...finally hoặc dùng using.
            //-Một số stream cho phép chúng ta nối vào một stream khác để cung cấp thêm tính năng cho nó, ví dụ BufferedStream cung cấp thêm bộ đệm dữ liệu giúp các thao tác đọc ghi trên các stream khác hiệu quả hơn.
            //- MemoryStream là một stream đặc biệt, nó không làm việc với thiết bị ngoại vi mà cung cấp khả năng đọc ghi dữ liệu trong bộ nhớ theo kiểu tuần tự.

            //Bài tập:
            //Viết một chương trình nhận vào tham số trên dòng lệnh là đường dẫn đến một thư mục, vẽ cây thư mục đó
            LibraryHelper.FolderTree(args);
        }

       
    }
}