using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Models.Entities;

namespace Link_Inventory.Models.Repositories
{
    public interface IInvoiceRepository
    {
        Invoice AddInvoice(Invoice invoice, int supplierId, int companyId);

        Invoice GetInvoiceById(int invoiceId);
    }
}
