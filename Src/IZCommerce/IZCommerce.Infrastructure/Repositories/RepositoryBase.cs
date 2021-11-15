using IZCommerce.Infrastructure.DatabaseContext;
using IZCommerce.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace IZCommerce.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected IZCommerceDBContext _iZCommerceDBContext;

        public RepositoryBase(IZCommerceDBContext iZCommerceDBContext)
        {
            _iZCommerceDBContext = iZCommerceDBContext;
        }

        public void Create(T entity)
        {
            _iZCommerceDBContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _iZCommerceDBContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? _iZCommerceDBContext.Set<T>() : _iZCommerceDBContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ? _iZCommerceDBContext.Set<T>().Where(expression) : _iZCommerceDBContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            _iZCommerceDBContext.Set<T>().Update(entity);
        }
    }
}
