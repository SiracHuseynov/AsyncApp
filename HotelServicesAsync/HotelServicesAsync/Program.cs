using Core.Services.Concretes;
using System.ComponentModel.Design;
using Core.Enums;
using Core.Models;
using Core.DataAccessLayer;

namespace HotelServicesAsync
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HotelService hotelService = new HotelService();
            RoomService roomService = new RoomService();

            bool check = false;
            bool subcheck = false;
            int choice;
            string hotelName;
            int hotelId;
            string roomName;
            double roomPrice;
            int roomId;

            do
            {
                Console.WriteLine("1.Hotel yarat");
                Console.WriteLine("2.Hotel sil");
                Console.WriteLine("3.Butun hotelleri gor");
                Console.WriteLine("4.Hotel sec");
                Console.WriteLine("0.Exit");

                do
                {
                    Console.Write("Secim edin: ");
                }
                while (!int.TryParse(Console.ReadLine(), out choice));

                switch (choice)
                {
                    case (byte)Menu.AddHotel:
                        Console.Write("Hotel adi daxil edin: ");
                        hotelName = Console.ReadLine();

                        Hotel hotel = new Hotel(hotelName);
                        await hotelService.AddHotel(hotel);
                        break;
                    case (byte)Menu.RemoveHotel:
                        do
                        {
                            Console.Write("Silmek istediyiniz hotel id daxil edin: ");
                        }
                        while (!int.TryParse(Console.ReadLine(), out hotelId));
                        await hotelService.RemoveHotel(hotelId);
                        break;
                    case (byte)Menu.GetAllHotels:
                        await hotelService.GetAllHotels();
                        break;
                    case (byte)Menu.ChooseHotel:
                        do
                        {
                            Console.Write("Secmek istediyiniz hotel id daxil edin: ");
                        }
                        while (!int.TryParse(Console.ReadLine(), out hotelId));
                        await hotelService.ChooseHotel(hotelId);

                        bool exist = AppDb.Hotels.Exists(item => item.Id == hotelId);

                        if (exist)
                        {
                            do
                            {
                                do
                                {
                                    Console.WriteLine("1.Room yarat");
                                    Console.WriteLine("2.Room sil");
                                    Console.WriteLine("3.Butun roomlari gor");
                                    Console.WriteLine("0.Evvelki menu qayit");
                                    Console.Write("Secim edin: ");
                                }
                                while (!int.TryParse(Console.ReadLine(), out choice));

                                switch (choice)
                                {
                                    case (byte)SubMenu.AddRoom:
                                        Console.WriteLine("Room adi daxil edin: ");
                                        roomName = Console.ReadLine();
                                        do
                                        {
                                            Console.WriteLine("Room price daxil edin: ");
                                        }
                                        while (!double.TryParse(Console.ReadLine(), out roomPrice));

                                        Room room = new Room(roomName, roomPrice);
                                        await roomService.AddRoom(room);
                                        break;
                                    case (byte)SubMenu.RemoveRoom:
                                        do
                                        {
                                            Console.Write("Silmek istediyiniz room id daxil edin: ");
                                        }
                                        while (!int.TryParse(Console.ReadLine(), out roomId));
                                        await roomService.RemoveRoom(hotelId);
                                        break;
                                    case (byte)SubMenu.GetAllRooms:
                                        await roomService.GetAllRooms();
                                        break;
                                    case (byte)SubMenu.Exit:
                                        subcheck = true;
                                        break;
                                }
                            }
                            while (!subcheck);
                        }
                        else
                        {
                            Console.WriteLine($"{hotelId} deye id yoxdur!");
                        }

                        break;
                    case (byte)Menu.Exit:
                        check = true;
                        break;

                }

            }
            while (!check);
        }
    }
}
