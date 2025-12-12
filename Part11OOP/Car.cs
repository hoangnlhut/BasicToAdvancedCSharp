namespace Part11_12OOP
{
    public class Car
    {
        private string name;
        public Car(string name)
        {
            this.name = name;
        }

        public virtual void Who()
        {
            Console.WriteLine("{0} is driving", name);
        }
    }
}
