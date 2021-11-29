using IZCommerce.Core.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IZCommerce.Infrastructure.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
        Task<Category> GetCategoryAsync(int categoryId, bool trackChanges);
        Task<IEnumerable<Category>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        void CreateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
