
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class PaymentGatewayConfiguration : BaseEntityConfiguration<PaymentGateway>
    {
        public override void Configure(EntityTypeBuilder<PaymentGateway> builder)
        {
            base.Configure(builder);

            builder.ToTable("payment_gateway");

            builder.Property(pg => pg.Name)
                   .HasColumnName("name")
                   .HasColumnOrder(1)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(pg => pg.Flag)
                   .HasColumnName("flag")
                   .HasColumnOrder(2)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.OwnsOne(t => t.EmailAddress, p =>
            {
                p.Property(x => x.Value)
                 .HasColumnName("email_address")
                 .HasColumnOrder(3)
                 .HasMaxLength(256)
                 .IsRequired(false);

                p.HasIndex(x => x.Value)
                 .IsUnique()
                 .HasFilter("email_address IS NOT NULL")
                 .HasDatabaseName("ix_payment_gateway_email_address");
            }).Navigation(x => x.EmailAddress)
              .IsRequired();

            builder.OwnsOne(t => t.Mobilephone, p =>
            {
                p.Property(x => x.Value)
                 .HasColumnName("mobile_phone")
                 .HasColumnOrder(4)
                 .HasMaxLength(20)
                 .IsRequired(false);

                p.HasIndex(x => x.Value)
                 .IsUnique()
                 .HasFilter("mobile_phone IS NOT NULL")
                 .HasDatabaseName("ix_payment_gateway_mobile_phone");
            }).Navigation(x => x.Mobilephone)
              .IsRequired();

            builder.OwnsOne(t => t.Telephone, p =>
            {
                p.Property(x => x.Value)
                 .HasColumnName("telephone")
                 .HasColumnOrder(5)
                 .HasMaxLength(20)
                 .IsRequired(false);

                p.HasIndex(x => x.Value)
                 .IsUnique()
                 .HasFilter("telephone IS NOT NULL")
                 .HasDatabaseName("ix_payment_gateway_telephone");
            }).Navigation(x => x.Telephone)
              .IsRequired();

            builder.Property(pg => pg.Priority)
                   .HasColumnName("priority")
                   .HasColumnOrder(6)
                   .HasDefaultValue(0);

            builder.Property(pg => pg.EnvironmentKey)
                   .HasColumnName("environment_key")
                   .HasColumnOrder(7)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(pg => pg.ApiBaseUrl)
                   .HasColumnName("api_base_url")
                   .HasColumnOrder(8)
                   .HasMaxLength(500)
                   .IsRequired(false);

            builder.HasIndex(pg => pg.Flag)
                   .IsUnique()
                   .HasDatabaseName("ix_payment_gateway_flag_unique");

            builder.HasIndex(pg => pg.Name)
                   .IsUnique()
                   .HasDatabaseName("ix_name_unique");

            builder.HasIndex(pg => pg.EnvironmentKey)
                   .IsUnique()
                   .HasDatabaseName("ix_payment_gateway_environment_key_unique");
        }
    }
}
