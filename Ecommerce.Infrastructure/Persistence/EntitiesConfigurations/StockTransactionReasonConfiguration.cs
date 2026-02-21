
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class StockTransactionReasonConfiguration : BaseEntityConfiguration<StockTransactionReason>
    {
        public override void Configure(EntityTypeBuilder<StockTransactionReason> builder)
        {
            base.Configure(builder);

            builder.ToTable("stock_transaction_reason");

            builder.Property(x => x.Name)
                   .HasColumnName("name")
                   .HasColumnOrder(1)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasColumnName("description")
                   .HasColumnOrder(2)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.HasIndex(x => x.Name)
                   .IsUnique()
                   .HasDatabaseName("ix_stock_transaction_reason_name");
        }
    }
}
