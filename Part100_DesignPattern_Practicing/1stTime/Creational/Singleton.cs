using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._1stTime.Creational
{
    public class SingletonNonSafeThread
    {
        private static SingletonNonSafeThread? _instance = null;

        // unable to initiate by Construtor
        private SingletonNonSafeThread() { }

        public static SingletonNonSafeThread GetInstance()
        {
            if (_instance == null) _instance = new SingletonNonSafeThread();

            return _instance;
        }

    }

    public class SingletonThreadSafe
    {
        private static SingletonThreadSafe? _instance = null;
        private static readonly object _lock = new object();

        public string Name { get; set; }

        // unable to initiate by Construtor
        private SingletonThreadSafe() { }
        public static SingletonThreadSafe GetInstance(string name)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonThreadSafe();
                        _instance.Name = name;
                    }
                }
            }
           
            return _instance;
        }
    }

}
