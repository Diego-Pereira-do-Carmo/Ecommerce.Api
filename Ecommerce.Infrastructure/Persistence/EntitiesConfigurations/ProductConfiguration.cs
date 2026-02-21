
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.ToTable("product");

            builder.Property(p => p.Name)
                   .HasColumnName("name")
                   .HasColumnOrder(1)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(p => p.UrlKey)
                   .HasColumnName("url_key")
                   .HasColumnOrder(2)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(p => p.ShortDescription)
                   .HasColumnName("short_description")
                   .HasColumnOrder(3)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(p => p.FullDescription)
                   .HasColumnName("full_description")
                   .HasColumnOrder(4)
                   .HasColumnType("text");

            builder.Property(p => p.BrandId)
                   .HasColumnName("brand_id")
                   .HasColumnOrder(5)
                   .IsRequired();


            builder.HasOne(p => p.Brand)
                   .WithMany(b => b.Products)
                   .HasForeignKey(p => p.BrandId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.ProductCategories)
                   .WithOne(pc => pc.Product)
                   .HasForeignKey(pc => pc.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.UrlKey)
                   .IsUnique()
                   .HasDatabaseName("ix_product_url_key_unique");

            builder.HasIndex(p => p.Name)
                   .HasDatabaseName("ix_product_name");

            builder.HasIndex(p => p.BrandId)
                   .HasDatabaseName("ix_Brand_id");
        }
    }
}
