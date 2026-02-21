
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string UrlKey { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public int DisplayOrder { get; private set; }

        public Guid? ParentCategoryId { get; private set; }
        public Category? ParentCategory { get; private set; }
        public ICollection<Category> SubCategories { get; private set; } = new List<Category>();
        public ICollection<ProductCategory> ProductCategories { get; private set; } = new List<ProductCategory>();

        protected Category() { }

        public Category(string name, string urlKey, Guid userId, string? description = null, int displayOrder = 0, Guid? parentCategoryId = null)
        {
            Update(name, urlKey, userId, description, displayOrder, parentCategoryId);
        }

        public void Update(string name, string urlKey, Guid userId, string? description = null, int displayOrder = 0, Guid? parentCategoryId = null)
        {
            Guard.AgainstNullOrEmpty(name, nameof(name));
            Guard.AgainstNullOrEmpty(urlKey, nameof(urlKey));
            Guard.AgainstMinValue(displayOrder, 1, nameof(displayOrder));

            if (parentCategoryId.HasValue && parentCategoryId.Value == Id)
                throw new DomainException("Uma categoria não pode ser pai de si mesma.");

            Name = name.Trim();
            UrlKey = urlKey.Trim().ToLower().Replace(" ", "-");
            Description = description?.Trim();
            DisplayOrder = displayOrder;
            ParentCategoryId = parentCategoryId;

            // Auditoria
            //SetUpdateMetadata(userId);
        }
    }
}
