using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part29_Reflection.Pluralsight.IoCContainer
{
    public class CoffeeService : ICoffeeService
    {
        //public CoffeeService()
        //{
            
        //}
        public CoffeeService(IWaterService waterService)
        {
            
        }
         
        public CoffeeService(IWaterService waterService, IBeanService<Catimor> beanService)
        {

        }



    }

    public class TapWaterService : IWaterService { }

    public class ArabicaBeanService<T> : IBeanService<T>
    {

    }

    public class Catimor
    {

    }
}
