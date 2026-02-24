
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Repositories;
using Ecommerce.Infrastructure.Persistence.Context;
using Ecommerce.Infrastructure.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EcommerceDbContext ecommerceDbContext) 
            : base(ecommerceDbContext)
        {
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await DbSetContext.FirstOrDefaultAsync(u => u.EmailAddress.Value == email);
        }
    }
}
