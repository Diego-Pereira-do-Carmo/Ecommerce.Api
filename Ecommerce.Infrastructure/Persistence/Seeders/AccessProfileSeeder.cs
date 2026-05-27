using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.Seeders.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.Seeders
{
    internal class AccessProfileSeeder : BaseSeeder<AccessProfile>
    {
        private static readonly Guid _systemUserId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        private static readonly DateTime _defaultDate = new DateTime(2026, 2, 10, 0, 0, 0, DateTimeKind.Utc);

        public override void Seed(EntityTypeBuilder<AccessProfile> builder)
        {
            var nameList = new[] { "Cliente", "Admin"};
            var className = nameof(AccessProfile);

            foreach (var name in nameList)
            {
                var id = GenerateDeterministicGuid(name);

                builder.HasData(new
                {
                    Id = GenerateDeterministicGuid(name),
                    Name = name,
                    Description = $"Perfil de acesso {name.ToLower()}",
                    IsDeleted = false,
                    IsActive = true,
                    FriendlyCode = GenerateFriendlyCode(id, className),
                    CreatedOn = _defaultDate,
                    CreatedBy = _systemUserId
                });
            }
        }
    }
}
