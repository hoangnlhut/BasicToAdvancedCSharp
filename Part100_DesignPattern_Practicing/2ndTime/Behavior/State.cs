using Part100_DesignPattern_Practicing._1stTime.Behavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._2ndTime.Behavior
{
    // This pattern was use in situations that related to states that when have a change on states It will let an object change It's behavior
    // such as order flow in ecommercial 
    // created => cancelled
    // || => paid => delivered => done

    //This pattern focuses on managing state transitions and coordinating state-specific behaviors.


    public abstract class State2
    {
        protected Context _context;

        public void SetContext(Context context) => _context = context;

        public abstract void Cancel();
        public abstract void Paid();
        public abstract void Delivered();
        public abstract void Done();
    }


    public class CreatedState2 : State2
    {
        public override void Cancel()
        {
            Console.WriteLine("You're going to cancel your order");
            _context.ChangeState(new CancelledState2());
        }

        public override void Paid()
        {
            Console.WriteLine("You're going to paid your order");
            _context.ChangeState(new PaidState2());
        }

        public override void Delivered()
        {
            throw new NotImplementedException("You're in CreateState");
        }

        public override void Done()
        {
            throw new NotImplementedException("You're in CreateState");
        }

       
    }

    public class PaidState2 : State2
    {
        public override void Cancel()
        {
            throw new NotImplementedException("You're in PaidState");
        }

        public override void Paid()
        {
            throw new NotImplementedException("You're in PaidState");
        }

        public override void Delivered()
        {
            Console.WriteLine("The products are delivering to you");
            _context.ChangeState(new DeliveredState2());
        }

        public override void Done()
        {
            throw new NotImplementedException("You're in PaidState");
        }
    }

    public class DeliveredState2 : State2
    {
        public override void Cancel()
        {
            throw new NotImplementedException("You're in DeliveredState");
        }

        public override void Paid()
        {
            throw new NotImplementedException("You're in DeliveredState");
        }

        public override void Delivered()
        {
            throw new NotImplementedException("You're in DeliveredState");
        }

        public override void Done()
        {
            Console.WriteLine("You done your order");
            _context.ChangeState(new DoneState2());
        }
    }

    public class DoneState2 : State2
    {
        public override void Cancel()
        {
            throw new NotImplementedException("You're in DoneState");
        }

        public override void Paid()
        {
            throw new NotImplementedException("You're in DoneState");
        }

        public override void Delivered()
        {
            throw new NotImplementedException("You're in DoneState");
        }

        public override void Done()
        {
            throw new NotImplementedException("You're in DoneState");
        }
    }

    public class CancelledState2 : State2
    {
        public override void Cancel()
        {
            throw new NotImplementedException("You're in CancelledState");
        }

        public override void Paid()
        {
            throw new NotImplementedException("You're in CancelledState");
        }

        public override void Delivered()
        {
            throw new NotImplementedException("You're in CancelledState");
        }

        public override void Done()
        {
            throw new NotImplementedException("You're in CancelledState");
        }
    }

    public class Context
    {
        private State2 _state;
        public Context(State2 state)
        {
            ChangeState(state);
        }
        public void ChangeState(State2 state)
        {
            Console.WriteLine($"Context: Change to {state.GetType().Name}");
            _state = state;
            _state.SetContext(this);
        }

        public  void Cancel()
        {
            _state.Cancel();
        }
        public  void Paid()
        {
            _state.Paid();
        }
        public  void Delivered()
        {
            _state.Delivered();
        }
        public void Done()
        {
            _state.Done();
        }
    }

    // Client only know Context and concreate state

    public class MainState2
    {
        public static void Main2()
        {
            Context context = new Context(new CreatedState2());

            //context.Cancel();
            //context.Paid();

            //context.ChangeState(new CreatedState2());
            context.Paid();
            context.Delivered();
            context.Done();
        }
    }
}


// Conclude 
// 1. Context:  contain reference of state through interface state. This class also have method about change state same as interface state 
// 2. State (abstract / interface) : contain method relate to change state that sub-class inherit 
// 3. Concreate State: inherits from abstract state to have specific implementation for each state
// 4. Client: only know Context and the first state to initiate and then when change state is use method of context