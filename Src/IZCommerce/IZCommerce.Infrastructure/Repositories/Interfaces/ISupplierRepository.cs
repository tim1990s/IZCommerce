using IZCommerce.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IZCommerce.Infrastructure.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync(bool trackChanges);
        Task<Supplier> GetSupplierAsync(int supplierId, bool trackChanges);
        Task<IEnumerable<Supplier>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        void CreateSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
    }
}
