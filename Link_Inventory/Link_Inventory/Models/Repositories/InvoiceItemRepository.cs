using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Data;
using Link_Inventory.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Link_Inventory.Models.Repositories
{
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public InvoiceItemRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<InvoiceItem> AllInvoiceItems
        {
            get { return _applicationDbContext.InvoiceItems.Include(x => x.Item).Include(n => n.Invoice); }
        }

        public InvoiceItem AddInvoiceItem(int invoiceId, int itemId, double price, int amount)
        {
            var newInvoiceItem = new InvoiceItem
            {
                ItemId = itemId,
                InvoiceId = invoiceId,
                PriceNoTax = price,
                Description = $"Nabavljena količina: {amount}"
            };

            if (newInvoiceItem != null)
            {
                _applicationDbContext.InvoiceItems.Add(newInvoiceItem);
                _applicationDbContext.SaveChanges();
            }

            return newInvoiceItem;
        }

        public InvoiceItem GetInvoiceItemById(int invoiceItemId)
        {
            var invoiceItem = _applicationDbContext.InvoiceItems.Find(invoiceItemId);

            return invoiceItem;
        }

        public IEnumerable<InvoiceItem> GetInvoiceItemsByItemId(int itemId)
        {
            var invoiceItems = _applicationDbContext.InvoiceItems.Where(x => x.ItemId == itemId).Include(n=>n.Invoice.Supplier);

            return invoiceItems;
        }

        public IEnumerable<InvoiceItem> InvoiceSummaryByInvoiceId(int invoiceId)
        {
            var invoiceItems = _applicationDbContext.InvoiceItems.Where(x => x.InvoiceId == invoiceId).Include(i=> i.Invoice).Include(it => it.Item);

            return invoiceItems;
        }

        public bool RemoveInvoiceItem(int invoiceItemId)
        {
            bool success = false;

            var invoiceItem = _applicationDbContext.InvoiceItems.Find(invoiceItemId);

            if(invoiceItem != null)
            {
                _applicationDbContext.Remove(invoiceItem);
                _applicationDbContext.SaveChanges();
                success = true;
            }

            return success;
        }
    }
}
