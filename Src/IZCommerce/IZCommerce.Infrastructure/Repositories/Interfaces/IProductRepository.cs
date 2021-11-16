using IZCommerce.Core.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IZCommerce.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);
    }
}
