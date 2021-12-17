using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Data;

namespace Link_Inventory.Models.Entities
{
    public class ItemRoom
    {
        public int Id { get; set; }

        public int SerializedItemId { get; set; }

        public SerializedItem SerializedItem { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }

        public int RoomFromId { get; set; }

        public Room RoomFrom { get; set; }

        public DateTime DateOfChange { get; set; }
        public int ItemUserId { get; set; }
        public ItemUser ItemUser { get; set; }
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
