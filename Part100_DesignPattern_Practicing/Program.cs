using Part100_DesignPattern_Practicing._1stTime.Behavior;
using Part100_DesignPattern_Practicing._1stTime.Creational;
using Part100_DesignPattern_Practicing._1stTime.Structural;
using Part100_DesignPattern_Practicing._2ndTime.Behavior;
using Part100_DesignPattern_Practicing._2ndTime.Creational;
using Part100_DesignPattern_Practicing._2ndTime.Structural;

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
        //ClientFacade.MainClientFacade();
        #endregion
        #endregion
        #region Behavioral Patterns
        #region Observer
        //ClientObserver.MainClient();
        #endregion

        #region Strategy
        //Console.WriteLine("Get destination by Walking  ");
        //ContextStrategy context = new ContextStrategy(new Walking());
        //context.Move();
        //Console.WriteLine();
        //Console.WriteLine();

        //Console.WriteLine("Get destination by Running  ");
        //context.SetStrategy(new Running());
        //context.Move();
        //Console.WriteLine();
        //Console.WriteLine();

        //Console.WriteLine("Get destination by Car  ");
        //context.SetStrategy(new CarMoving());
        //context.Move();
        //Console.WriteLine();
        //Console.WriteLine();

        //Console.WriteLine("Get destination by Bus  ");
        //context.SetStrategy(new PublicTransportation());
        //context.Move();
        //Console.WriteLine();
        //Console.WriteLine();

        #endregion

        #region Command
        //ClientCommand.Run();
        #endregion

        #region State Pattern
        //try
        //{
        //    Console.WriteLine("Create new Order");
        //    Context context = new Context(new CreatedState());
        //    context.Cancel();

        //    Console.WriteLine("Create new Order");
        //    Context context1 = new Context(new CreatedState());
        //    context1.Paid();
        //    context1.Delivered();
        //    context1.Done();

        //    context1.Cancel();
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
        #endregion

        #region Template Method
        //HouseBuildingTemplateMethod woodenHouse = new WoodenHouse();
        //woodenHouse.BuildHouse();
        //Console.WriteLine();
        //Console.WriteLine("----------------------------------------");

        //HouseBuildingTemplateMethod glassHouse = new GlassHouse();
        //glassHouse.BuildHouse();
        //Console.WriteLine();
        //Console.WriteLine("----------------------------------------");

        //HouseBuildingTemplateMethod simenHouse = new SimenHouse();
        //simenHouse.BuildHouse();
        #endregion

        #endregion
        #endregion
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        #region Practicing Second Time
        #region Creational Patterns
        #region Singleton 
        //Console.WriteLine("Testing Singleton no Thread Safe");
        //Console.WriteLine(SingletonNoThread.GetInstance("hoang").Value);
        //Console.WriteLine();
        //Console.WriteLine();

        //Console.WriteLine("Testing Singleton With Thread Safe");
        //Thread t1 = new Thread(() =>
        //{
        //    Console.WriteLine(SingletonThreadSafe2.GetInstance("thread 1").Value);
        //});

        //Thread t2 = new Thread(() =>
        //{
        //    Console.WriteLine(SingletonThreadSafe2.GetInstance("thread 2").Value);
        //});
        //t1.Start();
        //t2.Start();
        //t1.Join();
        //t2.Join();

        #endregion
        #region Factory Method

        //Ordinary way
        //List<IPizza> listPizza = new List<IPizza>()
        //{
        //    FactoryMethod2.PizzaFactory("fds"),
        //    FactoryMethod2.PizzaFactory("JP"),
        //    FactoryMethod2.PizzaFactory("USA")
        //};
        //foreach (var item in listPizza)
        //{
        //    item.DoPizza();
        //}

        //design pattern way
        //List<Creator2> creator2s = new List<Creator2>()
        //{
        //    new CreatorHut(),
        //    new Creator4P(),
        //    new CreatorNothing(),
        //};

        //foreach (var item in creator2s)
        //{
        //    item.DoOperation();
        //}

        #endregion
        #region Abstract Factory
        //AbstracFactoryCar factoryCar = new SuperCarFactory();
        //AbstractFactoryClient.RunFactory(factoryCar);

        //factoryCar = new VintageCarFactory();
        //AbstractFactoryClient.RunFactory(factoryCar);
        #endregion
        #region Builder
        //Director2 director = new Director2(new ConcreateProduct2());
        //director.VegetarianBread();
        //director.GymerBread();
        #endregion
        #endregion
        #region Structural Patterns
        #region Adapter
        //PrinterAdapter printerAdapter = new PrinterAdapter(new LegacyPrintServiceAdaptee());
        //ClientAdapter.MainRun(printerAdapter);
        #endregion
        #region Decorator
        //IVideoComponent mp3 = new Mp3Video();
        //var highQuality = new HighQualityVideoDecorator(mp3);
        //var speeding = new SpeedVideoDecorator(highQuality);
        //var savePlaylists = new AddPlaylistsVideoDecorator(speeding);

        //savePlaylists.PlayVideo();
        #endregion
        #region Facade Pattern
        //ClientFacade2.BookingCheapVacation();
        //ClientFacade2.BookingDeluxeVacation();
        #endregion
        #endregion
        #region Behavioral Patterns
        #region Observer
        //ClientObserver2.WarningStorm();
        //ClientObserver2.RecommentToGoOut();
        #endregion
        #region Strategy
        //ClientStrategy2.Main2();
        #endregion
        #region Command
        //ClientCommand2.MainCommand();
        #endregion
        #region State Pattern
        //MainState2.Main2();
        #endregion
        #region Template Method
        MainTemplateMethod.Main2();
        #endregion
        #endregion
        #endregion
    }
}