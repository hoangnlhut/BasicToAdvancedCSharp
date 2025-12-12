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
            DeniInterface.Run();
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

}

