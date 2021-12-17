using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Models.Entities;

namespace Link_Inventory.Models.Repositories
{
    public interface INonSerializedItemRoomRepository
    {
        IEnumerable<NonSerializedItemRoom> AllNonSerializedItemsRooms { get; }
        NonSerializedItemRoom AddNewNonSerializedItemRoom(int itemId, int roomToId, int roomFrom, int amountPerRoom, string appUserId);
        int SumAllItemsPerRoom(int itemId);
        List<NonSerializedItemRoom> AllNonSerliazidedItemsRoomsById(int itemId);
        Dictionary<string, int> SumPerRoom(int idItem);
        NonSerializedItemRoom RoomAmountReduction(int roomFrom, int amount, string appUserId, int itemId);
        int GetSumPerRoomPerRoomId(int roomId);



    }
}
