using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._2ndTime.Behavior
{
    // Instead you have to interact directly to your devices (TV, Fan...) to use what function you want ( turn on , off, volume up, down...) so you can use A command like Remote / smart device as an intermediary to access remoted to your devices

    public class TV
    {
        public void TurnOn()
        {
            Console.WriteLine("Turn On the TV");
        }

        public void TurnOff()
        {
            Console.WriteLine("Turn Off the TV");
        }

        public void VolumeUp()
        {
            Console.WriteLine("Turn The volume of TV up");
        }

        public void VolumeDown()
        {
            Console.WriteLine("Turn The volume of TV down");
        }
    }
    public interface ICommand
    {
        void Execute();
        void Undo();
    }


    public class TurnOnCommand : ICommand
    {
        private TV _tV;
        public TurnOnCommand(TV tV)
        {
            _tV = tV;
        }

        public void Execute()
        {
            _tV.TurnOn();
        }

        public void Undo()
        {
            _tV.TurnOff();
        }
    }

    public class TurnOffCommand : ICommand
    {
        private TV _tV;
        public TurnOffCommand(TV tV)
        {
            _tV = tV;
        }

        public void Execute()
        {
            _tV.TurnOff();
        }

        public void Undo()
        {
            _tV.TurnOn();
        }
    }

    public class VolumeUpCommand : ICommand
    {
        private TV _tV;
        public VolumeUpCommand(TV tV)
        {
            _tV = tV;
        }

        public void Execute()
        {
            _tV.VolumeUp();
        }

        public void Undo()
        {
            _tV.VolumeDown();
        }
    }

    public class VolumeDownCommand : ICommand
    {
        private TV _tV;
        public VolumeDownCommand(TV tV)
        {
            _tV = tV;
        }

        public void Execute()
        {
            _tV.VolumeDown();
        }

        public void Undo()
        {
            _tV.VolumeUp();
        }
    }

    public class RemoteTv
    {
        private ICommand _turnOn;
        private ICommand _turnOff;
        private ICommand _volumeUp;
        private ICommand _volumeDown;

        public RemoteTv(ICommand turnOn, ICommand turnOff , ICommand volumeUp, ICommand volumeDown)
        {
            _turnOn = turnOn;
            _turnOff = turnOff;
            _volumeDown = volumeDown;
            _volumeUp = volumeUp;
        }

        public void TurnOn()
        {
            _turnOn.Execute();
        }

        public void TurnOff()
        {
            _turnOff.Execute();
        }

        public void VolumeUp()
        {
            _volumeUp.Execute();
        }

        public void VolumeDown()
        {
            _volumeDown.Execute();
        }
    }

    public class ClientCommand2
    {
        public static void MainCommand()
        {
            TV tV = new TV();
            RemoteTv remoteTv = new RemoteTv(new TurnOnCommand(tV), new TurnOffCommand(tV), new VolumeUpCommand(tV), new VolumeDownCommand(tV));
          
            remoteTv.TurnOn();
            remoteTv.VolumeUp();
            remoteTv.VolumeDown();
            remoteTv.TurnOff();

        }
    }
}
