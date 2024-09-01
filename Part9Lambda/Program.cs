
namespace Part9Lambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region using lambda to sum 2 numbers
            //Console.WriteLine("using lambda to sum 2 numbers");
            //int a = 5;
            //int b = 10;
            //var sum = (int a, int b) => a + b;
            //Console.WriteLine($"Sum of {a} and {b}: {sum(a,b)}");

            //Action<string> printString = input => Console.WriteLine(input);
            //printString("Xin chao cac ban");
            #endregion

            #region  search one specified item in array
            var arrra = new[] { 12, 23, 456, 67676, 67212312, 1234 };

            PrintExistItem((int a, int b) => a == b ? true : false, 12, arrra);
            PrintExistItem((int a, int b) => a == b ? true : false, 1, arrra);
            PrintExistItem((int a, int b) => a == b ? true : false, 2, arrra);
            PrintExistItem((int a, int b) => a == b ? true : false, 67676, arrra);
            PrintExistItem((int a, int b) => a == b ? true : false, 456, arrra);

            #endregion

        }

        private static void PrintExistItem(Func<int, int, bool> value, int v, int[] arrra)
        {
            int flag = 0;
            foreach (var item in arrra)
            {
                if (value(v, item))
                {
                    Console.WriteLine($"Number {v} is existed in array");
                    flag++;
                }
            }

            if (flag <= 0) Console.WriteLine($"Number {v} is NOT existed in array");

        }
    }
}
