
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class StockTransactionConfiguration : BaseEntityConfiguration<StockTransaction>
    {
        public override void Configure(EntityTypeBuilder<StockTransaction> builder)
        {
            base.Configure(builder);

            var validTypes = string.Join(", ", Enum.GetNames<StockTransactionTypeEnum>().Select(n => $"'{n}'"));

            builder.ToTable("stock_transaction", t =>
            {
                t.HasCheckConstraint("CK_Stock_Quantity", "quantity <> 0");
                t.HasCheckConstraint("CK_Stock_BalanceAfter", "balance_after >= 0");
                t.HasCheckConstraint("CK_Stock_Transaction_Type_Enum", $"stock_transaction_type IN ({validTypes})");
            });

            builder.Property(x => x.ProductVariantId)
                   .HasColumnName("product_variant_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(x => x.OrderId)
                   .HasColumnName("order_id")
                   .HasColumnOrder(2);

            builder.Property(x => x.Quantity)
                   .HasColumnName("quantity")
                   .HasColumnOrder(3)
                   .IsRequired();

            builder.Property(x => x.BalanceAfter)
                   .HasColumnName("balance_after")
                   .HasColumnOrder(4)
                   .IsRequired();

            builder.Property(x => x.StockTransactionType)
                   .HasColumnName("stock_transaction_type")
                   .HasColumnOrder(5)
                   .HasConversion<string>()
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(x => x.StockTransactionReasonId)
                   .HasColumnName("stock_transaction_reason_id")
                   .HasColumnOrder(6)
                   .IsRequired();

            builder.Property(x => x.UserId)
                   .HasColumnName("user_id")
                   .HasColumnOrder(7)
                   .IsRequired();

            builder.HasOne(x => x.StockTransactionReason)
                   .WithMany()
                   .HasForeignKey(x => x.StockTransactionReasonId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ProductVariant)
                   .WithMany()
                   .HasForeignKey(x => x.ProductVariantId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Order)
                   .WithMany()
                   .HasForeignKey(x => x.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                   .WithMany()
                   .IsRequired()
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(st => st.ProductVariantId)
                   .HasDatabaseName("ix_stock_transaction_variant_id");

            builder.HasIndex(x => x.StockTransactionType)
                   .HasDatabaseName("ix_stock_transaction_type");

            builder.HasIndex(x => x.StockTransactionReasonId)
                   .HasDatabaseName("ix_stock_transaction_Reason_id");

            builder.HasIndex(x => x.UserId)
                   .HasDatabaseName("ix_User_id");
        }
    }
}
