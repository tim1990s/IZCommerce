using IZCommerce.Application.Contracts.Persistence;
using IZCommerce.Domain.Entities;

namespace IZCommerce.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(IZCommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
