using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Data;
using Link_Inventory.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Link_Inventory.Models.Repositories
{
    public class NonSerializedItemRoomRepository : INonSerializedItemRoomRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public NonSerializedItemRoomRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<NonSerializedItemRoom> AllNonSerializedItemsRooms
        {
            get { return _applicationDbContext.NonSerializedItemRooms.Include(x => x.Room); }
        }

        public NonSerializedItemRoom AddNewNonSerializedItemRoom(int id, int roomToId, int roomFrom, int amountPerRoom, string appUserId)
        {
            /*CultureInfo cultureInfo = new CultureInfo("sr-Latn-RS", false);

            DateTime dt = DateTime.Parse(DateTime.Today.ToString(), cultureInfo);*/

            

            var newNonSerializedItemRoom = new NonSerializedItemRoom
            {
                ItemId = id,
                RoomId = roomToId,
                RoomFromId = roomFrom,
                AmountPerRoom = amountPerRoom,
                DateOfChange = DateTime.Today,
                ApplicationUserId = appUserId
            };

            if (newNonSerializedItemRoom != null)
            {
                _applicationDbContext.NonSerializedItemRooms.Add(newNonSerializedItemRoom);
                _applicationDbContext.SaveChanges();
            }

            return newNonSerializedItemRoom;
        }

        public List<NonSerializedItemRoom> AllNonSerliazidedItemsRoomsById(int idItem)
        {
            var nonSerializedItemsById =  _applicationDbContext.NonSerializedItemRooms.Where(x => x.ItemId == idItem).Include(m => m.Room).Include(a => a.ApplicationUser).Include(b =>b.Room.Branch).ToList();
            return nonSerializedItemsById;
        }

        public int GetSumPerRoomPerRoomId(int roomId)
        {
            var nonSerializedroomItems = _applicationDbContext.NonSerializedItemRooms.Where(x => x.RoomId == roomId);

            var listOfAllAmounts = new List<int>();

            foreach(var itemRooms in nonSerializedroomItems)
            {
                listOfAllAmounts.Add(itemRooms.AmountPerRoom);
            }

            var finalAmountperRoom = listOfAllAmounts.Sum();

            return finalAmountperRoom;
        }

        public NonSerializedItemRoom RoomAmountReduction(int roomFrom, int amount, string appUserId, int itemId)
        {
            var previousRooms = _applicationDbContext.NonSerializedItemRooms.Where(x => x.RoomId == roomFrom && x.ItemId == itemId).ToList();

            var room = previousRooms.FirstOrDefault();

            if(room != null)
            {
                room.AmountPerRoom = room.AmountPerRoom - amount;
                room.DateOfChange = DateTime.Now;
                room.ApplicationUserId = appUserId;
                if(room.AmountPerRoom >= 0)
                {
                  _applicationDbContext.NonSerializedItemRooms.Update(room);
                  _applicationDbContext.SaveChanges();
                }

            }

            return room;
        }

        public int SumAllItemsPerRoom(int itemId)
        {

            var amountsPerRoom =
                from aPr in _applicationDbContext.NonSerializedItemRooms
                where aPr.ItemId == itemId
                select aPr.AmountPerRoom;

            var sum = amountsPerRoom.Sum();

            return sum;


        }

        public Dictionary<string, int> SumPerRoom(int itemId)
        {

            var list = _applicationDbContext.NonSerializedItemRooms.Where(x => x.ItemId == itemId).Include(s => s.Room).ToList();

            var groups = new Dictionary<string, int>();

           foreach(var x in list)
           {
                if (!groups.ContainsKey(x.Room.Name))
                {
                    groups.Add(x.Room.Name, x.AmountPerRoom);
                }
                else
                {
                    int amountValue = groups[x.Room.Name];
                    groups[x.Room.Name] = amountValue + x.AmountPerRoom;
                }
           }



            return groups;

        
  


        }
    }
}
