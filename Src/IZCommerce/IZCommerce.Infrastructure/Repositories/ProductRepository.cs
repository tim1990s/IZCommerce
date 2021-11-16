using IZCommerce.Core.Models;
using IZCommerce.Infrastructure.DatabaseContext;
using IZCommerce.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IZCommerce.Infrastructure.Repositories
{
    public class ProductRepository: RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IZCommerceDBContext iZCommerceDBContext) :base(iZCommerceDBContext)
        {
        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(p => p.ProductName).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.ProductId), trackChanges).ToListAsync();
        }

        public async Task<Product> GetProductAsync(int productId, bool trackChanges)
        {
            return await FindByCondition(x => x.ProductId.Equals(productId), trackChanges).SingleOrDefaultAsync();
        }
    }
}
