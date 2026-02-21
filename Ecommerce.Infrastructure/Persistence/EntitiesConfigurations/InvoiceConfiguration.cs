
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class InvoiceConfiguration : BaseEntityConfiguration<Invoice>
    {
        public override void Configure(EntityTypeBuilder<Invoice> builder)
        {
            base.Configure(builder);

            builder.ToTable("invoice", t =>
            {
                t.HasCheckConstraint("CK_Invoice_TotalAmount_Positive", "total_amount >= 0");
            });

            builder.Property(i => i.OrderId)
                   .HasColumnName("order_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(i => i.ExternalId)
                   .HasColumnName("external_id")
                   .HasColumnOrder(2)
                   .IsRequired(false);

            builder.Property(i => i.Number)
                   .HasColumnName("number")
                   .HasColumnOrder(3)
                   .HasMaxLength(20)
                   .IsRequired(false);

            builder.Property(i => i.Series)
                   .HasColumnName("series")
                   .HasColumnOrder(4)
                   .HasMaxLength(5)
                   .IsRequired(false);

            builder.Property(i => i.AccessKey)
                    .HasColumnName("access_key")
                    .HasColumnOrder(5)
                    .HasMaxLength(44)
                    .IsFixedLength()
                   .IsRequired(false);

            builder.Property(i => i.TotalAmount)
                   .HasColumnName("total_amount")
                   .HasColumnOrder(6)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(i => i.XmlUrl)
                   .HasColumnName("xml_url")
                   .HasColumnOrder(7)
                   .HasMaxLength(500);

            builder.Property(i => i.PdfUrl)
                   .HasColumnName("pdf_url")
                   .HasColumnOrder(8)
                   .HasMaxLength(500);

            builder.Property(i => i.ErrorMessage)
                   .HasColumnName("error_message")
                   .HasColumnOrder(9)
                   .HasMaxLength(1000);

            builder.Property(i => i.AuthorizedOn)
                   .HasColumnName("authorized_on")
                   .HasColumnOrder(10)
                   .IsRequired(false);

            builder.HasOne(i => i.Order)
                   .WithOne(o => o.Invoice)
                   .HasForeignKey<Invoice>(i => i.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.InvoiceStatus)
                   .WithMany()
                   .HasForeignKey(i => i.InvoiceStatusId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(i => new { i.Number, i.Series })
                   .IsUnique()
                   .HasDatabaseName("ix_invoice_number_series");

            builder.HasIndex(i => i.ExternalId)
                   .IsUnique()
                   .HasDatabaseName("ix_invoice_external_id");
        }
    }
}
