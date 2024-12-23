using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part36_ParallelLINQ_ParallelProgramming.PLinqDataSample
{
    //How to: Control Ordering in a PLINQ Query: https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-control-ordering-in-a-plinq-query
    public class ControlOrderinginaPLINQQuery
    {
        public static void Example1()
        {
            var source = Enumerable.Range(9, 10000);

            // Source is ordered; let's preserve it.
            var parallelQuery =
                from num in source.AsParallel().AsOrdered()
                where num % 3 == 0
                select num;

            // Use foreach to preserve order at execution time.
            foreach (var item in parallelQuery)
            {
                Console.Write($"{item} ");
            }

            // Some operators expect an ordered source sequence.
            var lowValues = parallelQuery.Take(10);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Take 10 from parallel Query");
            lowValues.ForAll(x => Console.WriteLine(x));
        }

        // Paste into PLINQDataSample class.
        public static void SimpleOrdering()
        {
            var customers = PLINQDataSample.GetCustomers();

            // Take the first 20, preserving the original order
            var firstTwentyCustomers = customers
                                        .AsParallel()
                                        .AsOrdered()
                                        .Take(20);

            foreach (var c in firstTwentyCustomers)
                Console.Write("{0} ", c.CustomerID);

            // All elements in reverse order.
            var reverseOrder = customers
                                .AsParallel()
                                .AsOrdered()
                                .Reverse();

            foreach (var v in reverseOrder)
                Console.Write("{0} ", v.CustomerID);

            // Get the element at a specified index.
            var cust = customers.AsParallel()
                                .AsOrdered()
                                .ElementAt(48);

            Console.WriteLine("Element #48 is: {0}", cust.CustomerID);
        }

        // Paste into PLINQDataSample class.
        public static void OrderedThenUnordered()
        {

            var orders = PLINQDataSample.GetOrders();
            var orderDetails = PLINQDataSample.GetOrderDetails();

            var q2 = orders.AsParallel()
               .Where(o => o.OrderDate < DateTime.Parse("07/04/1997"))
               .Select(o => o)
               .OrderBy(o => o.CustomerID) // Preserve original ordering for Take operation.
               .Take(20)
               .AsUnordered()  // Remove ordering constraint to make join faster.
               .Join(
                      orderDetails.AsParallel(),
                      ord => ord.OrderID,
                      od => od.OrderID,
                      (ord, od) =>
                      new
                      {
                          ID = ord.OrderID,
                          Customer = ord.CustomerID,
                          Product = od.ProductID
                      }
                     )
               .OrderBy(i => i.Product); // Apply new ordering to final result sequence.

            foreach (var v in q2)
            {
                Console.WriteLine("{0} {1} {2}", v.ID, v.Customer, v.Product);
            }
        }

    }
}
