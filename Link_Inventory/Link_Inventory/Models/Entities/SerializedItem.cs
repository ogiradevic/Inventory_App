using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_Inventory.Models.Entities
{
    public class SerializedItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public string SerialNumber { get; set; }
        public int SerializedItemConditionId { get; set; }
        public SerializedItemCondition SerializedItemCondition { get; set; }
        public int ItemUserId { get; set; }
        public ItemUser ItemUser { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int InvoiceItemId { get; set; }
        public InvoiceItem InvoiceItem { get; set; }
    }
}
