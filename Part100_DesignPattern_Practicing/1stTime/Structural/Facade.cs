using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._1stTime.Structural
{
    // Facade is a structural design pattern that provides a simplified (but limited) interface to a complex system of classes, library or framework.

    #region Subsystems
    public class EmailService
    {
        public string GetEmail(string name)
        {
            return $"Email: {name}.@topica.com";
        }
    }

    public class OrderService
    {
        public string GetOrder(string name)
        {
            return $"{name} have some orders in Z Shops ";
        }
    }

    public class PaymentService
    {
        public string PaymentCash(string name)
        {
            return $"{name} would like to pay in cash in Z Shops ";
        }
    }
    #endregion

    #region facade
    public class Facade
    {
        private EmailService _emailService;
        private OrderService _orderService;
        private PaymentService _paymentService;
        public Facade()
        {
            _emailService = new EmailService();
            _orderService = new OrderService();
            _paymentService = new PaymentService();
        }
        public string GetFullInfo(string name)
        {
            string email = _emailService.GetEmail(name);
            string order = _orderService.GetOrder(name);
            string payment = _paymentService.PaymentCash(name);
            return $"{email} \n {order} \n {payment}";
        }
    }
    #endregion

    #region Client
    public class ClientFacade
    {
        public static void MainClientFacade()
        {
            Facade facade = new Facade();
            Console.WriteLine(facade.GetFullInfo("John"));
        }
    }
    #endregion
}
