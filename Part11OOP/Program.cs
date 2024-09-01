namespace Part11_12OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test polymorphism");
            Polymorphism polymorphism = new Polymorphism();
            polymorphism.ImplementWrong();
            polymorphism.ImplementTrue();
        }
    }
}
