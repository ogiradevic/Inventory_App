using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Models.Entities;

namespace Link_Inventory.Models.Repositories
{
    public interface IInvoiceItemRepository
    {
        InvoiceItem AddInvoiceItem(int invoiceId, int itemId, double price, int amount);

        IEnumerable<InvoiceItem> AllInvoiceItems { get; }

        IEnumerable<InvoiceItem> InvoiceSummaryByInvoiceId(int invoiceId);

        bool RemoveInvoiceItem(int invoiceItemId);

        InvoiceItem GetInvoiceItemById(int invoiceItemId);

        IEnumerable<InvoiceItem> GetInvoiceItemsByItemId(int itemId);
    }
}
