
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class ProductReviewConfiguration : BaseEntityConfiguration<ProductReview>
    {
        public override void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            base.Configure(builder);

            builder.ToTable("product_review", t =>
            {
                t.HasCheckConstraint("CK_ProductReview_Title_MinLength", "char_length(title) >= 3");
                t.HasCheckConstraint("CK_ProductReview_ReviewMessage_MinLength", "char_length(review_message) >= 5");
                t.HasCheckConstraint("CK_ProductReview_Rating", "rating >= 1 AND rating <= 5");
                t.HasCheckConstraint("CK_ProductReview_HelpfulVotes", "helpful_votes >= 0");
                t.HasCheckConstraint("CK_ProductReview_ReplyMessage_MinLength", "reply_message IS NULL OR char_length(reply_message) >= 5");
            });

            builder.Property(x => x.CustomerId)
                   .HasColumnName("customer_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(x => x.ProductId)
                   .HasColumnName("product_id")
                   .HasColumnOrder(2)
                   .IsRequired();

            builder.Property(x => x.OrderId)
                   .HasColumnName("order_id")
                   .HasColumnOrder(3)
                   .IsRequired();

            builder.Property(pr => pr.Title)
                   .HasColumnName("title")
                   .HasColumnOrder(4)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(pr => pr.ReviewMessage)
                   .HasColumnName("review_message")
                   .HasColumnOrder(5)
                   .HasMaxLength(2000)
                   .IsRequired();

            builder.Property(pr => pr.Rating)
                   .HasColumnName("rating")
                   .HasColumnOrder(6)
                   .IsRequired();

            builder.Property(pr => pr.HelpfulVotes)
                   .HasColumnName("helpful_votes")
                   .HasColumnOrder(7)
                   .IsRequired();

            builder.Property(pr => pr.ReplyMessage)
                   .HasColumnName("reply_message")
                   .HasColumnOrder(8)
                   .HasMaxLength(2000)
                   .IsRequired();

            builder.Property(x => x.RepliedOn)
                   .HasColumnName("replied_on")
                   .HasColumnOrder(9);

            builder.Property(x => x.ProductReviewStatusId)
                   .HasColumnName("product_review_status_id")
                   .HasColumnOrder(10)
                   .IsRequired();

            builder.HasOne(pr => pr.Product)
                   .WithMany(p => p.Reviews)
                   .HasForeignKey(pr => pr.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pr => pr.Customer)
                   .WithMany()
                   .HasForeignKey(pr => pr.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pr => pr.Order)
                   .WithMany()
                   .HasForeignKey(pr => pr.OrderId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(pr => pr.ProductReviewStatus)
                   .WithMany()
                   .HasForeignKey(pr => pr.ProductReviewStatusId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pr => pr.ProductId)
                   .HasDatabaseName("ix_review_product_id");

            builder.HasIndex(pr => pr.CustomerId)
                   .HasDatabaseName("ix_review_customer_id");

            builder.HasIndex(pr => pr.OrderId)
                   .HasDatabaseName("ix_review_order_id");

            builder.HasIndex(pr => pr.ProductReviewStatusId)
                   .HasDatabaseName("ix_review_product_review_status_id");
        }
    }
}
