using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_Inventory.Models.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public int ItemTypeId { get; set; }

        public ItemType ItemType { get; set; }

        public int Amount { get; set; } 
    }
}
