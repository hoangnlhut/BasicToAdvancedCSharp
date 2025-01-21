using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._1stTime.Behavior
{

    // State is a behavioral design pattern that lets an object alter its behavior when its internal state changes. It appears as if the object changed its class.
    //Example for all posibilities of state pattern in buying a product in e-commerce
     // Created => Canncel
     //   |
     //   | => Paid => Delivered => Done.
    
    public class Context
    {
        private State _state;

        public Context(State state)
        {
            ChangeState(state);
        }

        public void ChangeState(State state)
        {
            _state = state;
            _state.SetContext(this);
        }


        public void Cancel()
        {
            _state.Cancel();
        }

        public void Paid()
        {
            _state.Paid();
        }

        public void Delivered()
        {
            _state.Delivered();
        }

        public void Done()
        {
            _state.Done();
        }
    }
    public abstract class State
    {
        protected Context _context;
        public void SetContext(Context context)
        {
            _context = context;
        }

        public abstract void Cancel();
        public abstract void Paid();
        public abstract void Delivered();
        public abstract void Done();
    }

    public class CancelledState : State
    {
        public override void Cancel()
        {
            throw new NotImplementedException("Can't not Cancel when you are in Cancel Status");
        }

        public override void Delivered()
        {
            throw new NotImplementedException("Can't not Delivered when you are in Cancel Status");
        }

        public override void Done()
        {
            throw new NotImplementedException("Can't not Done when you are in Cancel Status");
        }

        public override void Paid()
        {
            throw new NotImplementedException("Can't not Paid when you are in Cancel Status");
        }

    }

    public class CreatedState : State
    {
        public override void Cancel()
        {
            Console.WriteLine("Cancelling Order.");
            _context.ChangeState(new CancelledState());
        }
        public override void Paid()
        {
            Console.WriteLine("Custer is paying Order.");
            _context.ChangeState(new PaidState());
        }
        public override void Delivered()
        {
            throw new NotImplementedException("Can't Deliver if the customer do not pay for this order");
        }
        public override void Done()
        {
            throw new NotImplementedException("Can't Done If you can't payment and deliver product.");
        }
    }

    public class PaidState : State
    {
        public override void Cancel()
        {
            throw new NotImplementedException("Can't Cancel if the status is PaidState");
        }

        public override void Delivered()
        {
            Console.WriteLine("Paid Sucessfully. We will deliver order to customer");
            _context.ChangeState(new DeliveredState());
        }

        public override void Done()
        {
            throw new NotImplementedException("Can't Done if the status is PaidState");
        }

        public override void Paid()
        {
            throw new NotImplementedException("Can't Paid if the status is PaidState");
        }
    }

    public class DeliveredState : State
    {
        public override void Cancel()
        {
            throw new NotImplementedException("Can't Cancel if the status is DeliveredState");
        }

        public override void Delivered()
        {
            throw new NotImplementedException("Can't Cancel if the status is DeliveredState");
        }

        public override void Done()
        {
            Console.WriteLine("Delivered Successfully. THis's Order Done now.");
            _context.ChangeState(new DoneState());
        }

        public override void Paid()
        {
            throw new NotImplementedException("Can't Paid if the status is DeliveredState");
        }
    }

    public class DoneState : State
    {
        public override void Cancel()
        {
            throw new NotImplementedException("Can't Cancel if the status is DoneState");
        }

        public override void Delivered()
        {
            throw new NotImplementedException("Can't Delivered if the status is DoneState");
        }

        public override void Done()
        {
            throw new NotImplementedException("Can't Done if the status is DoneState");
        }

        public override void Paid()
        {
            throw new NotImplementedException("Can't Paid if the status is DoneState");
            //}


        }
    }
    
}
