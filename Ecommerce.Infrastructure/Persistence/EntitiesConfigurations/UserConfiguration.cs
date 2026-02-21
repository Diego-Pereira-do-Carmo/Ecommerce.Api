
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("user", t =>
            {
                t.HasCheckConstraint("CK_User_UserName_MinLength", "char_length(user_name) >= 2");
                t.HasCheckConstraint("CK_User_FirstName_MinLength", "char_length(first_name) >= 2");
                t.HasCheckConstraint("CK_User_LastName_MinLength", "char_length(last_name) >= 2");
                t.HasCheckConstraint("CK_User_FullName_MinLength", "char_length(full_name) >= 4");
                t.HasCheckConstraint("CK_User_email_address_MinLength", "char_length(email_address) >= 5");
            });

            builder.Property(u => u.UserName)
                   .HasColumnName("user_name")
                   .HasColumnOrder(1)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(u => u.FirstName)
                   .HasColumnName("first_name")
                   .HasColumnOrder(2)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(u => u.LastName)
                   .HasColumnName("last_name")
                   .HasColumnOrder(3)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(u => u.FullName)
                   .HasColumnName("full_name")
                   .HasColumnOrder(4)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.OwnsOne(t => t.EmailAddress, p =>
            {
                p.Property(x => x.Value)
                 .HasColumnName("email_address")
                 .HasColumnOrder(5)
                 .HasMaxLength(256)
                 .IsRequired();

                p.HasIndex(x => x.Value)
                 .IsUnique()
                 .HasFilter("email_address IS NOT NULL")
                 .HasDatabaseName("ix_user_email_address");
            });

            builder.OwnsOne(t => t.Mobilephone, p =>
            {
                p.Property(x => x.Value)
                 .HasColumnName("mobile_phone")
                 .HasColumnOrder(6)
                 .HasMaxLength(20)
                 .IsRequired();

                p.HasIndex(x => x.Value)
                 .IsUnique()
                 .HasFilter("mobile_phone IS NOT NULL")
                 .HasDatabaseName("ix_user_mobile_phone");
            });

            builder.Property(u => u.PasswordHash)
                   .HasColumnName("password_hash")
                   .HasColumnOrder(7)
                   .IsRequired();

            builder.Property(u => u.SecurityStamp)
                   .HasColumnName("security_stamp")
                   .HasColumnOrder(8)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(u => u.AccessFailedCount)
                   .HasColumnName("access_failed_count")
                   .HasColumnOrder(9)
                   .HasDefaultValue(0);

            builder.Property(u => u.LastAccess)
                   .HasColumnName("last_access");

            builder.Property(u => u.LockoutEnd)
                   .HasColumnName("lockout_end");

            builder.HasIndex(u => u.FirstName)
                   .HasDatabaseName("ix_user_first_name");

            builder.Property(x => x.IsEmailAddressConfirmed)
                   .HasColumnName("is_email_address_confirmed")
                   .HasDefaultValue(false)
                   .IsRequired();

            builder.HasMany(u => u.AccessProfileUsers)
                   .WithOne(ap => ap.User)
                   .HasForeignKey(ap => ap.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
