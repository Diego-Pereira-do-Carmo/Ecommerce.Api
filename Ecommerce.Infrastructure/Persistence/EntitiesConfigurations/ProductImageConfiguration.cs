using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class ProductImageConfiguration : BaseEntityConfiguration<ProductImage>
    {
        public override void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            base.Configure(builder);

            builder.ToTable("product_image");

            builder.Property(pi => pi.ProductId)
                   .HasColumnName("product_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(pi => pi.ProductVariantId)
                   .HasColumnName("product_variant_id")
                   .HasColumnOrder(2);

            builder.Property(pi => pi.FileName)
                   .HasColumnName("file_name")
                   .HasColumnOrder(3)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(pi => pi.StringBase64)
                   .HasColumnName("string_base64")
                   .HasColumnOrder(4)
                   .HasColumnType("text")
                   .IsRequired();

            builder.Property(pi => pi.MimeType)
                   .HasColumnName("mime_type")
                   .HasColumnOrder(5)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(pi => pi.IsMain)
                   .HasColumnName("is_main")
                   .HasColumnOrder(6)
                   .HasDefaultValue(false);

            builder.Property(pi => pi.DisplayOrder)
                   .HasColumnName("display_order")
                   .HasColumnOrder(7)
                   .HasDefaultValue(0);

            builder.HasOne(pi => pi.Product)
                   .WithMany(p => p.Images)
                   .HasForeignKey(pi => pi.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pi => pi.ProductVariant)
                   .WithMany(pv => pv.Images)
                   .HasForeignKey(pi => pi.ProductVariantId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(pi => pi.FileName)
                   .HasDatabaseName("ix_product_image_file_name");

            builder.HasIndex(pi => pi.ProductId)
                   .HasDatabaseName("ix_product_image_product_id");

            builder.HasIndex(pi => pi.ProductVariantId)
                   .HasDatabaseName("ix_product_image_variant_id");
        }
    }
}
