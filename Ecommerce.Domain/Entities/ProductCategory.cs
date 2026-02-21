
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class ProductCategory
    {
        public Guid ProductId { get; private set; }
        public Guid CategoryId { get; private set; }
        public bool IsMain { get; private set; } = false;

        public Product Product { get; private set; } = null!;
        public Category Category { get; private set; } = null!;

        protected ProductCategory() { }

        public ProductCategory(Guid productId, Guid categoryId, bool isMain = false)
        {
            Guard.AgainstEmptyGuid(productId, nameof(productId));
            Guard.AgainstEmptyGuid(categoryId, nameof(categoryId));

            ProductId = productId;
            CategoryId = categoryId;
            IsMain = isMain;
        }

        public void MarkAsMain() => IsMain = true;
        public void UnmarkAsMain() => IsMain = false;
    }
}
