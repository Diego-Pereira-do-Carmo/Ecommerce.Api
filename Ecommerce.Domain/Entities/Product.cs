
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string UrlKey { get; private set; } = string.Empty;
        public string ShortDescription { get; private set; } = string.Empty;
        public string? FullDescription { get; private set; }
        public Guid BrandId { get; private set; }

        public Brand Brand { get; private set; } = null!;
        public ICollection<ProductVariant> Variants { get; private set; } = new List<ProductVariant>();
        public ICollection<ProductImage> Images { get; private set; } = new List<ProductImage>();
        public ICollection<ProductCategory> ProductCategories { get; private set; } = new List<ProductCategory>();
        public ICollection<ProductReview> Reviews { get; private set; } = new List<ProductReview>();

        protected Product() { }

        public Product(string name, string urlKey, string shortDescription, Guid brandId, string? fullDescription = null)
        {
            Update(name, urlKey, shortDescription, brandId, fullDescription);
        }

        public void Update(string name, string urlKey, string shortDescription, Guid brandId, string? fullDescription = null)
        {
            Guard.AgainstNullOrEmpty(name, nameof(name));
            Guard.AgainstNullOrEmpty(urlKey, nameof(urlKey));
            Guard.AgainstNullOrEmpty(shortDescription, nameof(shortDescription));
            Guard.AgainstEmptyGuid(brandId, nameof(brandId));

            Name = name.Trim();
            UrlKey = urlKey.Trim().ToLower().Replace(" ", "-");
            ShortDescription = shortDescription.Trim();
            FullDescription = fullDescription?.Trim();
            BrandId = brandId;
        }
    }
}
