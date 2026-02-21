
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class ProductVariantAttribute : BaseEntity
    {
        public Guid ProductVariantId { get; private set; }
        public Guid ProductAttributeValueId { get; private set; }

        public ProductVariant ProductVariant { get; private set; } = null!;
        public ProductAttributeValue ProductAttributeValue { get; private set; } = null!;

        protected ProductVariantAttribute() { }

        public ProductVariantAttribute(Guid productVariantId, Guid productAttributeValueId)
        {
            Guard.AgainstEmptyGuid(productVariantId, nameof(productVariantId));
            Guard.AgainstEmptyGuid(productAttributeValueId, nameof(productAttributeValueId));

            ProductVariantId = productVariantId;
            ProductAttributeValueId = productAttributeValueId;
        }
    }
}
