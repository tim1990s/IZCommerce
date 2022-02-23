using IZCommerce.Domain.Entities;

namespace IZCommerce.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}
