using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Models.Entities;

namespace Link_Inventory.Models.Repositories
{
    public interface IItemRoomRepository
    {
        ItemRoom AddInitialItemRoom(int serializedItemId, int roomId, DateTime initialInputDate, int itemUserId, string appUserId);

        IEnumerable<ItemRoom> AllItemsRooms { get; }

        ItemRoom AddNewSerializedItemRoom(int serializedItemId, int currentRoomId, int roomToId, int itemUserId, string appUserId);


    }
}
