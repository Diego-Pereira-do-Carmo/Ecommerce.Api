
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Ecommerce.Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class EmailStatusConfiguration : BaseStatusEntityConfiguration<EmailStatus>
    {
        public override void Configure(EntityTypeBuilder<EmailStatus> builder)
        {
            base.Configure(builder);
            builder.ToTable("email_status");

            new EmailStatusSeeder().Seed(builder);
        }
    }
}
