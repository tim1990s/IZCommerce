using System.Threading.Tasks;

namespace IZCommerce.Infrastructure.Repositories.Interfaces
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }

        ICategoryRepository Category { get; }

        ISupplierRepository Supplier { get; }

        Task SaveAsync();
    }
}
