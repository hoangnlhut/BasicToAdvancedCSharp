using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part98_Delegate_And_Event.Closure
{
    public class ClosureTest
    {
        public static void ResultAsNotExpected()
        {
            List<Action> actions = new List<Action>();
            for (int i = 0; i < 10; i++) {
                actions.Add(() => Console.WriteLine(i));
            }

            foreach (Action item in actions)
            {
                item();
            }
        }

        public static void ResultAsExpected()
        {
            List<Action> actions = new List<Action>();
            for (int i = 0; i < 10; i++)
            {
                int copy = i;
                actions.Add(() => Console.WriteLine(copy));
            }

            foreach (Action item in actions)
            {
                item();
            }
        }

        public Func<int> Count()
        {
            int count= 0;
            return () =>
            {
                count++;
                return count;
            };
        }

    }
}
