using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_Inventory.Models.Entities
{
    public class ItemUser
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
