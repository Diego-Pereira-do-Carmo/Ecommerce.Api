
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.Entities
{
    public class Logistic : BaseEntity
    {
        public Guid OrderId { get; private set; }
        public Guid LogisticsMethodId { get; private set; }
        public Guid LogisticsStatusId { get; private set; }

        public string? TrackingCode { get; private set; }
        public string? TrackingUrl { get; private set; }
        public decimal LogisticsCost { get; private set; }
        public int VolumeNumber { get; private set; }
        public string? Observations { get; private set; }
        public DimensionsValueObject Dimensions { get; private set; } = null!;

        public DateTime? PostedOn { get; private set; }
        public DateTime? EstimatedDeliveryDate { get; private set; }
        public DateTime? DeliveredOn { get; private set; }

        public Order Order { get; private set; } = null!;
        public LogisticStatus LogisticsStatus { get; private set; } = null!;
        public LogisticMethod LogisticsMethod { get; private set; } = null!;

        protected Logistic() { }

        public Logistic(Guid orderId, Guid logisticsMethodId, Guid logisticsStatusId, decimal cost, int volumes, DimensionsValueObject dimensions)
        {
            Guard.AgainstEmptyGuid(orderId, nameof(orderId));
            Guard.AgainstEmptyGuid(logisticsMethodId, nameof(logisticsMethodId));
            Guard.AgainstEmptyGuid(logisticsStatusId, nameof(logisticsStatusId));
            Guard.AgainstMinValue(cost, 0m, nameof(cost));
            Guard.AgainstMinValue(volumes, 1, nameof(volumes));

            OrderId = orderId;
            LogisticsMethodId = logisticsMethodId;
            LogisticsStatusId = logisticsStatusId;
            LogisticsCost = cost;
            VolumeNumber = volumes;
            Dimensions = dimensions;
        }
    }
}
