namespace Part11_12OOP
{
    public class HyperCar : Car
    {
        public HyperCar(string name) : base(name)
        {
        }
        public override void Who()
        {
            base.Who();
            Console.WriteLine("Hyper car is very very fast and fancy");
        }
    }
}
