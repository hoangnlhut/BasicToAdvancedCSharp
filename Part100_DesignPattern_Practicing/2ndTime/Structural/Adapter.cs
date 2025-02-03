using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._2ndTime.Structural
{
    // Adapter pattern include 4 actors
    // 1. Client call interface Target interface
    //2. Target interface is 1/ more abstract method that client will call
    //3. Adapter: contains adaptee/3-party service that we need to work with
    //4. Adaptee: service existed that we need to intergrate
    public interface IPrintTarget
    {
        void Print();
    }

    public class PrinterAdapter : IPrintTarget
    {
        private LegacyPrintServiceAdaptee _service;
        public PrinterAdapter(LegacyPrintServiceAdaptee service)
        {
            _service = service;
        }
        public void Print()
        {
            _service.PrintDocument();
        }
    }

    public class LegacyPrintServiceAdaptee
    {
        public void PrintDocument()
        {
            Console.WriteLine("Print Document in Legacy System");
        }
    }

    public class ClientAdapter
    {
        public static void MainRun(IPrintTarget printTarget)
        {
            printTarget.Print();
        }
    }
}
