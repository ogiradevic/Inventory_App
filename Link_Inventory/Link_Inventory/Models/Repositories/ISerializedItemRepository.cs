using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Models.Entities;

namespace Link_Inventory.Models.Repositories
{
    public interface ISerializedItemRepository
    {
        List<SerializedItem> NewSerializedItems(int itemId, int amount, int invoiceItemId);
        IEnumerable<SerializedItem> AllSerializedItems { get; }
        SerializedItem GetSerializedItemById(int id);

        SerializedItem UpdateCurrentRoomOfSerializedItem(int serializedItemId, int newRoomId);

        SerializedItem UpdateCurrentUserOfSerializedItem(int serializedItemId, int itemUserId);

        SerializedItem UpdateSerialNumber(int serializedItemId, string serialNumber);


    }
}
