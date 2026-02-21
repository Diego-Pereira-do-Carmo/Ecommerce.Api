
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.ToTable("category");

            builder.Property(c => c.Name)
                   .HasColumnName("name")
                   .HasColumnOrder(1)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.UrlKey)
                   .HasColumnName("url_key")
                   .HasColumnOrder(2)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(c => c.Description)
                   .HasColumnName("description")
                   .HasColumnOrder(3)
                   .HasMaxLength(250);

            builder.Property(c => c.DisplayOrder)
                   .HasColumnName("display_order")
                   .HasColumnOrder(4)
                   .IsRequired();

            builder.HasOne(c => c.ParentCategory)
                   .WithMany(p => p.SubCategories)
                   .HasForeignKey(c => c.ParentCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.ProductCategories)
                   .WithOne(pc => pc.Category)
                   .HasForeignKey(pc => pc.CategoryId);

            builder.HasIndex(c => c.UrlKey)
                   .IsUnique()
                   .HasDatabaseName("ix_category_url_key");
        }
    }
}
