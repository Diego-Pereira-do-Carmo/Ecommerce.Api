
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence.Context;

namespace Ecommerce.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceDbContext _context;

        public UnitOfWork(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
