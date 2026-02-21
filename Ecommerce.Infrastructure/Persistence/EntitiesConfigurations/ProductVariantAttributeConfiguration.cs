
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class ProductVariantAttributeConfiguration : BaseEntityConfiguration<ProductVariantAttribute>
    {
        public override void Configure(EntityTypeBuilder<ProductVariantAttribute> builder)
        {
            base.Configure(builder);

            builder.ToTable("product_variant_attribute");

            builder.Property(pva => pva.ProductVariantId)
                   .HasColumnName("product_variant_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(pva => pva.ProductAttributeValueId)
                   .HasColumnName("product_attribute_value_id")
                   .HasColumnOrder(2)
                   .IsRequired();

            builder.HasOne(pva => pva.ProductVariant)
                   .WithMany(pv => pv.ProductVariantAttributes)
                   .HasForeignKey(pva => pva.ProductVariantId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pva => pva.ProductAttributeValue)
                   .WithMany()
                   .HasForeignKey(pva => pva.ProductAttributeValueId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pva => new { pva.ProductVariantId, pva.ProductAttributeValueId })
                   .IsUnique()
                   .HasDatabaseName("ix_product_variant_attribute_unique");

            builder.HasIndex(pva => pva.ProductAttributeValueId)
                   .HasDatabaseName("ix_product_variant_attribute_value_id");
        }
    }
}
