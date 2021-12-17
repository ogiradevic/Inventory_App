using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_Inventory.Models.Entities
{
    public class NonSerializedItemWriteOff
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Amount { get; set; }
        public Item Item { get; set; }
        public int ItemRoomId { get; set; }
        public ItemRoom ItemRoom { get; set; }
        public string Description { get; set; }
    }
}
