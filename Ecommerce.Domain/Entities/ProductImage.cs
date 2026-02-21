
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public Guid ProductId { get; private set; }
        public Guid? ProductVariantId { get; private set; }
        public string FileName { get; private set; } = string.Empty;
        public string StringBase64 { get; private set; } = string.Empty;
        public string MimeType { get; private set; } = string.Empty;
        public bool IsMain { get; private set; }
        public int DisplayOrder { get; private set; }

        public Product Product { get; private set; } = null!;
        public ProductVariant? ProductVariant { get; private set; }

        protected ProductImage() { }

        public ProductImage(Guid productId, string fileName, string mimeType, bool isMain = false, int displayOrder = 0, Guid? productVariantId = null)
        {
            Guard.AgainstEmptyGuid(productId, nameof(productId));
            Guard.AgainstNullOrEmpty(fileName, nameof(fileName));
            Guard.AgainstNullOrEmpty(mimeType, nameof(mimeType));

            ProductId = productId;
            ProductVariantId = productVariantId;
            FileName = fileName;
            MimeType = mimeType;
            IsMain = isMain;
            DisplayOrder = displayOrder;
        }

        public void MarkAsMain() => IsMain = true;
        public void SetDisplayOrder(int order) => DisplayOrder = order;
    }
}
