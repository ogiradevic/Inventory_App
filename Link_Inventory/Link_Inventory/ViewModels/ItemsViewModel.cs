using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Models.Entities;

namespace Link_Inventory.ViewModels
{
    public class ItemsViewModel
    {
        public IEnumerable<Item> AllNonSerilizedItems { get; set; }
        public IEnumerable<SerializedItem> AllSerilizedItems { get; set; }
        public NonSerializedItemRoom NonSerializedItemRoom { get; set; }
        public NonSerializedItemRoom NonSerializedItemRoomDeduction { get; set; }
        public IEnumerable<NonSerializedItemRoom> AllNonSerializedItemsRooms { get; set; }
        public List<NonSerializedItemRoom> AllNonSerializedItemsRoomsById { get; set; }
        public ItemRoom NewItemRoom { get; set; }
        public List<ItemRoom> AllItemsRooms { get; set; }
        public Item Item { get; set; }
        public SerializedItem SerializedItem { get; set; }
        public int AmountPerRoom { get; set; }
        public int TotalAmountPerItemId { get; set; }
        public int ItemId { get; set; }
        public string ApplicationUserId { get; set; }
        public int Undefined { get; set; }
        public int SumAmountPerRoom { get; set; }
        public int Check { get; set; }
        public Dictionary<string, int> SumItemsRooms { get; set; }
        
        public Room Room { get; set; }
        public DateTime DateOfChange { get; set; }
        public ItemUser CurrentUser { get; set; }
        public Room CurrentRoom { get; set; }
        public IEnumerable<InvoiceItem> AllInvoiceItemsByItemId { get; set; }

    }
}
