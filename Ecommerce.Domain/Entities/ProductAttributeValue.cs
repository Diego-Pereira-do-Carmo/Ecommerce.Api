
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class ProductAttributeValue : BaseEntity
    {
        public Guid ProductAttributeId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int DisplayOrder { get; private set; }

        public ProductAttribute ProductAttribute { get; private set; } = null!;

        protected ProductAttributeValue() { }

        public ProductAttributeValue(Guid productAttributeId, string name, int displayOrder = 0)
        {
            Guard.AgainstEmptyGuid(productAttributeId, nameof(productAttributeId));
            Update(name, displayOrder);
            ProductAttributeId = productAttributeId;
        }

        public void Update(string name, int displayOrder)
        {
            Guard.AgainstNullOrEmpty(name, nameof(name));
            Name = name.Trim();
            DisplayOrder = displayOrder;
        }
    }
}
