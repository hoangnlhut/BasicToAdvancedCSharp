using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._1stTime.Behavior
{
    //Command is a behavioral design pattern that turns a request into a stand-alone object that contains all information about the request. This transformation lets you parameterize methods with different requests, delay or queue a request’s execution, and support undoable operations.
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class TurnOnCommander : ICommand
    {
        private TVBoard _receiver;
        public TurnOnCommander(TVBoard receiver)
        {
            _receiver = receiver;
        }
        public void Execute()
        {
            _receiver.TurnOn();
        }
        public void Undo()
        {
            _receiver.TurnOff();
        }
    }
    public class TurnOffCommander : ICommand
    {
        private TVBoard _receiver;
        public TurnOffCommander(TVBoard receiver)
        {
            _receiver = receiver;
        }
        public void Execute()
        {
            _receiver.TurnOff();
        }
        public void Undo()
        {
            _receiver.TurnOn();
        }
    }

    public class Channel6Commander : ICommand
    {
        private TVBoard _receiver;
        public Channel6Commander(TVBoard receiver)
        {
            _receiver = receiver;
        }
        public void Execute()
        {
            _receiver.Channel6();
        }
        public void Undo()
        {
            _receiver.Channel5();
        }
    }

    public class Channel5Commander : ICommand
    {
        private TVBoard _receiver;
        public Channel5Commander(TVBoard receiver)
        {
            _receiver = receiver;
        }
        public void Execute()
        {
            _receiver.Channel5();
        }
        public void Undo()
        {
            _receiver.Channel6();
        }
    }

    public class TVBoard
    {
        public void TurnOn()
        {
            Console.WriteLine("Turned On");
        }
        public void TurnOff()
        {
            Console.WriteLine("Turned Off");
        }

        public void Channel5()
        {
            Console.WriteLine("Watching Channel 5");
        }
        public void Channel6()
        {
            Console.WriteLine("Watching Channel 6");
        }
    }

    public class Remote
    {
        private ICommand _turnOnCommand;
        private ICommand _turnOffCommand;
        private ICommand _channel5Command;
        private ICommand _channel6Command;

        public Remote()
        {
        }

        public void SetTurnOnCommand(ICommand turnOnCommand)
        {
            _turnOnCommand = turnOnCommand;
        }

        public void SetTurnOffCommand(ICommand turnOffCommand)
        {
            _turnOffCommand = turnOffCommand;
        } 

        public void SetChannel5Command(ICommand channel5)
        {
            _channel5Command = channel5;
        }

        public void SetChannel6Command(ICommand channel6)
        {
            _channel6Command = channel6;
        }

        public void TurnOn()
        {
            _turnOnCommand.Execute();
        }

        public void TurnOff()
        {
            _turnOffCommand.Execute();
        }

        public void Channel5()
        {
            _channel5Command.Execute();
        }


        public void Channel6()
        {
            _channel6Command.Execute();
        }

        public void UndoChannel6()
        {
            _channel6Command.Undo();
        }
    }

    public class ClientCommand
    {
        public static void Run()
        {
            TVBoard tvBoard = new TVBoard();
            Remote remote = new Remote();
            remote.SetTurnOnCommand(new TurnOnCommander(tvBoard));
            remote.SetTurnOffCommand(new TurnOffCommander(tvBoard));
            remote.SetChannel5Command(new Channel5Commander(tvBoard));
            remote.SetChannel6Command(new Channel6Commander(tvBoard));
            remote.TurnOn();
            remote.Channel5();
            remote.Channel6();
            remote.UndoChannel6();
            remote.TurnOff();
        }
    }

}
