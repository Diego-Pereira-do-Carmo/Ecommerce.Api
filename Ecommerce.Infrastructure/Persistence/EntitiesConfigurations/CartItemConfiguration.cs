
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("cart_item", t =>
            {
                t.HasCheckConstraint("CK_CartItem_Quantity_Min", "quantity > 0");
            });

            builder.HasKey(ci => new { ci.CustomerId, ci.ProductVariantId });

            builder.Property(ci => ci.ProductVariantId)
                   .HasColumnName("product_variant_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(ci => ci.CustomerId)
                   .HasColumnName("customer_id")
                   .HasColumnOrder(2)
                   .IsRequired();

            builder.Property(ci => ci.Quantity)
                   .HasColumnName("quantity")
                   .HasColumnOrder(3)
                   .IsRequired();

            builder.Property(ci => ci.AddedAt)
                   .HasColumnName("added_at")
                   .HasColumnOrder(4)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP")
                   .IsRequired();

            builder.HasOne(ci => ci.Customer)
                   .WithMany(c => c.CartItems)
                   .HasForeignKey(ci => ci.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.ProductVariant)
                   .WithMany(pv => pv.CartItems)
                   .HasForeignKey(ci => ci.ProductVariantId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
