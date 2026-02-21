
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class ProductAttribute : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public int DisplayOrder { get; private set; }
        public ICollection<ProductAttributeValue> Values { get; private set; } = new List<ProductAttributeValue>();

        protected ProductAttribute() { }

        public ProductAttribute(string name, int displayOrder = 0)
        {
            Update(name, displayOrder);
        }

        public void Update(string name, int displayOrder)
        {
            Guard.AgainstNullOrEmpty(name, nameof(name));

            Name = name.Trim();
            DisplayOrder = displayOrder;
        }
    }
}
