
using System.Linq.Expressions;

namespace Ecommerce.Domain.Interfaces.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object?>>[] includes);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object?>>[] includes);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
