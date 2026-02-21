
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class AccessProfileUserConfiguration : BaseEntityConfiguration<AccessProfileUser>
    {
        public override void Configure(EntityTypeBuilder<AccessProfileUser> builder)
        {
            base.Configure(builder);

            builder.ToTable("access_profile_user");

            builder.Property(apu => apu.UserId)
                   .HasColumnName("user_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(apu => apu.AccessProfileId)
                   .HasColumnName("access_profile_id")
                   .HasColumnOrder(2)
                   .IsRequired();

            builder.HasIndex(apu => new {apu.UserId, apu.AccessProfileId})
                   .IsUnique()
                   .HasDatabaseName("ix_access_profile_user_unique_combination");

            builder.HasIndex(x => x.AccessProfileId)
                    .HasDatabaseName("ix_access_profile_user_profile_id");

            builder.HasOne(apu => apu.User)
                   .WithMany(apu => apu.AccessProfileUsers)
                   .HasForeignKey(apu => apu.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(apu => apu.AccessProfile)
                   .WithMany(apu => apu.AccessProfileUsers)
                   .HasForeignKey(apu => apu.AccessProfileId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
