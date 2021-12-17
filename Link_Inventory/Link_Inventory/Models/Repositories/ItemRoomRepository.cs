using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Data;
using Link_Inventory.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Link_Inventory.Models.Repositories
{
    public class ItemRoomRepository : IItemRoomRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ItemRoomRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<ItemRoom> AllItemsRooms
        {
            get { return _applicationDbContext.ItemsRooms.Include(x => x.Room).Include(a=>a.ApplicationUser); }
        }

        public ItemRoom AddInitialItemRoom(int serializedItemId, int roomId, DateTime initialInputDate, int itemUserId, string appUserId)
        {


            var initialItemroom = new ItemRoom
            {
                SerializedItemId = serializedItemId,
                RoomId = roomId,
                ItemUserId = itemUserId,
                ApplicationUserId = appUserId
            };

            if (initialItemroom != null)
            {
                _applicationDbContext.ItemsRooms.Add(initialItemroom);
                _applicationDbContext.SaveChanges();
            }

            return initialItemroom;
        }

        public ItemRoom AddNewSerializedItemRoom(int serializedItemId, int currentRoomId, int roomToId, int itemUserId, string appUserId)
        {

            var itemRoom = new ItemRoom
            {
                SerializedItemId = serializedItemId,
                RoomFromId = currentRoomId,
                RoomId = roomToId,
                ItemUserId = itemUserId,
                DateOfChange = DateTime.Today,
                ApplicationUserId = appUserId
            };

            if (itemRoom != null)
            {
                _applicationDbContext.ItemsRooms.Add(itemRoom);
                _applicationDbContext.SaveChanges();
            }

            return itemRoom;
        }

    }
}
