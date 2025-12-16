using System.Collections;
using System.Collections.Immutable;

namespace Part11_12OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Test polymorphism");
            //Polymorphism polymorphism = new Polymorphism();
            //polymorphism.ImplementWrong();
            //polymorphism.ImplementTrue();

            //TestCarPolymophy();
            //DeniInterface.Run();
            TestArray();
        }

        static void TestArray()
        {
            //string[] strE = new String[256];
            //strE[10] = "Hello";
            //strE[20] = "Hoang";
            //strE[220] = "Hoang";

            //Int32[] strE1 = new Int32[256];
            //strE1[10] = 1;
            //strE1[20] = 2;
            //strE1[220] = 3;


            //Sorting array
            //SortingArray();

            //Jagged array
            //TestJaggedArray();


            FindMaxAndMinInArray();


            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add(4);
            arrayList.Add(5);
            arrayList.Add(6);
            arrayList.Add(7);

            Console.WriteLine($"ArrayList count: {arrayList.Count}");

            arrayList.Capacity = 4;
           
        }

        private static void FindMaxAndMinInArray()
        {


            const int rows = 3;
            const int columns = 4;

            int[,] arr = new int[rows, columns];
            arr[0, 0] = 1;
            arr[0, 1] = 11;
            arr[0, 2] = 3;
            arr[0, 3] = 6;
            arr[1, 0] = 14;
            arr[1, 1] = 4;
            arr[1, 2] = 4;
            arr[1, 3] = 6;
            arr[2, 0] = 9;
            arr[2, 1] = 17;
            arr[2, 2] = 34;
            arr[2, 3] = 18;

            Int32[] oneDimenArr = new Int32[12];
            int flag = 0;

            

            // khởi tạo các thành phần trong mảng
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    oneDimenArr[flag++] = arr[i, j] ;
                }
            }


            flag = 0;
            foreach (int item in oneDimenArr.OrderDescending())
            {
                Console.Write(item + " ");
                oneDimenArr[flag++] = item;
            }
            Console.WriteLine();
            Console.WriteLine($"Max value in array: {oneDimenArr[0]}");
            Console.WriteLine($"Min value in array: {oneDimenArr[oneDimenArr.Length - 1]}");

        }

        private static void TestJaggedArray()
        {
            int[][] arr = new int[3][];
            arr[0] = new int[] { 1, 2, 3 };
            arr[1] = new int[] { 3, 5 };
            arr[2] = new int[] { 6, 7, 8, 9 };

            foreach (int[] row in arr)
            {
                foreach (int item in row)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }

            foreach (int item in arr.SelectMany(x => x))
            {
                Console.Write(item + " ");
            }
        }

        private static void SortingArray()
        {
            int[] ints = new int[] { 1, 12, 33, 4, 5, 6, 7, 18, 9 };
            
            foreach (var each in ints.Order())
            {
                Console.WriteLine($"Value: {each}");
            }

            Console.WriteLine("----------------");
            foreach (var each in ints.OrderDescending())
            {
                Console.WriteLine($"Value: {each}");
            }
        }

        static void TestCarPolymophy()
        {
            Car[] cars = new Car[4];
            cars[0] = new Car("Base car");
            cars[1] = new SportsCar("BMW");
            cars[2] = new VintageCar("Mercedes");
            cars[3] = new HyperCar("Lamboghini");

            foreach (Car car in cars)
            {
                car.Who();
            }
        }
    }


    interface IBase
    {
        int P { get; set; }
    }

    interface IDerived : IBase
    {
        new int P();
    }

    class myClass1 : IDerived
    {
        // thực thi tường minh cho thuộc tính cơ sở
        int IBase.P { get { /* do anything */ return 0; } set { } }
        // thực thi ngầm định phương thức dẫn xuất
        public int P() { /* do anything */ return 0; }
    }

    class myClass2 : IDerived
    {
        // thực thi ngầm định cho thuộc tính cơ sở
        public int P { get { /* do anything */ return 0; } set { } }
        // thực thi tường minh phương thức dẫn xuất
        int IDerived.P() { /* do anything */ return 0; }
    }
    class myClass3 : IDerived
    {
        // thực thi tường minh cho thuộc tính cơ sở
        int IBase.P { get { /* do anything */ return 0; } set { } }
        // thực thi tường minh phương thức dẫn xuất
        int IDerived.P() { /* do anything */ return 0; }
    }
    public interface IDimensions
    {
        long Width { get; set; }
        long Height { get; set; }
        double Area();
        double Circumference();
        int Side();
    }
}

