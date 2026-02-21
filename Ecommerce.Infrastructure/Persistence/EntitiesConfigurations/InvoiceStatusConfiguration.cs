
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Ecommerce.Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class InvoiceStatusConfiguration : BaseStatusEntityConfiguration<InvoiceStatus>
    {
        public override void Configure(EntityTypeBuilder<InvoiceStatus> builder)
        {
            base.Configure(builder);
            builder.ToTable("invoice_status");

            new InvoiceStatusSeeder().Seed(builder);
        }
    }
}
