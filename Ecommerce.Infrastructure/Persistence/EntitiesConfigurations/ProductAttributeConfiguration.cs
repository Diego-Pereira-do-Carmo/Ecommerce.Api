
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class ProductAttributeConfiguration : BaseEntityConfiguration<ProductAttribute>
    {
        public override void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            base.Configure(builder);

            builder.ToTable("product_attribute");

            builder.Property(pa => pa.Name)
                   .HasColumnName("name")
                   .HasColumnOrder(1)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(pa => pa.DisplayOrder)
                   .HasColumnName("display_order")
                   .HasColumnOrder(2)
                   .HasDefaultValue(0)
                   .IsRequired();

            builder.HasIndex(pa => pa.Name)
                   .IsUnique()
                   .HasDatabaseName("ix_product_attribute_name_unique");
        }
    }
}
