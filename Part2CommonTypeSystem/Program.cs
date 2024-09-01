namespace Part2CommonTypeSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Value Type First");
            var valueType = new ValueType();
            valueType.Assign();

            Console.WriteLine("Test Reference Type ");
            var refType = new ReferenceType();
            refType.AssignedReferenceTest();
        }
    }
}
