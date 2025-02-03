using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._2ndTime.Behavior
{
    //4 components:
    //1. Subject: is an interface include add , remove and notify message
    //2. Concreate Subject: contain a list of subcriver and with detail implementation to add / remove and notify messafe for concreate observer
    //3. IObserver is an interface only have one method is notify message
    //4. Concreate Observer is many observer were notify when state was change

    public interface ISubject
    {
        void AddObservers(IObserver observer);
        void RemoveObservers(IObserver observer);
        void Notify(string message);
    }

    public class WeatherSubject : ISubject
    {
        private List<IObserver> _list = new List<IObserver>();
     
        public void AddObservers(IObserver observer)
        {
            Console.WriteLine("Adding new device.......");
            _list.Add(observer);
        }

        public void Notify(string message)
        {
            foreach (var item in _list)
            {
                item.Update(message);
            }
        }

        public void RemoveObservers(IObserver observer)
        {
            Console.WriteLine("Removing new device.......");
            _list.Remove(observer);
        }
    }

    public interface IObserver
    {
        void Update(string message);
    }

    public class SmartPhoneObserver : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"Message {message} was sent to your smartphone");
        }
    }

    public class ComputerObserver : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"Message {message} was sent to your computer");
        }
    }

    public class ServerObserver : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"Message {message} was sent to your server");
        }
    }

    public class ClientObserver2
    {
        public static void WarningStorm()
        {
            ISubject weatherNotifier = new WeatherSubject();
            weatherNotifier.AddObservers(new SmartPhoneObserver());
            weatherNotifier.AddObservers(new ComputerObserver());

            var server = new ServerObserver();
            weatherNotifier.AddObservers(server);

            weatherNotifier.Notify("Storm warning");
            weatherNotifier.RemoveObservers(server);
        }

        public static void RecommentToGoOut()
        {
            ISubject weatherNotifier = new WeatherSubject();
            weatherNotifier.AddObservers(new SmartPhoneObserver());
            weatherNotifier.AddObservers(new ComputerObserver());
            weatherNotifier.AddObservers(new ServerObserver());

            weatherNotifier.Notify("The weather is so cool. Let get out your house to enjoy it");
        }
    }
}
