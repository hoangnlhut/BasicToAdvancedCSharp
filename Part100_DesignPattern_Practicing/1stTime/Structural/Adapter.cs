using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._1stTime.Structural
{
    //Adapter is a structural design pattern that allows objects with incompatible interfaces to collaborate.

    //2 ways: object adapter and class adapter

    #region object adapter : uses the object composition principle: the adapter implements the interface of one object and wraps the other one
    //Adaptee class (Service Class: 3rd-party or legacy)
    public class Sockets2LoCamDien : IOcam
    {
        public void PlugIn()
        {
            Console.WriteLine("Plug in the 2 lo cam dien");
        }
    }

    public class Sockets3LoCamDien : IOcam
    {
        public void PlugIn()
        {
            Console.WriteLine("Plug in the 2 lo cam dien");
        }
    }

    public interface IOcam
    {
        void PlugIn();
    }

    //Target interface
    public interface IClientInterface
    {
        void RequestPlugIn();
    }

    //Adapter class: bo chuyen doi
    public class AdapterOCamDien : IClientInterface
    {
        private readonly IOcam _sockets;
        public AdapterOCamDien(IOcam sockets)
        {
            _sockets = sockets;
        }
        public void RequestPlugIn()
        {
            _sockets.PlugIn();
        }
    }

    //Client class
    public class ClientInAdapter
    {
        private  IClientInterface _clientInterface;
        public ClientInAdapter(IClientInterface clientInterface)
        {
            _clientInterface = clientInterface;
        }
        public void MainClient()
        {
            _clientInterface.RequestPlugIn();
        }
    }
    #endregion
}
