
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.Entities
{
    public class ProductVariant : BaseEntity
    {
        public Guid ProductId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Sku { get; private set; } = string.Empty;
        public string? Ean { get; private set; }
        public decimal Price { get; private set; }
        public DimensionsValueObject Dimensions { get; private set; } = null!;

        public Product Product { get; private set; } = null!;
        public Stock Stock { get; private set; } = null!;

        public ICollection<CartItem> CartItems { get; private set; } = new List<CartItem>();
        public ICollection<ProductVariantAttribute> ProductVariantAttributes { get; private set; } = new List<ProductVariantAttribute>();
        public ICollection<ProductImage> Images { get; private set; } = new List<ProductImage>();


        protected ProductVariant() { }

        public ProductVariant(Guid productId, string name, string sku, decimal price, DimensionsValueObject dimensions, string? ean = null)
        {
            Guard.AgainstEmptyGuid(productId, nameof(productId));
            Guard.AgainstNullOrEmpty(name, nameof(name));
            Guard.AgainstNullOrEmpty(sku, nameof(sku));
            Guard.AgainstMinValue(price, 0.01m, nameof(price));

            ProductId = productId;
            Name = name.Trim();
            Sku = sku.Trim().ToUpper();
            Price = price;
            Dimensions = dimensions;
            Ean = ean;
        }

        public void UpdatePrice(decimal newPrice)
        {
            Guard.AgainstMinValue(newPrice, 0.01m, nameof(newPrice));
            Price = newPrice;
        }
    }
}
