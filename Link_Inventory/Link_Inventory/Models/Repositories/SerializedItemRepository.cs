using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Data;
using Link_Inventory.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Link_Inventory.Models.Repositories
{
    public class SerializedItemRepository : ISerializedItemRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IItemRepository _itemRepository;

        public SerializedItemRepository(ApplicationDbContext applicationDbContext, IItemRepository itemRepository )
        {
            _applicationDbContext = applicationDbContext;
            _itemRepository = itemRepository;
        }

        public IEnumerable<SerializedItem> AllSerializedItems
        {
            get { return _applicationDbContext.SerializedItems.Include(x => x.Item).Include(i=> i.InvoiceItem.Invoice); }
        }

        public SerializedItem GetSerializedItemById(int id)
        {
            var serializedItem = _applicationDbContext.SerializedItems.Find(id);
            serializedItem.Item = _itemRepository.GetItemById(serializedItem.ItemId);
            return serializedItem;
        }

        public List<SerializedItem> NewSerializedItems(int itemId, int amount, int invoiceItemId)
        {
            List<SerializedItem> newSerializedItems = new List<SerializedItem>();
            while (amount > 0)
            {
                var serializedItem = new SerializedItem
                {
                    ItemId = itemId,
                    SerialNumber = "Nedefinisan serijski broj",
                    SerializedItemConditionId = 1, 
                    ItemUserId = 1,
                    RoomId = 1,
                    InvoiceItemId = invoiceItemId
                };

                if(serializedItem != null)
                {
                    newSerializedItems.Add(serializedItem);
                }

                amount--;

            }

            _applicationDbContext.SerializedItems.AddRange(newSerializedItems);
            _applicationDbContext.SaveChanges();

            return newSerializedItems;
        }

        public SerializedItem UpdateCurrentRoomOfSerializedItem(int serializedItemId, int newRoomId)
        {
            var serializedItem = _applicationDbContext.SerializedItems.Find(serializedItemId);

            serializedItem.RoomId = newRoomId;
            if(serializedItem != null)
            {
                _applicationDbContext.SerializedItems.Update(serializedItem);
                _applicationDbContext.SaveChanges();
            }

            return serializedItem;
        }

        public SerializedItem UpdateCurrentUserOfSerializedItem(int serializedItemId, int itemUserId)
        {
            var serializedItem = _applicationDbContext.SerializedItems.Find(serializedItemId);

            serializedItem.ItemUserId = itemUserId;
            if (serializedItem != null)
            {
                _applicationDbContext.SerializedItems.Update(serializedItem);
                _applicationDbContext.SaveChanges();
            }

            return serializedItem;
        }

        public SerializedItem UpdateSerialNumber(int serializedItemId, string serialNumber)
        {
            var serializedItem = _applicationDbContext.SerializedItems.Find(serializedItemId);

            serializedItem.SerialNumber = serialNumber;

            if(serializedItem != null)
            {
                _applicationDbContext.SerializedItems.Update(serializedItem);
                _applicationDbContext.SaveChanges();
            }

            return serializedItem;
        }
    }
}
