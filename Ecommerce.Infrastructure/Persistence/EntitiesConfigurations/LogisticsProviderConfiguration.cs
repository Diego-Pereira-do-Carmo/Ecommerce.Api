
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class LogisticsProviderConfiguration : BaseEntityConfiguration<LogisticProvider>
    {
        public override void Configure(EntityTypeBuilder<LogisticProvider> builder)
        {
            base.Configure(builder);

            builder.ToTable("logistics_provider");

            builder.Property(x => x.Name)
                   .HasColumnName("name")
                   .HasColumnOrder(1)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.Code)
                   .HasColumnName("code")
                   .HasColumnOrder(2)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.OwnsOne(t => t.Cnpj, p =>
            {
                p.Property(x => x.Number)
                 .HasColumnName("cnpj")
                 .HasColumnOrder(3)
                 .HasMaxLength(14)
                 .IsRequired();

                p.HasIndex(x => x.Number)
                 .IsUnique()
                 .HasDatabaseName("ix_logistics_provider_cnpj");
            });

            builder.OwnsOne(t => t.EmailAddress, p =>
            {
                p.Property(x => x.Value)
                 .HasColumnName("email_address")
                 .HasColumnOrder(4)
                 .HasMaxLength(256)
                 .IsRequired(false);

                p.HasIndex(x => x.Value)
                 .IsUnique()
                 .HasFilter("email_address IS NOT NULL")
                 .HasDatabaseName("ix_logistics_provider_email_address");
            }).Navigation(x => x.EmailAddress)
              .IsRequired();

            builder.OwnsOne(t => t.Mobilephone, p =>
            {
                p.Property(x => x.Value)
                 .HasColumnName("mobile_phone")
                 .HasColumnOrder(5)
                 .HasMaxLength(20)
                 .IsRequired(false);

                p.HasIndex(x => x.Value)
                 .IsUnique()
                 .HasFilter("mobile_phone IS NOT NULL")
                 .HasDatabaseName("ix_logistics_provider_mobile_phone");
            }).Navigation(x => x.Mobilephone)
              .IsRequired();

            builder.OwnsOne(t => t.Telephone, p =>
            {
                p.Property(x => x.Value)
                 .HasColumnName("telephone")
                 .HasColumnOrder(6)
                 .HasMaxLength(20)
                 .IsRequired(false);

                p.HasIndex(x => x.Value)
                 .IsUnique()
                 .HasFilter("telephone IS NOT NULL")
                 .HasDatabaseName("ix_logistics_provider_telephone");
            }).Navigation(x => x.Telephone)
              .IsRequired();

            builder.Property(x => x.Website)
                   .HasColumnName("website")
                   .HasColumnOrder(7)
                   .HasMaxLength(255);

            builder.Property(x => x.LogoUrl)
                   .HasColumnName("logo_url")
                   .HasColumnOrder(8)
                   .HasMaxLength(500);

            builder.HasMany(x => x.LogisticsMethods)
                   .WithOne(m => m.LogisticsProvider)
                   .HasForeignKey(m => m.LogisticsProviderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.Code)
                   .IsUnique()
                   .HasDatabaseName("ix_logistics_provider_code");

            builder.HasIndex(x => x.Name)
                   .HasDatabaseName("ix_logistics_provider_name");
        }
    }
}
