
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class LogisticMethodConfiguration : BaseEntityConfiguration<LogisticMethod>
    {
        public override void Configure(EntityTypeBuilder<LogisticMethod> builder)
        {
            base.Configure(builder);

            builder.ToTable("logistics_method");

            builder.Property(x => x.LogisticsProviderId)
                   .HasColumnName("logistics_provider_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(x => x.Name)
                   .HasColumnName("name")
                   .HasColumnOrder(2)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasColumnName("description")
                   .HasColumnOrder(3)
                   .HasMaxLength(500);

            builder.Property(x => x.Code)
                   .HasColumnName("code")
                   .HasColumnOrder(4)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.TrackingUrlTemplate)
                   .HasColumnName("tracking_url_template")
                   .HasColumnOrder(5)
                   .HasMaxLength(500);

            builder.Property(x => x.EstimatedDeliveryTimeHours)
                   .HasColumnName("estimated_delivery_time_hours")
                   .HasColumnOrder(6);

            builder.Property(x => x.BasePrice)
                   .HasColumnName("base_price")
                   .HasColumnOrder(7)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(x => x.MinOrderAmount)
                   .HasColumnName("min_order_amount")
                   .HasColumnOrder(8)
                   .HasPrecision(18, 2);

            builder.Property(x => x.IsFreeShipping)
                   .HasColumnName("is_free_shipping")
                   .HasColumnOrder(9)
                   .HasDefaultValue(false);

            builder.ComplexProperty(x => x.MaxDimensions, d =>
            {
                d.Property(p => p.Length)
                 .HasColumnName("max_length")
                 .HasPrecision(12, 4)
                 .HasColumnOrder(10)
                 .IsRequired();

                d.Property(p => p.Width)
                 .HasColumnName("max_width")
                 .HasPrecision(12, 4)
                 .HasColumnOrder(11)
                 .IsRequired();

                d.Property(p => p.Height)
                 .HasColumnName("max_height")
                 .HasPrecision(12, 4)
                 .HasColumnOrder(12)
                 .IsRequired();

                d.Property(p => p.Weight)
                 .HasColumnName("max_weight")
                 .HasPrecision(12, 4)
                 .HasColumnOrder(13)
                 .IsRequired();
            });

            builder.Property(x => x.RequiresSignature)
                   .HasColumnName("requires_signature")
                   .HasColumnOrder(14)
                   .HasDefaultValue(false);

            builder.HasOne(x => x.LogisticsProvider)
                   .WithMany(p => p.LogisticsMethods)
                   .HasForeignKey(x => x.LogisticsProviderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.LogisticsProviderId, x.Name })
                   .HasDatabaseName("ix_logistics_method_provider_id_name");

            builder.HasIndex(x => x.LogisticsProviderId)
                   .HasDatabaseName("ix_logistics_method_provider_id");

            builder.HasIndex(x => x.Code)
                   .IsUnique()
                   .HasDatabaseName("ix_logistics_method_code");

            builder.HasIndex(x => x.Name)
                   .HasDatabaseName("ix_logistics_method_Name");
        }
    }
}
