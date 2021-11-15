using IZCommerce.Core.Models;
using IZCommerce.Infrastructure.DatabaseContext;
using IZCommerce.Infrastructure.Repositories.Interfaces;

namespace IZCommerce.Infrastructure.Repositories
{
    public class ProductRepository: RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IZCommerceDBContext iZCommerceDBContext) :base(iZCommerceDBContext)
        {
        }
    }
}
