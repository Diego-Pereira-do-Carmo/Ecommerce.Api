
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class OrderConfiguration : BaseEntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.ToTable("order", t =>
            {
                t.HasCheckConstraint("CK_Order_ItemsTotalAmount_Positive", "items_total_amount >= 0");
                t.HasCheckConstraint("CK_Order_delivery_amount_Positive", "delivery_amount >= 0");
                t.HasCheckConstraint("CK_Order_DiscountAmount_Positive", "discount_amount >= 0");
                t.HasCheckConstraint("CK_Order_TotalPayableAmount_Positive", "total_payable_amount >= 0");
            });

            builder.Property(o => o.ItemsTotalAmount)
                   .HasColumnName("items_total_amount")
                   .HasColumnOrder(1)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(o => o.DeliveryAmount)
                   .HasColumnName("delivery_amount")
                   .HasColumnOrder(2)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(o => o.DiscountAmount)
                   .HasColumnName("discount_amount")
                   .HasColumnOrder(3)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(o => o.TotalPayableAmount)
                   .HasColumnName("total_payable_amount")
                   .HasColumnOrder(4)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(o => o.Observation)
                   .HasColumnName("observation")
                   .HasColumnOrder(5)
                   .HasMaxLength(500);

            builder.Property(o => o.ConfirmedOn)
                   .HasColumnName("confirmed_on")
                   .HasColumnOrder(6);

            builder.Property(o => o.OrderStatusId)
                   .HasColumnName("order_status_id")
                   .HasColumnOrder(7)
                   .IsRequired();

            builder.Property(o => o.CustomerId)
                   .HasColumnName("customer_id")
                   .HasColumnOrder(8)
                   .IsRequired();

            builder.Property(o => o.CouponId)
                   .HasColumnName("coupon_id")
                   .HasColumnOrder(9);

            builder.OwnsOne(a => a.FullAddress, p =>
            {
                p.Property(x => x.PostalCode)
                 .HasColumnName("postal_code")
                 .HasColumnOrder(10)
                 .HasMaxLength(8)
                 .IsRequired();

                p.HasIndex(x => x.PostalCode)
                 .HasDatabaseName("ix_order_postal_code");

                p.Property(x => x.Street)
                 .HasColumnName("street")
                 .HasColumnOrder(11)
                 .HasMaxLength(250)
                 .IsRequired();

                p.Property(a => a.Number)
                 .HasColumnName("number")
                 .HasColumnOrder(12)
                 .HasMaxLength(30)
                 .IsRequired();

                p.Property(a => a.Complement)
                 .HasColumnName("complement")
                 .HasColumnOrder(13)
                 .HasMaxLength(250)
                 .IsRequired(false);

                p.Property(a => a.District)
                 .HasColumnName("district")
                 .HasColumnOrder(14)
                 .HasMaxLength(150)
                 .IsRequired();

                p.Property(a => a.City)
                 .HasColumnName("city")
                 .HasColumnOrder(15)
                 .HasMaxLength(150)
                 .IsRequired();

                p.HasIndex(x => x.City)
                 .HasDatabaseName("ix_order_city");

                p.Property(x => x.State)
                 .HasColumnName("state")
                 .HasColumnOrder(16)
                 .HasMaxLength(2)
                 .IsRequired();

                p.HasIndex(x => x.State)
                 .HasDatabaseName("ix_order_state");

                p.Property(a => a.Country)
                 .HasColumnName("country")
                 .HasColumnOrder(17)
                 .HasMaxLength(50)
                 .IsRequired();
            });

            builder.HasOne(o => o.OrderStatus)
                   .WithMany()
                   .HasForeignKey(o => o.OrderStatusId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Customer)
                   .WithMany()
                   .HasForeignKey(o => o.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Coupon)
                   .WithMany()
                   .HasForeignKey(o => o.CouponId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
