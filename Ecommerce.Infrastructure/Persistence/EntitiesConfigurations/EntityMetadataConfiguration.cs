
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class EntityMetadataConfiguration : IEntityTypeConfiguration<EntityMetadata>
    {
        public void Configure(EntityTypeBuilder<EntityMetadata> builder)
        {
            builder.ToTable("entity_metadata", t =>
                   t.HasCheckConstraint("CK_EntityMetadata_Code_Positive", "char_length(entity_code) > 0"));
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("id")
                   .HasColumnOrder(0);

            builder.Property(e => e.EntityName)
                   .HasColumnName("entity_name")
                   .HasColumnOrder(1)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.EntityCode)
                   .HasColumnName("entity_code")
                   .HasColumnType("varchar(7)") 
                   .HasMaxLength(7)           
                   .IsFixedLength()            
                   .HasColumnOrder(3)
                   .IsRequired();

            builder.HasIndex(e => e.EntityName)
                   .IsUnique()
                   .HasDatabaseName("ix_entity_metadata_name");

            builder.HasIndex(e => e.EntityCode)
                   .IsUnique()
                   .HasDatabaseName("ix_entity_metadata_code");

            new EntityMetadataSeeder().Seed(builder);
        }
    }
}
