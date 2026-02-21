using Ecommerce.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base
{
    internal abstract class BaseEntityConfiguration<TBase> : IEntityTypeConfiguration<TBase> 
        where TBase : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("id")
                   .HasColumnOrder(0);

            builder.Property(x => x.IsDeleted)
                   .HasColumnName("is_deleted")
                   .HasColumnOrder(100)
                   .HasDefaultValue(false)                  
                   .IsRequired();

            builder.Property(x => x.IsActive)
                   .HasColumnName("is_active")
                   .HasColumnOrder(101)
                   .HasDefaultValue(true);

            builder.Property(x => x.FriendlyCode)
                   .HasColumnName("friendly_code")
                   .HasColumnOrder(102)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(x => x.CreatedOn)
                   .HasColumnName("created_on")
                   .HasColumnOrder(103)
                   .IsRequired();

            builder.Property(x => x.CreatedBy)
                   .HasColumnName("created_by")
                   .HasColumnOrder(104)
                   .IsRequired();

            builder.Property(x => x.ModifiedOn)
                   .HasColumnName("modified_on")
                   .HasColumnOrder(105);

            builder.Property(x => x.ModifiedBy)
                   .HasColumnName("modified_by")
                   .HasColumnOrder(106);

            builder.Property(x => x.DeletedOn)
                   .HasColumnName("deleted_on")
                   .HasColumnOrder(107);

            builder.Property(x => x.DeletedBy)
                   .HasColumnName("deleted_by")
                   .HasColumnOrder(108);

            builder.HasIndex(x => x.FriendlyCode)
                   .IsUnique()
                   .HasDatabaseName($"ix_{typeof(TBase).Name.ToLower()}_friendly_code");

            builder.HasIndex(x => x.IsDeleted)
                   .HasFilter("is_deleted = false")
                   .HasDatabaseName($"ix_{typeof(TBase).Name.ToLower()}_not_deleted");
        }
    }
}
