using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3Array
{
    public class TimKiemTrongMang
    {
        public void TimKiem()
        {
            int[] arrs = { 1, 4, 6, 8, 9, 10, 12, 13, 14, 15, 16 };

            Console.WriteLine("Nhập vào một số xem có xuât hiện trong mảng đó không: ");
            var input = Console.ReadLine();

            int result = 0;
            //validate
            if (!int.TryParse(input, out result)) throw new Exception("Invalid input");

            // check if result is belong to an array
            int flag = 0;
            foreach (int i in arrs)
            {
                if(result == i)
                {
                    flag++;
                    break;
                }    
            }

            string res = flag > 0 ? "Có" : "Không";

            Console.WriteLine($"Số vừa nhập {result} {res} xuất hiện trong mảng lúc đầu");

        }
    }
}
