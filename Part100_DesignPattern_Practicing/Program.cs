using Part100_DesignPattern_Practicing._1stTime.Creational;
using Part100_DesignPattern_Practicing._1stTime.Structural;

public class Program
{
    private static void Main(string[] args)
    {
        #region Practicing First Time
        #region Creational Patterns
        #region Singleton 
        // non thread safe
        //var nonSafeThread1 =  SingletonNonSafeThread.GetInstance();
        //var nonSafeThread2 =  SingletonNonSafeThread.GetInstance();

        //if (nonSafeThread1 == nonSafeThread2)
        //{
        //    Console.WriteLine("Singleton works, both variables contain the same instance.");
        //}
        //else
        //{
        //    Console.WriteLine("Singleton failed, variables contain different instances.");
        //}

        // thread safe
        //Thread thread1 = new Thread(() =>
        //{
        //   var thread1Vari = SingletonThreadSafe.GetInstance("Thread1");
        //    Console.WriteLine($"Name of Thread 1: {thread1Vari.Name}");
        //});

        //Thread thread2 = new Thread(() =>
        //{
        //    var thread2Vari = SingletonThreadSafe.GetInstance("Thread2");
        //    Console.WriteLine($"Name of Thread 2: {thread2Vari.Name}");
        //});

        //thread1.Start();
        //thread2.Start();

        //thread1.Join();
        //thread2.Join();
        #endregion

        #region Factory Method
        //Creator creatorPA = new CreatorProductA();
        //creatorPA.SomeOperation();

        //Creator creatorPB = new CreatorProductB();
        //creatorPB.SomeOperation();
        #endregion

        #region Abstract Factory
        //Client.MainClient();
        #endregion

        #region Builder
        //Console.WriteLine("Build Minimum Product");
        //var productA = new ConCreateBuilder();
        //Director minimum = new Director(productA);
        //minimum.BuildMinimalViableProduct();
        //Console.WriteLine(productA.GetProduct().ListParts());
        //Console.WriteLine("COMPLETE Build Minimum Product");
        //Console.WriteLine();

        //Console.WriteLine("Build Full Product");
        ////var productB = new ConCreateBuilder();
        //Director full = new Director(productA);
        //full.BuildFullFeaturedProduct();
        //Console.WriteLine(productA.GetProduct().ListParts()); 
        //Console.WriteLine("COMPLETE Build Full Product");

        //Console.WriteLine("You can buil manually like that");
        //productA.BuildStepZ();
        //productA.BuildStepB();
        //productA.BuildStepA();
        //Console.WriteLine(productA.GetProduct().ListParts());

        #endregion
        #endregion
        #region Structural Patterns
        #region Adapter
        //Console.WriteLine("Thiet bi 2 chan cam vao o dien");
        //ClientInAdapter client = new ClientInAdapter(new AdapterOCamDien(new Sockets2LoCamDien()));
        //client.MainClient();

        //Console.WriteLine();

        //Console.WriteLine("Thiet bi 3 chan cam vao o dien");
        //client = new ClientInAdapter(new AdapterOCamDien(new Sockets3LoCamDien()));
        //client.MainClient();
        #endregion

        #region Decorator
        //var a = new ConcreteComponent();
        //var b = new ConcreteDecoratorA(a);
        //var c = new ConcreteDecoratorB(b);
        //Console.WriteLine(c.Execute()); 

        //Console.WriteLine("Make an thick pizza with cheese and tomato on top");
        //var plate = new ThickBasePizza();
        //var addCheese = new CheeseDecorator(plate);
        //var addTomato = new TomatoDecorator(addCheese);
        //addTomato.DoPizza();

        //Console.WriteLine();
        //Console.WriteLine("-------------------");

        //Console.WriteLine("Make an thin pizza with bacon and onion on top");
        //var newPlate = new ThinBasePizza();
        //var bacon = new BaconDecorator(newPlate);
        //var onion = new OnionDecorator(bacon);
        //onion.DoPizza();

        //Console.WriteLine();
        //Console.WriteLine("-------------------");

        //Console.WriteLine("Full-toping Thick plate pizza ");
        //var fullPlate = new ThickBasePizza();
        //var addCheeseFull = new CheeseDecorator(fullPlate);
        //var addTomatoFull = new TomatoDecorator(addCheeseFull);
        //var addBaconFull = new BaconDecorator(addTomatoFull);
        //var addOnionFull = new OnionDecorator(addBaconFull);
        //addOnionFull.DoPizza();

        #endregion

        #region Facade Pattern
        ClientFacade.MainClientFacade();
        #endregion


        #endregion
        #endregion
    }
}