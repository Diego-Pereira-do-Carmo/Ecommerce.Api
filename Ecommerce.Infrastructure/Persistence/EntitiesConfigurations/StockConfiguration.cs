
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class StockConfiguration : BaseEntityConfiguration<Stock>
    {
        public override void Configure(EntityTypeBuilder<Stock> builder)
        {
            base.Configure(builder);

            builder.ToTable("stock", t =>
            {
                t.HasCheckConstraint("CK_Stock_Quantity_Positive", "quantity >= 0");
                t.HasCheckConstraint("CK_Stock_Reserved_Positive", "reserved_quantity >= 0");
                t.HasCheckConstraint("CK_Stock_MinQuantity_Positive", "min_quantity >= 0");
            });

            builder.Property(x => x.ProductVariantId)
                   .HasColumnName("product_variant_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(x => x.Quantity)
                   .HasColumnName("quantity")
                   .HasColumnOrder(2)
                   .HasDefaultValue(0)
                   .IsRequired();

            builder.Property(x => x.ReservedQuantity)
                   .HasColumnName("reserved_quantity")
                   .HasColumnOrder(3)
                   .HasDefaultValue(0)
                   .IsRequired();

            builder.Property(x => x.MinQuantity)
                   .HasColumnName("min_quantity")
                   .HasColumnOrder(4)
                   .HasDefaultValue(0)
                   .IsRequired();

            builder.HasOne(x => x.ProductVariant)
                   .WithOne(pv => pv.Stock)
                   .HasForeignKey<Stock>(x => x.ProductVariantId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.ProductVariantId)
                   .IsUnique()
                   .HasDatabaseName("ix_stock_product_variant_id_unique");
        }
    }
}
