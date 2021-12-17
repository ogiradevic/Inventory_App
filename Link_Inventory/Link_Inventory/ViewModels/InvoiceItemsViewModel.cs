using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Models.Entities;

namespace Link_Inventory.ViewModels
{
    public class InvoiceItemsViewModel
    {
        public Invoice Invoice { get; set; }
        public IEnumerable<Supplier> AllSuppliers { get; set; }
        public IEnumerable<Company> AllCompanies { get; set; }
        public IEnumerable<Item> AllItems { get; set; }
        public List<SerializedItem> NewSerializedItems { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public Item Item { get; set; }
        public int InvoiceId { get; set; }
        public InvoiceItem InvoiceItem { get; set; }
        public IEnumerable<InvoiceItem> InvoiceItemsByInvoiceId { get; set; }

        public bool SuccessfullyRemovedInvoiceItem { get; set; }
    }
}
