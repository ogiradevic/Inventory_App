using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Data;
using Link_Inventory.Models.Entities;

namespace Link_Inventory.Models.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SupplierRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<Supplier> AllSuppliers
        {
            get { return _applicationDbContext.Suppliers; }
        }

        public Supplier GetSupplierById(int supplierId)
        {
            var supplier = _applicationDbContext.Suppliers.Find(supplierId);

            return supplier;

        }
    }
}
