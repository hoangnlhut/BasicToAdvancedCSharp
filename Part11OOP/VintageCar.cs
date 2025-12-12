namespace Part11_12OOP
{
    public class VintageCar : Car
    {
        public VintageCar(string name) : base(name)
        {
        }
        public override void Who()
        {
            base.Who();
            Console.WriteLine("Vintage car is at normal speed");
        }
    }
}
