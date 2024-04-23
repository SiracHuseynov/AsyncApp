using Core.DataAccessLayer;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Concretes
{
    public class RoomService
    {
        public async Task AddRoom(Room room)
        {
            await Task.Run(() =>
            {
                AppDb.Rooms.Add(room);
            });
        }

        public async Task RemoveRoom(int id)
        {
            await Task.Run(() =>
            {
                AppDb.Rooms.Remove(AppDb.Rooms.Find(item => item.Id == id));

            });
        }

        public async Task GetAllRooms()
        {
            await Task.Run(() =>
            {
                AppDb.Rooms.ForEach(item => Console.WriteLine(item));
            });
        }

    }
}
