using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part13Static.SingletonPattern
{
    public class Singleton
    {
        // Static field initializer calls instance constructor.
        private static Singleton instance = new Singleton();

        private Singleton()
        {
            Console.WriteLine("Executes before static constructor.");
        }

        static Singleton()
        {
            Console.WriteLine("Executes after instance constructor.");
        }

        public static Singleton Instance => instance;
    }

    //singleton non-safe thread and lazyloading
    public class AccessCouterNoThreadSafe
    {
        private static AccessCouterNoThreadSafe? _instance = null;
        private AccessCouterNoThreadSafe() 
        {
        }

        public static AccessCouterNoThreadSafe GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AccessCouterNoThreadSafe();
            }

            return _instance;
        }

    }


    //singleton safe thread 
    public class AccessCouterThreadSafe
    {
        private readonly static object _key = new();
        private static AccessCouterThreadSafe? _instance = null;
        private AccessCouterThreadSafe()
        {
        }

        public static AccessCouterThreadSafe GetInstance(string name)
        {
            if (_instance == null)
            {
                lock (_key)
                {
                    if (_instance == null)
                    {
                        _instance = new AccessCouterThreadSafe();
                        _instance.Value = name;
                    }
                }
            }
            return _instance;
        }

        public string? Value { get; set; }
    }
}
