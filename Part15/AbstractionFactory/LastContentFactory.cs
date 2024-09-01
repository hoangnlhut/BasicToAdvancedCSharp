using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part15.AbstractionFactory
{
    public static class LastContentFactory
    {
        public static List<string> GetLastContentFactory(FileToFind file)
        {
            switch (file.ParamsForFind)
            {
                case "/c /v":
                    return new LastContentWithCandV().GetLastContent(file); //hiển thị số dòng không chứa từ khóa (có phân biệt hoa thường)
                case "/c /n":
                    return new LastContentWithCandN().GetLastContent(file);  //hiển thị SỐ lượng dòng xuất hiện từ khóa
                case "/c":
                    return new LastContentWithC().GetLastContent(file); //hiển thị SỐ lượng dòng xuất hiện từ khóa
                case "/v":
                    return new LastContentWithV().GetLastContent(file); //hiển thị các dòng không có từ khóa cần tìm trong file
                case "/n":
                    return new LastContentWithN().GetLastContent(file);  //hiện thị các dòng có xuất hiện từ khóa với định dạng sau [index của dòng] nội dung dòng
                case "/i":
                    return new LastContentWithI().GetLastContent(file); // hiện thị tất cả các dòng có từ khóa cần tìm KHÔNG PHÂN BIỆT HOA THƯỜNG
                default:
                    return new LastContentDefault().GetLastContent(file); // hiển thị hết các 
            }
        }
    }
}
