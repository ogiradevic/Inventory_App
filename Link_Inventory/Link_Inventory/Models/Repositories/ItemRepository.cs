using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Data;
using Link_Inventory.Models.Entities;

namespace Link_Inventory.Models.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ItemRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Item> NonSerializedItems
        {
            get { return _applicationDbContext.Items.Where(x => x.ItemTypeId == 2); }
        }

        IEnumerable<Item> IItemRepository.AllItems
        {
            get { return _applicationDbContext.Items; }
        }

        public Item GetItemById(int id)
        {
            var item = _applicationDbContext.Items.Find(id);
            return item;
        }

        public int GetTypeIdByItemId(int id)
        {
            var item = _applicationDbContext.Items.First(x => x.Id == id);

            int typeId = item.ItemTypeId;
            return typeId;
        }

        public Item UpdateItem(int itemId, int amount)
        {
            var item = _applicationDbContext.Items.Find(itemId);

   
            item.Amount += amount;

            if (item != null)
            {
                _applicationDbContext.Items.Update(item);
                _applicationDbContext.SaveChanges();
            }

            return item;
        }
    }
}
