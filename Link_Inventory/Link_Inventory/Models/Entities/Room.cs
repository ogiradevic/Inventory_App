using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_Inventory.Models.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BranchId { get; set; }

        public Branch Branch { get; set; }

        public int RoomCategoryTypeId { get; set; }
        public RoomCategoryType RoomCategoryType { get; set; }
    }
}
