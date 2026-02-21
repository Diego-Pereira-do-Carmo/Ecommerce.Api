
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class AccessProfileConfiguration : BaseEntityConfiguration<AccessProfile>
    {
        public override void Configure(EntityTypeBuilder<AccessProfile> builder)
        {
            base.Configure(builder);

            builder.ToTable("access_profile", t =>
            {
                t.HasCheckConstraint("CK_AccessProfile_Name_MinLength", "char_length(name) >= 3");
                t.HasCheckConstraint("CK_AccessProfile_Description_MinLength", "char_length(description) >= 3");
            });

            builder.Property(a => a.Name)
                   .HasColumnName("name")
                   .HasColumnOrder(1)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(a => a.Description)
                   .HasColumnName("description")
                   .HasColumnOrder(2)
                   .HasMaxLength(150);

            builder.HasIndex(a => a.Name)
                   .IsUnique()
                   .HasDatabaseName("ix_access_profile_name");
        }
    }
}
