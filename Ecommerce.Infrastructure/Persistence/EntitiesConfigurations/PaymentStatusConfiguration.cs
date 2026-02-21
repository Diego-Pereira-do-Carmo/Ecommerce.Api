
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Ecommerce.Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class PaymentStatusConfiguration : BaseStatusEntityConfiguration<PaymentStatus>
    {
        public override void Configure(EntityTypeBuilder<PaymentStatus> builder)
        {
            base.Configure(builder);
            builder.ToTable("payment_status");

            new PaymentStatusSeeder().Seed(builder);
        }
    }
}
