using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Models.Entities;

namespace Link_Inventory.Models.Repositories
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> AllSuppliers { get; }

        Supplier GetSupplierById(int supplierId);
    }
}
