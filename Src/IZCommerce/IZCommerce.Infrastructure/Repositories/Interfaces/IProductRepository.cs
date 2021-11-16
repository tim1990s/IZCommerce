using IZCommerce.Core.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IZCommerce.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);
        Task<Product> GetProductAsync(int productId, bool trackChanges);
        Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
