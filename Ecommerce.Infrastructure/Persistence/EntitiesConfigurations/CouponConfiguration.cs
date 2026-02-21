
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class CouponConfiguration : BaseEntityConfiguration<Coupon>
    {
        public override void Configure(EntityTypeBuilder<Coupon> builder)
        {
            base.Configure(builder);

            var validTypes = string.Join(", ", Enum.GetNames<DiscountTypeEnum>().Select(n => $"'{n}'"));

            builder.ToTable("coupon", t =>
            {
                t.HasCheckConstraint("CK_Coupon_DiscountAmount", "discount_amount > 0");
                t.HasCheckConstraint("CK_Coupon_Dates", "expiration_date IS NULL OR expiration_date > start_date");

                t.HasCheckConstraint("CK_Coupon_Type_Enum", $"type IN ({validTypes})");
            });

            builder.Property(c => c.Code)
                   .HasColumnName("code")
                   .HasColumnOrder(1)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(c => c.DiscountAmount)
                   .HasColumnName("discount_amount")
                   .HasColumnOrder(2)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(c => c.StartDate)
                   .HasColumnName("start_date")
                   .HasColumnOrder(3)
                   .IsRequired();

            builder.Property(c => c.ExpirationDate)
                   .HasColumnName("expiration_date")
                   .HasColumnOrder(4)
                   .IsRequired();

            builder.Property(c => c.UsageLimit)
                   .HasColumnName("usage_limit")
                   .HasColumnOrder(5)
                   .IsRequired();

            builder.Property(c => c.MinPurchaseAmount)
                   .HasColumnName("min_purchase_amount")
                   .HasColumnOrder(6)
                   .HasPrecision(18, 2);

            builder.Property(c => c.Type)
                   .HasColumnName("type")
                   .HasColumnOrder(7)
                   .HasConversion<string>()
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(c => c.CategoryId)
                   .HasColumnName("category_id")
                   .HasColumnOrder(8);

            builder.HasOne(c => c.Category)
                   .WithMany()
                   .HasForeignKey(c => c.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(c => c.Code)
                   .IsUnique()
                   .HasDatabaseName("ix_coupon_code");
        }
    }
}
