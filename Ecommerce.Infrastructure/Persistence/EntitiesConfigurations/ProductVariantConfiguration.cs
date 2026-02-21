
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class ProductVariantConfiguration : BaseEntityConfiguration<ProductVariant>
    {
        public override void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            base.Configure(builder);

            builder.ToTable("product_variant");

            builder.Property(pv => pv.ProductId)
                   .HasColumnName("product_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(pv => pv.Name)
                   .HasColumnName("name")
                   .HasColumnOrder(2)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(pv => pv.Sku)
                   .HasColumnName("sku")
                   .HasColumnOrder(3)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(pv => pv.Ean)
                   .HasColumnName("ean")
                   .HasColumnOrder(4)
                   .HasMaxLength(20);

            builder.ComplexProperty(x => x.Dimensions, d =>
            {
                d.Property(p => p.Length)
                 .HasColumnName("length")
                 .HasPrecision(12, 4)
                 .HasColumnOrder(5)
                 .IsRequired();

                d.Property(p => p.Width)
                 .HasColumnName("width")
                 .HasPrecision(12, 4)
                 .HasColumnOrder(6)
                 .IsRequired();

                d.Property(p => p.Height)
                 .HasColumnName("height")
                 .HasPrecision(12, 4)
                 .HasColumnOrder(7)
                 .IsRequired();

                d.Property(p => p.Weight)
                 .HasColumnName("weight")
                 .HasPrecision(12, 4)
                 .HasColumnOrder(8)
                 .IsRequired();
            });

            builder.Property(pv => pv.Price)
                   .HasColumnName("price")
                   .HasColumnOrder(9)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.HasIndex(pv => pv.Sku)
                   .IsUnique()
                   .HasDatabaseName("ix_product_variant_sku_unique");

            builder.HasIndex(pv => pv.Ean)
                   .HasDatabaseName("ix_product_variant_ean");

            builder.HasIndex(pv => pv.ProductId)
                   .HasDatabaseName("ix_product_variant_product_id");

            builder.HasOne(pv => pv.Product)
                   .WithMany(p => p.Variants)
                   .HasForeignKey(pv => pv.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(pv => pv.CartItems)
                   .WithOne(ci => ci.ProductVariant)
                   .HasForeignKey(ci => ci.ProductVariantId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
