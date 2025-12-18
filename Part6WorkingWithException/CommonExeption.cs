namespace Part6WorkingWithException
{
    public class CommonExeption
    {
        public static void TestCommonExeption()
        {
            try
            {
                Console.WriteLine("Starting Main....");
                f1();
            }
            catch (Exception)
            {
                Console.WriteLine("Exception caught in Main....");
            }
            Console.WriteLine("Finishing Main....");
        }

        private static void f1()
        {
            // this way , the exception is handled inside f1,  Main are not affected.

            //try
            //{
            //    Console.WriteLine("Starting F1....");
            //    f2();
            //    Console.WriteLine("Finishing F1....");
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Exception caught in F1");
            //}
            Console.WriteLine("Starting F1....");
            f2();
            Console.WriteLine("Finishing F1....");

        }

        private static void f2()
        {
            // this way , the exception is handled inside f2, and f1, Main are not affected.
            //try
            //{
            //    Console.WriteLine("Starting F2....");
            //    throw new Exception();
            //}
            //catch
            //{
            //    Console.WriteLine("Exception caught in F2");
            //}
            //Console.WriteLine("Finishing F2....");

            Console.WriteLine("Starting F2....");
            throw new Exception();
            Console.WriteLine("Finishing F2....");
        }
    }
}