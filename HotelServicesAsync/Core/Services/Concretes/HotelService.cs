using Core.DataAccessLayer;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Concretes
{
    public class HotelService
    {
        public async Task AddHotel(Hotel hotel)
        {
            await Task.Run(() =>
            {
                AppDb.Hotels.Add(hotel);
            });
        }
        public async Task RemoveHotel(int id)
        {
            await Task.Run(() =>
            {
                AppDb.Hotels.Remove(AppDb.Hotels.Find(item => item.Id == id));
            });
        }

        public async Task GetAllHotels()
        {
            await Task.Run(() =>
            {
                AppDb.Hotels.ForEach(item => Console.WriteLine(item));
            });
        }

        public async Task ChooseHotel(int id)
        {
            await Task.Run(() =>
            {
                AppDb.Hotels.Find(item => item.Id == id);
            });
        }
    }
}
