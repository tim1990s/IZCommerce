using IZCommerce.Infrastructure.DatabaseContext;
using IZCommerce.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;

namespace IZCommerce.Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private IZCommerceDBContext _iZCommerceDBContext;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private ISupplierRepository _supplierRepository;

        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_iZCommerceDBContext);
                }
                return _productRepository;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_iZCommerceDBContext);
                }
                return _categoryRepository;
            }
        }

        public ISupplierRepository Supplier
        {
            get
            {
                if (_supplierRepository == null)
                {
                    _supplierRepository = new SupplierRepository(_iZCommerceDBContext);
                }
                return _supplierRepository;
            }
        }

        public Task SaveAsync()
        {
            return _iZCommerceDBContext.SaveChangesAsync();
        }
    }
}
