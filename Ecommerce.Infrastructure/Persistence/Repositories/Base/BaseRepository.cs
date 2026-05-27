using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Interfaces.Base;
using Ecommerce.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace Ecommerce.Infrastructure.Persistence.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly EcommerceDbContext EcommerceDbContext;
        protected readonly DbSet<T> DbSetContext;

        protected BaseRepository(EcommerceDbContext ecommerceDbContext)
        {
            EcommerceDbContext = ecommerceDbContext;
            DbSetContext = EcommerceDbContext.Set<T>();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await DbSetContext.AnyAsync(predicate, cancellationToken);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindWithIncludesAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<T, object?>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdWithIncludesAsync(Guid id, CancellationToken cancellationToken = default, params Expression<Func<T, object?>>[] includes)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await DbSetContext.AddAsync(entity, cancellationToken);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetByFriendlyCode(string friendlycode, CancellationToken cancellationToken = default)
        {
            return await DbSetContext.FirstOrDefaultAsync(x => x.FriendlyCode == friendlycode, cancellationToken);
        }
    }
}
