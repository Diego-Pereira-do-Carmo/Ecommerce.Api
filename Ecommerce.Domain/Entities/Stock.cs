
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class Stock : BaseEntity
    {
        public Guid ProductVariantId { get; private set; }
        public int Quantity { get; private set; }
        public int ReservedQuantity { get; private set; }
        public int MinQuantity { get; private set; }

        public virtual ProductVariant ProductVariant { get; private set; } = null!;

        protected Stock() { }

        public Stock(Guid productVariantId, int initialQuantity, int minQuantity = 0)
        {
            Guard.AgainstEmptyGuid(productVariantId, nameof(productVariantId));
            Guard.AgainstMinValue(initialQuantity, 0, nameof(initialQuantity));
            Guard.AgainstMinValue(minQuantity, 0, nameof(minQuantity));

            ProductVariantId = productVariantId;
            Quantity = initialQuantity;
            MinQuantity = minQuantity;
            ReservedQuantity = 0;
        }

        public int GetAvailableQuantity() => Quantity - ReservedQuantity;
    }
}
