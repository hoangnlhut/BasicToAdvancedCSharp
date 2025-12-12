namespace Part11_12OOP
{
    public class SportsCar : Car
    {
        public SportsCar(string name) : base(name)
        {
        }
        public override void Who()
        {
            base.Who();
            Console.WriteLine("Sports car is driving fast!");
        }
    }
}
