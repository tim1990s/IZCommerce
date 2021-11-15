using IZCommerce.Core.Models;
using IZCommerce.Infrastructure.DatabaseContext;
using IZCommerce.Infrastructure.Repositories.Interfaces;

namespace IZCommerce.Infrastructure.Repositories
{
    public class CategoryRepository: RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IZCommerceDBContext iZCommerceDBContext): base(iZCommerceDBContext)
        {
        }
    }
}
