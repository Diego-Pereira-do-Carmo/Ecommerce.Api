
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(pc => new { pc.ProductId, pc.CategoryId });

            builder.ToTable("product_category");

            builder.Property(t => t.ProductId)
                   .HasColumnName("product_id")
                   .HasColumnOrder(0)
                   .IsRequired();

            builder.Property(t => t.CategoryId)
                   .HasColumnName("category_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(t => t.IsMain)
                   .HasColumnName("is_main")
                   .HasColumnOrder(2)
                   .HasDefaultValue(false);

            builder.HasIndex(t => t.ProductId)
                   .IsUnique()
                   .HasFilter("is_main = true")
                   .HasDatabaseName("ix_product_category_unique_main");

            builder.HasOne(t => t.Product)
                   .WithMany(p => p.ProductCategories)
                   .HasForeignKey(t => t.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Category)
                   .WithMany(c => c.ProductCategories)
                   .HasForeignKey(t => t.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
