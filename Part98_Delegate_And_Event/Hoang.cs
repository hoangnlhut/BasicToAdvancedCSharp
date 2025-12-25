namespace Part98_Delegate_And_Event
{
    public class Hoang
    {
        public delegate void MyDeleagte(int x, int y);

        public static void TestDelegate(MyDeleagte hahah, int e, int g)
        {
            hahah(e, g);
        }
    }

    public class Sum
    {
        public void TestSum(int a, int b)
        {
            Console.WriteLine($"Sum of {a} + {b}: {a + b}");
        }
    }

    public class Divide
    {
        public void TestDivide(int c, int d)
        {
            Console.WriteLine($"Divide of {c} / {d}: {c / d}");
        }


    }

}


