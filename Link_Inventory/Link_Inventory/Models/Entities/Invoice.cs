using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_Inventory.Models.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
