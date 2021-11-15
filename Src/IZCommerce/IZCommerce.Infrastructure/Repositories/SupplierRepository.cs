using IZCommerce.Core.Models;
using IZCommerce.Infrastructure.DatabaseContext;
using IZCommerce.Infrastructure.Repositories.Interfaces;

namespace IZCommerce.Infrastructure.Repositories
{
    public class SupplierRepository: RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(IZCommerceDBContext iZCommerceDBContext): base(iZCommerceDBContext)
        {
        }
    }
}
