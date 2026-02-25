
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Base;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(EmailAddressValueObject emailVO, CancellationToken cancellationToken = default);
    }
}
