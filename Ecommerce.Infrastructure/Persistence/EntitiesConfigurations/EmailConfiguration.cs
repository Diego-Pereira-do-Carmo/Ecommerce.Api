
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class EmailConfiguration : BaseEntityConfiguration<Email>
    {
        public override void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("email", e =>
            {
                e.HasCheckConstraint("CK_Email_Subject_MinLength", "char_length(subject) >= 3");
                e.HasCheckConstraint("CK_Email_Body_MinLength", "char_length(body) >= 3");
                e.HasCheckConstraint("CK_Email_MinLength", "char_length(email_address) >= 5");
            });

            builder.OwnsOne(e => e.EmailAddress, p =>
            {
                p.Property(x => x.Value)
                 .HasColumnName("email_address")
                 .HasColumnOrder(1)
                 .HasMaxLength(256)
                 .IsRequired();

                p.HasIndex(x => x.Value)
                 .HasDatabaseName("ix_email_address");
            });

            builder.Property(e => e.Subject)
                   .HasColumnName("subject")
                   .HasColumnOrder(2)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(e => e.Body)
                   .HasColumnName("body")
                   .HasColumnOrder(3)
                   .HasColumnType("text")
                   .IsUnicode(true)
                   .IsRequired();

            builder.Property(e => e.SentAttempts)
                   .HasColumnName("sent_attempts")
                   .HasColumnOrder(4)
                   .HasDefaultValue(0);

            builder.Property(e => e.LastErrorMessage)
                   .HasColumnName("last_error_message")
                   .HasColumnOrder(5);

            builder.Property(e => e.SentAt)
                   .HasColumnName("sent_at")
                   .HasColumnOrder(6);

            builder.Property(e => e.TemplateEmailId)
                   .HasColumnName("template_email_id")
                   .HasColumnOrder(7)
                   .IsRequired();

            builder.Property(e => e.EmailStatusId)
                   .HasColumnName("email_status_id")
                   .HasColumnOrder(8)
                   .IsRequired();

            builder.Property(e => e.EntityMetadataId)
                   .HasColumnName("entity_metadata_id")
                   .HasColumnOrder(9)
                   .IsRequired();

            builder.Property(e => e.ReferenceId)
                   .HasColumnName("reference_id")
                   .HasColumnOrder(10)
                   .IsRequired();

            builder.HasOne(e => e.TemplateEmail)
                   .WithMany()
                   .HasForeignKey(e => e.TemplateEmailId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.EntityMetadata)
                   .WithMany()
                   .HasForeignKey(e => e.EntityMetadataId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => new { e.EntityMetadataId, e.ReferenceId })
                   .HasDatabaseName("ix_email_metadata_reference");

            builder.HasOne(e => e.EmailStatus)
                   .WithMany()
                   .HasForeignKey(e => e.EmailStatusId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
