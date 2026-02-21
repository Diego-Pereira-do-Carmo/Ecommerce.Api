
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Ecommerce.Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class LogisticStatusConfiguration : BaseStatusEntityConfiguration<LogisticStatus>
    {
        public override void Configure(EntityTypeBuilder<LogisticStatus> builder)
        {
            base.Configure(builder);
            builder.ToTable("logistics_status");

            new LogisticStatusSeeder().Seed(builder);
        }
    }
}
