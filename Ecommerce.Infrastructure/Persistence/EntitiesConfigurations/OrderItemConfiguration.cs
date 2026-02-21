
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class OrderItemConfiguration : BaseEntityConfiguration<OrderItem>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            base.Configure(builder);

            builder.ToTable("order_item", t =>
            {
                t.HasCheckConstraint("CK_OrderItem_Quantity_Positive", "quantity > 0");
                t.HasCheckConstraint("CK_OrderItem_UnitPriceAmount_Positive", "unit_price_amount >= 0");
                t.HasCheckConstraint("CK_OrderItem_TotalAmount_Positive", "total_amount >= 0");
            });

            builder.Property(t => t.Quantity)
                   .HasColumnName("quantity")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(t => t.UnitPriceAmount)
                   .HasColumnName("unit_price_amount")
                   .HasColumnOrder(2)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(t => t.TotalAmount)
                   .HasColumnName("total_amount")
                   .HasColumnOrder(3)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(t => t.OrderId)
                   .HasColumnName("order_id")
                   .HasColumnOrder(4)
                   .IsRequired();

            builder.Property(t => t.ProductVariantId)
                   .HasColumnName("product_variant_id")
                   .HasColumnOrder(5)
                   .IsRequired();

            builder.HasOne(t => t.Order)
                   .WithMany(o => o.OrderItems)
                   .HasForeignKey(t => t.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.ProductVariant)
                   .WithMany()
                   .HasForeignKey(t => t.ProductVariantId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(t => new { t.OrderId, t.ProductVariantId })
                   .IsUnique()
                   .HasDatabaseName("ix_order_item_order_product_unique");

            builder.HasIndex(oi => oi.ProductVariantId)
                   .HasDatabaseName("ix_order_item_variant_id");
        }
    }
}
