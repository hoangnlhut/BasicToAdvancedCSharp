using Part98_Delegate_And_Event.Closure;
using Part98_Delegate_And_Event.Event;
using Part98_Delegate_And_Event.ImageProcess;
using System;
using System.Linq.Expressions;

namespace Part98_Delegate_And_Event
{
    public class Program
    {
        public static void Main()
        {
            //RunPair();
            //RunImageProcess();
            //RunEvent();

            //Divide2Number();
            //TestOpenText();
            //TestDelagate();

            //Console.WriteLine("Closure Example give unexpected results");
            //ClosureTest.ResultAsNotExpected();
            //Console.WriteLine("---------------------------------------\n\n");
            //Console.WriteLine("Closure Example give expected results");
            //ClosureTest.ResultAsExpected();
            //Console.WriteLine("---------------------------------------\n\n");

            //Console.WriteLine("Another Closure");
            //ClosureTest closureTest = new ClosureTest();
            //var result = closureTest.Count();
            //Console.WriteLine($"getCount(): {result().ToString()}");
            //Console.WriteLine($"getCount(): {result().ToString()}");
            //Console.WriteLine($"getCount(): {result().ToString()}");
            //Console.WriteLine($"getCount(): {result().ToString()}");


            //Console.WriteLine("---------------------------------------\n\n");
            //Console.WriteLine($"getCount(): {closureTest.Count()().ToString()}");
            //Console.WriteLine($"getCount(): {closureTest.Count()().ToString()}");
            //Console.WriteLine($"getCount(): {closureTest.Count()().ToString()}");
            //Console.WriteLine($"getCount(): {closureTest.Count()().ToString()}");

            //Expression<Func<int, bool>> expr = num => num < 5;
            //Func<int, bool> test = expr.Compile();
            //Console.WriteLine($"Run Expression Tree with result : { test(6)}");


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

        public static void TestDelagate()
        {

            Sum sum = new Sum();
            Divide divide = new Divide();

            //1st way: 
            Hoang.MyDeleagte myDeleagteSum1 = sum.TestSum;
            myDeleagteSum1 += divide.TestDivide;
            Hoang.TestDelegate(myDeleagteSum1, 10, 20);

            //2nd way
            Hoang.MyDeleagte myDeleagteSum = new Hoang.MyDeleagte(sum.TestSum);
            Hoang.MyDeleagte myDeleagteDivide = new Hoang.MyDeleagte(divide.TestDivide);
            Hoang.TestDelegate(myDeleagteSum, 40, 20);
            Hoang.TestDelegate(myDeleagteDivide, 20, 5);
        }
    }

}


