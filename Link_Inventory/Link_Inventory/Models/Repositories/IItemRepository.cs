using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Models.Entities;

namespace Link_Inventory.Models.Repositories
{
    public interface IItemRepository
    {
        IEnumerable<Item> AllItems { get;  }
        Item UpdateItem(int itemId, int amount);

        IEnumerable<Item> NonSerializedItems { get; }

        Item GetItemById(int id);

        int GetTypeIdByItemId(int id);
    }
}
