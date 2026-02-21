
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class ProductReviewImageConfiguration : BaseEntityConfiguration<ProductReviewImage>
    {
        public override void Configure(EntityTypeBuilder<ProductReviewImage> builder)
        {
            base.Configure(builder);

            builder.ToTable("product_review_image");

            builder.Property(x => x.ProductReviewId)
                   .HasColumnName("product_review_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(x => x.FileName)
                   .HasColumnName("file_name")
                   .HasColumnOrder(2)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.StringBase64)
                   .HasColumnName("string_base64")
                   .HasColumnOrder(3)
                   .HasColumnType("text")
                   .IsRequired();

            builder.Property(x => x.MimeType)
                   .HasColumnName("mime_type")
                   .HasColumnOrder(4)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.DisplayOrder)
                   .HasColumnName("display_order")
                   .HasColumnOrder(6)
                   .HasDefaultValue(0);

            builder.HasOne(x => x.ProductReview)
                   .WithMany(pr => pr.Images)
                   .HasForeignKey(x => x.ProductReviewId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.ProductReviewId)
                   .HasDatabaseName("ix_review_image_review_id");

            builder.HasIndex(pi => pi.FileName)
                   .HasDatabaseName("ix_review_image_file_name");
        }
    }
}
