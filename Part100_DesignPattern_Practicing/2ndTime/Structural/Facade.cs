using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part100_DesignPattern_Practicing._2ndTime.Structural
{
    // A common design goal is to minimize the communication and dependencies between subsystems.
    // instead customer / client have to work with directly so many service we will crete Facade as a only provider for client to request. Facade will how to call services with every request.

    // for example for booking a tourist. We have tourist agency as a facade with many packages from cheap to expensive to everywhere in the world
    public class RestaurantService
    {
        public void NonVegaterianMenu()
        {
            Console.WriteLine("Food with menu include meat dishes");
        }

        public void VegaterianMenu()
        {
            Console.WriteLine("Food with menu include vegetable dishes");
        }
    }

    public class RoomService
    {
        public void DeluxeRoom()
        {
            Console.WriteLine("You will be stay in deluxe room");
        }

        public void OrdinaryRoom()
        {
            Console.WriteLine("You will be stay in ordinary room");
        }
    }

    public class PlaneReserveService
    {
        public void BusinessClass()
        {
            Console.WriteLine("You will be flying in business class of plane");
        }

        public void NornalClass()
        {
            Console.WriteLine("You will be flying in nornal class of plane");
        }
    }

    public class TouristAgencyFacade
    {
        private RestaurantService _restaurant;
        private RoomService _room;
        private PlaneReserveService _plane;

        public TouristAgencyFacade(RestaurantService restaurantService, RoomService roomService , PlaneReserveService planeReserveService)
        {
            _restaurant = restaurantService;
            _room = roomService;
            _plane = planeReserveService;
        }

        public void CheapVacation()
        {
            Console.WriteLine("We will happy to booking for you a save-money vacation");
            _plane.NornalClass();
            _room.OrdinaryRoom();
            _restaurant.VegaterianMenu();
        }

        public void DeluxeVacation()
        {
            Console.WriteLine("We will happy to booking for you a deluxe vacation");
            _plane.BusinessClass();
            _room.DeluxeRoom();
            _restaurant.NonVegaterianMenu();
        }
    }

    public class ClientFacade2
    {
        public static void BookingCheapVacation() => new TouristAgencyFacade(new RestaurantService(), new RoomService(), new PlaneReserveService()).CheapVacation();
        public static void BookingDeluxeVacation() => new TouristAgencyFacade(new RestaurantService(), new RoomService(), new PlaneReserveService()).DeluxeVacation();
    }
}
