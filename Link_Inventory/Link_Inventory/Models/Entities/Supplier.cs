using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_Inventory.Models.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UniqueCompanyNumber { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string AccountNumber { get; set; }
        public string ContactEmailAddress { get; set; }
    }
}
