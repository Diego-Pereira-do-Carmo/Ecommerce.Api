using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class PaymentConfiguration : BaseEntityConfiguration<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            base.Configure(builder);

            builder.ToTable("payment", t =>
            {
                t.HasCheckConstraint("CK_Payment_PaidAmount_Positive", "paid_amount >= 0");
                t.HasCheckConstraint("CK_Payment_RefundedAmount_Positive", "refunded_amount >= 0");
                t.HasCheckConstraint("CK_Payment_Installments_Positive", "installments > 0");
            });

            builder.Property(p => p.PaidAmount)
                   .HasColumnName("paid_amount")
                   .HasColumnOrder(1)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(p => p.Installments)
                   .HasColumnName("installments")
                   .HasColumnOrder(2)
                   .IsRequired();

            builder.Property(p => p.PaidOn)
                   .HasColumnName("paid_on")
                   .HasColumnOrder(3);

            builder.Property(p => p.RefundedAmount)
                   .HasColumnName("refunded_amount")
                   .HasColumnOrder(4)
                   .HasPrecision(18, 2)
                   .HasDefaultValue(0.0m);

            builder.Property(p => p.RefundedOn)
                   .HasColumnName("refunded_on")
                   .HasColumnOrder(5);

            builder.Property(p => p.GatewaysStatusMessage)
                   .HasColumnName("gateway_status_message")
                   .HasColumnOrder(6)
                   .HasMaxLength(1000);

            builder.Property(p => p.PaymentLink)
                   .HasColumnName("payment_link")
                   .HasColumnOrder(7)
                   .HasMaxLength(1000);

            builder.Property(p => p.ReceiptLink)
                   .HasColumnName("receipt_link")
                   .HasColumnOrder(8)
                   .HasMaxLength(1000);

            builder.Property(p => p.ExternalTransactionId)
                   .HasColumnName("external_transaction_id")
                   .HasColumnOrder(9)
                   .HasMaxLength(1000);

            builder.Property(p => p.AuthorizationCode)
                   .HasColumnName("authorization_code")
                   .HasColumnOrder(10)
                   .HasMaxLength(1000);

            builder.Property(p => p.OrderId)
                   .HasColumnName("order_id")
                   .HasColumnOrder(11)
                   .IsRequired();

            builder.Property(p => p.PaymentGatewayId)
                   .HasColumnName("payment_gateway_id")
                   .HasColumnOrder(12)
                   .IsRequired();

            builder.Property(p => p.PaymentMethodId)
                   .HasColumnName("payment_method_id")
                   .HasColumnOrder(13)
                   .IsRequired();

            builder.Property(p => p.PaymentStatusId)
                   .HasColumnName("payment_status_id")
                   .HasColumnOrder(14)
                   .IsRequired();


            builder.HasOne(p => p.Order)
                   .WithMany(o => o.Payments)
                   .HasForeignKey(p => p.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.PaymentGateway)
                   .WithMany()
                   .HasForeignKey(p => p.PaymentGatewayId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.PaymentMethod)
                   .WithMany()
                   .HasForeignKey(p => p.PaymentMethodId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.PaymentStatus)
                   .WithMany()
                   .HasForeignKey(p => p.PaymentStatusId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.ExternalTransactionId)
                   .HasDatabaseName("ix_payment_external_transaction");

            builder.HasIndex(p => p.OrderId)
                   .HasDatabaseName("ix_payment_order_id");

            builder.HasIndex(p => p.PaymentGatewayId)
                   .HasDatabaseName("ix_payment_gateway_id");

            builder.HasIndex(p => p.PaymentMethodId)
                   .HasDatabaseName("ix_payment_method_id");

            builder.HasIndex(p => p.PaymentStatusId)
                   .HasDatabaseName("ix_payment_status_id");
        }
    }
}
