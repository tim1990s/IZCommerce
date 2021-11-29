using IZCommerce.Core.Models;
using IZCommerce.Infrastructure.DatabaseContext;
using IZCommerce.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IZCommerce.Infrastructure.Repositories
{
    public class CategoryRepository: RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IZCommerceDBContext iZCommerceDBContext): base(iZCommerceDBContext)
        {
        }

        public void CreateCategory(Category category)
        {
            Create(category);
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.CategoryName).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.CategoryId), trackChanges).ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int categoryId, bool trackChanges)
        {
            return await FindByCondition(x => x.CategoryId.Equals(categoryId), trackChanges).SingleOrDefaultAsync();
        }
    }
}
