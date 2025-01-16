using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._1stTime.Creational
{
    public abstract class AbstractChair
    {
        public abstract void InitiateChair();
    }

    public class VictorianChair : AbstractChair
    {
        public override void InitiateChair()
        {
            Console.WriteLine("Victorian Chair");
        }
    }

    public class ModelChair : AbstractChair
    {
        public override void InitiateChair()
        {
            Console.WriteLine("Model Chair");
        }
    }

    public abstract class AbstractTable
    {
        public abstract void InitiateTable();
    }

    public class VictorianTable : AbstractTable
    {
        public override void InitiateTable()
        {
            Console.WriteLine("Victorian Table");
        }
    }

    public class ModelTable : AbstractTable
    {
        public override void InitiateTable()
        {
            Console.WriteLine("Model Table");
        }
    }
    public interface AbstractFactory
    {
        AbstractChair CreateChair();
        AbstractTable CreateTable();
    }

    public class VictorianFactory : AbstractFactory
    {
        public AbstractChair CreateChair()
        {
            return new VictorianChair();
        }
        public AbstractTable CreateTable()
        {
            return new VictorianTable();
        }
    }

    public class ModelFactory : AbstractFactory
    {
        public AbstractChair CreateChair()
        {
            return new ModelChair();
        }
        public AbstractTable CreateTable()
        {
            return new ModelTable();
        }
    }

    public class Client
    {
        private AbstractFactory _factory;
        public Client(AbstractFactory factory)
        {
            _factory = factory;
        }

        public void Build()
        {
            var chair = _factory.CreateChair();
            chair.InitiateChair();
            var table = _factory.CreateTable();
            table.InitiateTable();
        }

        public static void MainClient()
        {
            Console.WriteLine("Build Vitorian Factory");
            Client client = new Client(new VictorianFactory());
            client.Build();
            Console.WriteLine("Build Vitorian Completely");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Build Model Factory");
            client = new Client(new ModelFactory());
            client.Build();
            Console.WriteLine("Build Model Completely");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
