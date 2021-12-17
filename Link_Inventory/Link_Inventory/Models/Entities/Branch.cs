using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_Inventory.Models.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}
