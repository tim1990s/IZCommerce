using IZCommerce.Domain.Entities;

namespace IZCommerce.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}
