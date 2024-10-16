namespace Part29_Reflection
{
    public class CustomBinderDriver
    {
        public static void PrintBob()
        {
            Console.WriteLine("PrintBob");
        }

        public static void PrintValue(long value)
        {
            Console.WriteLine("PrintValue({0})", value);
        }

        public static void PrintValue(string value)
        {
            Console.WriteLine("PrintValue\"{0}\")", value);
        }

        public static void PrintNumber(double value)
        {
            Console.WriteLine("PrintNumber ({0})", value);
        }
    }
}
