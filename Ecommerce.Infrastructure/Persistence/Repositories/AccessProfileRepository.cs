
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Repositories;
using Ecommerce.Infrastructure.Persistence.Context;
using Ecommerce.Infrastructure.Persistence.Repositories.Base;

namespace Ecommerce.Infrastructure.Persistence.Repositories
{
    public class AccessProfileRepository : BaseRepository<AccessProfile>, IAccessProfileRepository
    {
        public AccessProfileRepository(EcommerceDbContext ecommerceDbContext)
        : base(ecommerceDbContext)
            {
            }

    }
}
