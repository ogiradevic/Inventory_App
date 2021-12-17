using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Data;

namespace Link_Inventory.Models.Entities
{
    public class NonSerializedItemRoom
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int RoomFromId { get; set; }
        public Room RoomFrom { get; set; }
        public DateTime DateOfChange { get; set; }
        public int AmountPerRoom { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
