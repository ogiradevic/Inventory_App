using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Models.Entities;

namespace Link_Inventory.Models.Repositories
{
    public interface IItemUserRepository
    {
        ItemUser GetItemUserBySerializedItemId(int id);

        IEnumerable<ItemUser> AllItemsUsers { get; }

        Room GetRoomBySerializedItemId(int id);
    }
}
