
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class PaymentMethodConfiguration : BaseEntityConfiguration<PaymentMethod>
    {
        public override void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            base.Configure(builder);

            builder.ToTable("payment_method");

            builder.Property(pm => pm.PaymentGatewayId)
                   .HasColumnName("payment_gateway_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(pm => pm.Name)
                   .HasColumnName("name")
                   .HasColumnOrder(2)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(pm => pm.Description)
                   .HasColumnName("description")
                   .HasColumnOrder(3)
                   .HasMaxLength(255);

            builder.Property(pm => pm.GatewayFlag)
                   .HasColumnName("gateway_flag")
                   .HasColumnOrder(4)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(pm => pm.TransactionFeePercentage)
                   .HasColumnName("transaction_fee_percentage")
                   .HasColumnOrder(5)
                   .HasPrecision(5, 2)
                   .HasDefaultValue(0);

            builder.Property(pm => pm.IconUrl)
                   .HasColumnName("icon_url")
                   .HasColumnOrder(6)
                   .HasMaxLength(1000);

            builder.HasIndex(pm => pm.GatewayFlag)
                   .IsUnique()
                   .HasDatabaseName("ix_payment_method_gateway_flag_unique");

            builder.HasIndex(pm => pm.Name)
                   .HasDatabaseName("ix_payment_method_name");

            builder.HasIndex(pm => new { pm.PaymentGatewayId, pm.Name })
                   .IsUnique()
                   .HasDatabaseName("ix_payment_method_gateway_name_unique");

            builder.HasOne(pm => pm.PaymentGateway)
                   .WithMany(pg => pg.PaymentMethods)
                   .HasForeignKey(pm => pm.PaymentGatewayId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
