using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._2ndTime.Creational
{
    //Singleton no-thread safe
    public sealed class SingletonNoThread
    {
        private static SingletonNoThread? _instance = null;
        private SingletonNoThread() { }

        public string Value { get; set; }
        public static SingletonNoThread GetInstance(string value)
        {
            if (_instance == null)
            {
                _instance = new SingletonNoThread();
                _instance.Value = value;
            }
           
            return _instance;
        }

    }

    //Singleton thread safe
    public sealed class SingletonThreadSafe2
    {
        private static SingletonThreadSafe2? _instance = null;
        private static readonly object _lock = new object();
        private SingletonThreadSafe2() { }

        public string Value { get; set; }
        public static SingletonThreadSafe2 GetInstance(string value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonThreadSafe2();
                        _instance.Value = value;
                    }
                }
            }
          
            return _instance;
        }

    }
}
