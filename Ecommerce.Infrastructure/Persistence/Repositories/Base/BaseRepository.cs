
using Ecommerce.Domain.Interfaces.Base;
using Ecommerce.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Infrastructure.Persistence.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly EcommerceDbContext EcommerceDbContext;
        protected readonly DbSet<T> DbSetContext;

        protected BaseRepository(EcommerceDbContext ecommerceDbContext)
        {
            EcommerceDbContext = ecommerceDbContext;
            DbSetContext = EcommerceDbContext.Set<T>();
        }


        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object?>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object?>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
