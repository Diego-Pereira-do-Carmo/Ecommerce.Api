
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class CustomerConfiguration : BaseEntityConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            var validCustomerTypes = string.Join(", ", Enum.GetNames<CustomerTypeEnum>().Select(n => $"'{n}'"));
            var validGenderTypes = string.Join(", ", Enum.GetNames<GenderTypeEnum>().Select(n => $"'{n}'"));

            builder.ToTable("customer", t =>
            {
                t.HasCheckConstraint("CK_Customer_NationalId_Length", "char_length(national_id) IN (11, 14)");
                t.HasCheckConstraint("CK_Customer_Type_Rules",
                "(customer_type = 'Physical' AND corporate_name IS NULL AND trade_name IS NULL AND state_registration IS NULL AND birth_date IS NOT NULL AND gender_type IS NOT NULL) OR " +
                "(customer_type = 'Legal' AND corporate_name IS NOT NULL AND birth_date IS NULL AND gender_type IS NULL)");

                t.HasCheckConstraint("CK_Customer_Type_Enum", $"customer_type IN ({validCustomerTypes})");
                t.HasCheckConstraint("CK_Gender_Type_Enum", $"gender_type IN ({validGenderTypes})");
            });

            builder.OwnsOne(t => t.NationalId, p =>
            {
                p.Property(x => x.Number)
                 .HasColumnName("national_id")
                 .HasColumnOrder(1)
                 .HasMaxLength(14)
                 .IsRequired();

                p.HasIndex(x => x.Number)
                 .IsUnique()
                 .HasDatabaseName("ix_national_id");
            });

            builder.Property(c => c.CorporateName)
                   .HasColumnName("corporate_name")
                   .HasColumnOrder(2)
                   .HasMaxLength(250);

            builder.Property(c => c.TradeName)
                   .HasColumnName("trade_name")
                   .HasColumnOrder(3)
                   .HasMaxLength(250);

            builder.Property(c => c.StateRegistration)
                   .HasColumnName("state_registration")
                   .HasColumnOrder(4)
                   .HasMaxLength(50);

            builder.Property(c => c.CustomerType)
                   .HasColumnName("customer_type")
                   .HasColumnOrder(5)
                   .HasConversion<string>()
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(c => c.GenderType)
                   .HasColumnName("gender_type")
                   .HasColumnOrder(6)
                   .HasConversion<string>()
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(c => c.BirthDate)
                   .HasColumnName("birth_date")
                   .HasColumnOrder(7);

            builder.Property(c => c.NewsletterSubscribed)
                   .HasColumnName("newsletter_subscribed")
                   .HasColumnOrder(8)
                   .HasDefaultValue(false)
                   .IsRequired();

            builder.Property(c => c.UserId)
                   .HasColumnName("user_id")
                   .HasColumnOrder(9)
                   .IsRequired();

            builder.HasIndex(c => c.UserId)
                   .IsUnique()
                   .HasDatabaseName("ix_customer_user_id");

            builder.HasIndex(c => c.TradeName)
                   .HasDatabaseName("ix_customer_trade_name");

            builder.HasOne(c => c.User)
                   .WithOne(u => u.Customer)
                   .HasForeignKey<Customer>(c => c.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Addresses)
                   .WithOne(a => a.Customer)
                   .HasForeignKey(a => a.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.CartItems)
                   .WithOne(ci => ci.Customer)
                   .HasForeignKey(a => a.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
