using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part15.AbstractionFactory
{
    public static class LastContentFactory
    {
        public static IContentFromParams GetLastContentFactory(string paramsForFind)
        {
            switch (paramsForFind)
            {
                case "/c /v":
                    return new LastContentWithCandV(); //hiển thị số dòng không chứa từ khóa (có phân biệt hoa thường)
                case "/c /n":
                    return new LastContentWithCandN();  //hiển thị SỐ lượng dòng xuất hiện từ khóa
                case "/c":
                    return new LastContentWithC(); //hiển thị SỐ lượng dòng xuất hiện từ khóa
                case "/v":
                    return new LastContentWithV(); //hiển thị các dòng không có từ khóa cần tìm trong file
                case "/n":
                    return new LastContentWithN();  //hiện thị các dòng có xuất hiện từ khóa với định dạng sau [index của dòng] nội dung dòng
                case "/i":
                    return new LastContentWithI(); // hiện thị tất cả các dòng có từ khóa cần tìm KHÔNG PHÂN BIỆT HOA THƯỜNG
                default:
                    return new LastContentDefault(); // hiển thị hết các 
            }
        }
    }
}
