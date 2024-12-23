using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part36_ParallelLINQ_ParallelProgramming.PLinqDataSample
{
    public class SequenceDemo
    {
        public static void SequentialDemo()
        {
            var orders = PLINQDataSample.GetOrders();
            var query = (from order in orders.AsParallel()
                         orderby order.OrderID
                         select new
                         {
                             order.OrderID,
                             OrderedOn = order.OrderDate,
                             ShippedOn = order.ShippedDate
                         })
                         .AsSequential().Take(5);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
}
