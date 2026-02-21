
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class ProductAttributeValueConfiguration : BaseEntityConfiguration<ProductAttributeValue>
    {
        public override void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
        {
            base.Configure(builder);

            builder.ToTable("product_attribute_value");

            builder.Property(pav => pav.ProductAttributeId)
                   .HasColumnName("product_attribute_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(pav => pav.Name)
                   .HasColumnName("name")
                   .HasColumnOrder(2)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(pav => pav.DisplayOrder)
                   .HasColumnName("display_order")
                   .HasColumnOrder(3)
                   .HasDefaultValue(0)
                   .IsRequired();

            builder.HasOne(pav => pav.ProductAttribute)
                   .WithMany(pa => pa.Values)
                   .HasForeignKey(pav => pav.ProductAttributeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(pav => new { pav.ProductAttributeId, pav.Name })
                   .IsUnique()
                   .HasDatabaseName("ix_product_attribute_value_unique");

            builder.HasIndex(pav =>  pav.Name)
                   .HasDatabaseName("ix_product_attribute_value_Name");
        }
    }
}
