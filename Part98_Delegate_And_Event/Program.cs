using Part98_Delegate_And_Event.Event;
using Part98_Delegate_And_Event.ImageProcess;
using System;

namespace Part98_Delegate_And_Event
{
    public class Program
    {
        public static void Main()
        {
            //RunPair();
            //RunImageProcess();
            RunEvent();
        }

        public static void RunPair()
        {
            // tạo ra hai đối tượng Student và Cat
            // đưa chúng vào hai đối tượng Pair
            Student Thao = new Student("Thao");
            Student Ba = new Student("Ba");
            Cat Mun = new Cat(5);
            Cat Ngao = new Cat(2);
            Pair studentPair = new Pair(Thao, Ba);
            Pair catPair = new Pair(Mun, Ngao);
            Console.WriteLine("Sinh vien \t\t\t: {0}", studentPair.ToString());
            Console.WriteLine("Meo \t\t\t: {0}", catPair.ToString());
            // tạo ủy quyền
            Pair.WhichIsFirst theStudentDelegate = new Pair.WhichIsFirst(Student.WhichStudentComesFirst);
            Pair.WhichIsFirst theCatDelegate = new Pair.WhichIsFirst(Cat.WhichCatComesFirst);
            // sắp xếp dùng ủy quyền
            studentPair.Sort(theStudentDelegate);
            Console.WriteLine("Sau khi sap xep studentPair\t\t:{0}", studentPair.ToString());
            studentPair.ReverseSort(theStudentDelegate);
            Console.WriteLine("Sau khi sap xep nguoc studentPair\t\t:{0}", studentPair.ToString());

            catPair.Sort(theCatDelegate);
            Console.WriteLine("Sau khi sap xep catPair\t\t:{0}", catPair.ToString());
            catPair.ReverseSort(theCatDelegate);
            Console.WriteLine("Sau khi sap xep nguoc catPair\t\t:{0}", catPair.ToString());
        }

        public static void RunImageProcess()
        {
            Image theImage = new Image();
            // do không có GUI để thực hiện chúng ta sẽ chọn lần
            // lượt các hành động và thực hiện
            ImageProcessor theProc = new ImageProcessor(theImage);
            theProc.AddToEffects(theProc.BlurEffect);
            theProc.AddToEffects(theProc.FilterEffect);
            theProc.AddToEffects(theProc.RotateEffect);
            theProc.AddToEffects(theProc.SharpenEffect);
            theProc.ProcessImage();
        }

        public static void RunEvent()
        {
            // tạo ra đối tượng clock
            Clock theClock = new Clock();
            // tạo đối tượng DisplayClock đăng ký
            // sự kiện và xử lý sự kiện
            DisplayClock dc = new DisplayClock();
            dc.Subscribe(theClock);
            // tạo đối tượng LogCurrent và yêu cầu đăng
            // ký và xử lý sự kiện
            LogCurrentTime lct = new LogCurrentTime();
            lct.Subscribe(theClock);
            // bắt đầu thực hiện vòng lặp và phát sinh sự kiện
            // trong mỗi giây đồng hồ
            theClock.Run();
        }
    }

    

}


