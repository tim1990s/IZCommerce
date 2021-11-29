using IZCommerce.Core.Models;
using IZCommerce.Infrastructure.DatabaseContext;
using IZCommerce.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IZCommerce.Infrastructure.Repositories
{
    public class SupplierRepository: RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(IZCommerceDBContext iZCommerceDBContext): base(iZCommerceDBContext)
        {
        }

        public void CreateSupplier(Supplier supplier)
        {
            Create(supplier);
        }

        public void DeleteSupplier(Supplier supplier)
        {
            Delete(supplier);
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(s => s.CompanyName).ToListAsync();
        }

        public async Task<IEnumerable<Supplier>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges)
        {
            return await FindByCondition(s => ids.Contains(s.SupplierId), trackChanges).ToListAsync();
        }

        public async Task<Supplier> GetSupplierAsync(int supplierId, bool trackChanges)
        {
            return await FindByCondition(s => s.SupplierId.Equals(supplierId), trackChanges).SingleOrDefaultAsync();
        }
    }
}
