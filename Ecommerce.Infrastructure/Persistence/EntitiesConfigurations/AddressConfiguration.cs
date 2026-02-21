
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class AddressConfiguration : BaseEntityConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);

            var validTypes = string.Join(", ", Enum.GetNames<AddressTypeEnum>().Select(n => $"'{n}'"));

            builder.ToTable("address", t =>
            {
                t.HasCheckConstraint("CK_Address_ZipCode_Validation",
                    "(country = 'Brasil' AND char_length(postal_code) = 8) OR " +
                    "(country <> 'Brasil' AND char_length(postal_code) >= 3)");

                t.HasCheckConstraint("CK_Address_State_Validation",
                    "(country = 'Brasil' AND char_length(state) = 2) OR (country <> 'Brasil')");

                t.HasCheckConstraint("CK_Address_Type_Enum", $"address_type IN ({validTypes})");
            });

            builder.Property(a => a.CustomerId)
                   .HasColumnName("customer_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.OwnsOne(a => a.FullAddress, p =>
            {
                p.Property(x => x.PostalCode)
                 .HasColumnName("postal_code")
                 .HasColumnOrder(2)
                 .HasMaxLength(8)
                 .IsRequired();

                p.HasIndex(x => x.PostalCode)
                 .HasDatabaseName("ix_address_postal_code");

                p.Property(x => x.Street)
                 .HasColumnName("street")
                 .HasColumnOrder(3)
                 .HasMaxLength(250)
                 .IsRequired();

                p.Property(a => a.Number)
                 .HasColumnName("number")
                 .HasColumnOrder(4)
                 .HasMaxLength(30)
                 .IsRequired();

                p.Property(a => a.Complement)
                 .HasColumnName("complement")
                 .HasColumnOrder(5)
                 .HasMaxLength(250)
                 .IsRequired(false);

                p.Property(a => a.District)
                 .HasColumnName("district")
                 .HasColumnOrder(6)
                 .HasMaxLength(150)
                 .IsRequired();

                p.Property(a => a.City)
                 .HasColumnName("city")
                 .HasColumnOrder(7)
                 .HasMaxLength(150)
                 .IsRequired();

                p.HasIndex(x => x.City)
                 .HasDatabaseName("ix_address_city");

                p.Property(x => x.State)
                 .HasColumnName("state")
                 .HasColumnOrder(8)
                 .HasMaxLength(2)
                 .IsRequired();

                p.HasIndex(x => x.State)
                 .HasDatabaseName("ix_address_state");

                p.Property(a => a.Country)
                 .HasColumnName("country")
                 .HasColumnOrder(9)
                 .HasMaxLength(50)
                 .IsRequired();
            });

            builder.Property(a => a.AddressType)
                   .HasColumnName("address_type")
                   .HasColumnOrder(10)
                   .HasConversion<string>()
                   .HasMaxLength(20)
                   .IsRequired();

            builder.HasIndex(a => new { a.CustomerId, a.AddressType })
                   .HasDatabaseName("ix_address_customer_type");

            builder.HasIndex(a => a.CustomerId)
                   .HasDatabaseName("ix_address_customer_id");

            builder.HasOne(a => a.Customer)
                   .WithMany(c => c.Addresses)
                   .HasForeignKey(a => a.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
