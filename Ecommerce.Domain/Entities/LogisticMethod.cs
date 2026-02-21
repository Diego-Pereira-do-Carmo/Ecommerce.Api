
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.Entities
{
    public class LogisticMethod : BaseEntity        
    {
        public Guid LogisticsProviderId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public string? TrackingUrlTemplate { get; private set; }
        public decimal BasePrice { get; private set; }
        public decimal? MinOrderAmount { get; private set; }
        public bool IsFreeShipping { get; private set; }
        public int EstimatedDeliveryTimeHours { get; private set; }
        public DimensionsValueObject MaxDimensions { get; private set; } = null!;
        public bool RequiresSignature { get; private set; }

        public LogisticProvider LogisticsProvider { get; private set; } = null!;


        protected LogisticMethod() { }

        public LogisticMethod(
        Guid logisticsProviderId,
        string name,
        string code,
        decimal basePrice,
        int estimatedDeliveryTimeHours,
        DimensionsValueObject maxDimensions)
        {
            Guard.AgainstEmptyGuid(logisticsProviderId, nameof(logisticsProviderId));
            Guard.AgainstNullOrEmpty(name, nameof(name));
            Guard.AgainstNullOrEmpty(code, nameof(code));
            Guard.AgainstMinValue(basePrice, 0m, nameof(basePrice));
            Guard.AgainstMinValue(estimatedDeliveryTimeHours, 0, nameof(estimatedDeliveryTimeHours));

            LogisticsProviderId = logisticsProviderId;
            Name = name;
            Code = code;
            BasePrice = basePrice;
            EstimatedDeliveryTimeHours = estimatedDeliveryTimeHours;
            MaxDimensions = maxDimensions;
        }
    }
}
