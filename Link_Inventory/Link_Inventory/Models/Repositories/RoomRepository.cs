using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Data;
using Link_Inventory.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Link_Inventory.Models.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RoomRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<Room> AllRooms
        {
            get { return _applicationDbContext.Rooms.Include(b => b.Branch).Include(c =>c.RoomCategoryType); }
        }

        public Room GetRoomById(int id)
        {
            var room = _applicationDbContext.Rooms.Find(id);

            return room;
        }

        public int GetRoomIdByName()
        {
            var room = _applicationDbContext.Rooms.First(x => x.Name == "Prostorija nije odredena");
            int roomId = room.Id;
            return roomId;
        }
    }
}
