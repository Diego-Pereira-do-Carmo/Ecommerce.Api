using Ecommerce.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net.NetworkInformation;


namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base
{
    internal abstract class BaseStatusEntityConfiguration<TBaseStatus> : BaseEntityConfiguration<TBaseStatus>
        where TBaseStatus : BaseStatusEntity
    {
        public override void Configure(EntityTypeBuilder<TBaseStatus> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                   .HasColumnName("name")
                   .HasColumnOrder(1)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasColumnName("description")
                   .HasColumnOrder(2)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(x => x.Flag)
                   .HasColumnName("flag")
                   .HasColumnOrder(3)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.HasIndex(x => x.Flag)
                   .IsUnique()
                   .HasDatabaseName($"ix_{typeof(TBaseStatus).Name.ToLower()}_flag");

            builder.HasIndex(x => x.Name)
                   .IsUnique()
                   .HasDatabaseName($"ix_{typeof(TBaseStatus).Name.ToLower()}_name");
        }
    }
}
