using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Data;
using Link_Inventory.Models.Entities;

namespace Link_Inventory.Models.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public InvoiceRepository( ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Invoice AddInvoice(Invoice invoice, int supplierId, int companyId)
        {
            Invoice newInvoice = new Invoice
            {
                InvoiceNumber = invoice.InvoiceNumber,
                IssueDate = invoice.IssueDate,
                DueDate = invoice.DueDate,
                SupplierId = supplierId,
                CompanyId = companyId
            };



            return newInvoice;


        }

        public Invoice GetInvoiceById(int invoiceId)
        {
            var invoice = _applicationDbContext.Invoices.Find(invoiceId);

            return invoice;
        }
    }
}
