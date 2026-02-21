
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class LogisticConfiguration : BaseEntityConfiguration<Logistic>
    {
        public override void Configure(EntityTypeBuilder<Logistic> builder)
        {
            base.Configure(builder);

            builder.ToTable("logistics", x =>
            {
                x.HasCheckConstraint("CK_Logistics_logistics_cost_Positive", "logistics_cost >= 0");
                x.HasCheckConstraint("CK_Logistics_volume_number_Positive", "volume_number >= 1");
            });

            builder.Property(x => x.OrderId)
                   .HasColumnName("order_id")
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(x => x.TrackingCode)
                   .HasColumnName("tracking_code")
                   .HasColumnOrder(2)
                   .HasMaxLength(150);

            builder.Property(x => x.TrackingUrl)
                   .HasColumnName("tracking_url")
                   .HasColumnOrder(3)
                   .HasMaxLength(1000);

            builder.Property(x => x.LogisticsCost)
                   .HasColumnName("logistics_cost")
                   .HasColumnOrder(4)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(x => x.VolumeNumber)
                   .HasColumnName("volume_number")
                   .HasColumnOrder(5)
                   .HasDefaultValue(1)
                   .IsRequired();

            builder.Property(x => x.Observations)
                   .HasColumnName("observations")
                   .HasColumnOrder(6)
                   .HasMaxLength(2000);

            builder.ComplexProperty(x => x.Dimensions, d =>
            {
                d.Property(p => p.Length)
                 .HasColumnName("length")
                 .HasPrecision(12, 4)
                 .HasColumnOrder(7)
                 .IsRequired();

                d.Property(p => p.Width)
                 .HasColumnName("width")
                 .HasPrecision(12, 4)
                 .HasColumnOrder(8)
                 .IsRequired();

                d.Property(p => p.Height)
                 .HasColumnName("height")
                 .HasPrecision(12, 4)
                 .HasColumnOrder(9)
                 .IsRequired();

                d.Property(p => p.Weight)
                 .HasColumnName("weight")
                 .HasPrecision(12, 4)
                 .HasColumnOrder(10)
                 .IsRequired();
            });

            builder.Property(x => x.LogisticsMethodId)
                   .HasColumnName("logistics_method_id")
                   .HasColumnOrder(11)
                   .IsRequired();

            builder.Property(x => x.LogisticsStatusId)
                   .HasColumnName("logistics_status_id")
                   .HasColumnOrder(12)
                   .IsRequired();

            builder.Property(x => x.PostedOn)
                   .HasColumnName("posted_on")
                   .HasColumnOrder(13);

            builder.Property(x => x.EstimatedDeliveryDate)
                   .HasColumnName("estimated_delivery_date")
                   .HasColumnOrder(14);

            builder.Property(x => x.DeliveredOn)
                   .HasColumnName("delivered_on")
                   .HasColumnOrder(15);


            builder.HasOne(x => x.Order)
                   .WithMany(o => o.Logistics)
                   .HasForeignKey(x => x.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LogisticsMethod)
                   .WithMany()
                   .HasForeignKey(x => x.LogisticsMethodId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LogisticsStatus)
                   .WithMany()
                   .HasForeignKey(x => x.LogisticsStatusId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.TrackingCode)
                   .HasDatabaseName("ix_logistics_tracking_code");

            builder.HasIndex(x => new { x.OrderId, x.VolumeNumber })
                   .IsUnique()
                   .HasDatabaseName("ix_logistics_order_volume");

            builder.HasIndex(x => x.LogisticsStatusId)
                   .HasDatabaseName("ix_logistics_status_id");
        }
    }
}
