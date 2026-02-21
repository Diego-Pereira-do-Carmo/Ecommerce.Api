
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class BrandConfiguration : BaseEntityConfiguration<Brand>
    {
        public override void Configure(EntityTypeBuilder<Brand> builder)
        {
            base.Configure(builder);

            builder.ToTable("brand", b =>
            {
                b.HasCheckConstraint("CK_Brand_Name_MinLength", "char_length(name) >= 2");
                b.HasCheckConstraint("CK_Brand_UrlKey_Format", "url_key ~ '^[a-z0-9-]+$'");
            });

            builder.Property(b => b.Name)
                   .HasColumnName("name")
                   .HasColumnOrder(1)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(b => b.UrlKey)
                   .HasColumnName("url_key")
                   .HasColumnOrder(2)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(b => b.LogoUrl)
                   .HasColumnName("logo_url")
                   .HasColumnOrder(3)
                   .HasMaxLength(250);

            builder.OwnsOne(t => t.Cnpj, p =>
            {
                p.Property(x => x.Number)
                 .HasColumnName("cnpj")
                 .HasColumnOrder(4)
                 .HasMaxLength(14)
                 .IsRequired();

                p.HasIndex(x => x.Number)
                 .IsUnique()
                 .HasDatabaseName("ix_brand_cnpj");
            });

            builder.OwnsOne(t => t.EmailAddress, p =>
            {
                p.Property(x => x.Value)
                 .HasColumnName("email_address")
                 .HasColumnOrder(5)
                 .HasMaxLength(256)
                 .IsRequired(false);

                p.HasIndex(x => x.Value)
                 .IsUnique()
                 .HasFilter("email_address IS NOT NULL")
                 .HasDatabaseName("ix_brand_email_address");
            }).Navigation(x => x.EmailAddress)
              .IsRequired();

            builder.OwnsOne(t => t.Mobilephone, p =>
            {
                p.Property(x => x.Value)
                 .HasColumnName("mobile_phone")
                 .HasColumnOrder(6)
                 .HasMaxLength(20)
                 .IsRequired(false);

                p.HasIndex(x => x.Value)
                 .IsUnique()
                 .HasFilter("mobile_phone IS NOT NULL")
                 .HasDatabaseName("ix_brand_mobile_phone");
            }).Navigation(x => x.Mobilephone)
              .IsRequired();

            builder.OwnsOne(t => t.Telephone, p =>
            {
                p.Property(x => x.Value)
                 .HasColumnName("telephone")
                 .HasColumnOrder(7)
                 .HasMaxLength(20)
                 .IsRequired(false);

                p.HasIndex(x => x.Value)
                 .IsUnique()
                 .HasFilter("telephone IS NOT NULL")
                 .HasDatabaseName("ix_brand_telephone");
            }).Navigation(x => x.Telephone)
              .IsRequired();

            builder.HasIndex(b => b.Name)
                   .IsUnique()
                   .HasDatabaseName("ix_brand_name");

            builder.HasIndex(b => b.UrlKey)
                   .IsUnique()
                   .HasDatabaseName("ix_brand_url_key");

            builder.HasMany(b => b.Products)
                   .WithOne(p => p.Brand)
                   .HasForeignKey(p => p.BrandId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
