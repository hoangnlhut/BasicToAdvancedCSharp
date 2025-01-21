using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._1stTime.Behavior
{
    // Observer Pattern is a behavioral design pattern that lets you define a subscription mechanism to notify multiple objects about any events that happen to the object they’re observing.   
    public interface ISubcriber
    {
        void Notify(string message);
    }

    public class SubcriberA : ISubcriber
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Sending new messages of new product for sub A: {message}");
        }
    }

    public class SubcriberB : ISubcriber
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Sending new messages of new product for sub B: {message}");
        }
    }


    public class Publisher
    {
        private List<ISubcriber> _subcribers = new List<ISubcriber>();

        public void AddSubcriber(ISubcriber subcriber)
        {
            _subcribers.Add(subcriber);
        }

        public void RemoveSubcriber(ISubcriber subcriber)
        {
            _subcribers.Remove(subcriber);
        }

        public void NotifySubcribers(string message)
        {
            foreach (var subcriber in _subcribers)
            {
                subcriber.Notify(message);
            }
        }

        public void SendMassageNewVinFastCar()
        {
            NotifySubcribers("New Car - Vinfast VF10 is available");
        }

        public void SendMassageLatestIPhone()
        {
            NotifySubcribers("Brand new mode of Iphone is available");
        }

        public void SendMassageLatestLaptopWindownOS()
        {
            NotifySubcribers("Brand new laption in WindowOs is available");
        }
    }

    public class ClientObserver()
    {
        public static void MainClient()
        {
            Publisher publisher = new Publisher();
            ISubcriber subcriberA = new SubcriberA();
            ISubcriber subcriberB = new SubcriberB();
            publisher.AddSubcriber(subcriberA);
            publisher.AddSubcriber(subcriberB);
            publisher.SendMassageNewVinFastCar();
            publisher.SendMassageLatestIPhone();

            publisher.RemoveSubcriber(subcriberA);
            publisher.SendMassageLatestLaptopWindownOS();
        }

    }
}

