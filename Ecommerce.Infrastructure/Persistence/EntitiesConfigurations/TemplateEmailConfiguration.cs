
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class TemplateEmailConfiguration : BaseEntityConfiguration<TemplateEmail>
    {
        public override void Configure(EntityTypeBuilder<TemplateEmail> builder)
        {
            base.Configure(builder);

            builder.ToTable("template_email", x =>
            {
                x.HasCheckConstraint("CK_TemplateEmail_Name_MinLength", "char_length(name) >= 3");
                x.HasCheckConstraint("CK_TemplateEmail_Subject_MinLength", "char_length(subject) >= 3");
                x.HasCheckConstraint("CK_TemplateEmail_Body_MinLength", "char_length(body) >= 3");
            });

            builder.Property(x => x.Name)
                   .HasColumnName("name")
                   .HasColumnOrder(1)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.Subject)
                   .HasColumnName("subject")
                   .HasColumnOrder(2)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(x => x.Body)
                   .HasColumnName("body")
                   .HasColumnOrder(3)
                   .HasColumnType("text")
                   .IsUnicode(true)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasColumnName("description")
                   .HasColumnOrder(4)
                   .HasMaxLength(500);

            builder.HasMany(x => x.Emails)
                   .WithOne(e => e.TemplateEmail)
                   .HasForeignKey(e => e.TemplateEmailId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.Name)
                   .IsUnique()
                   .HasDatabaseName("ix_template_email_name");
        }
    }
}
