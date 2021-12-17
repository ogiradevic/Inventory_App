using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_Inventory.Models.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public double PriceNoTax { get; set; }
        public string Description { get; set; }


    }
}
