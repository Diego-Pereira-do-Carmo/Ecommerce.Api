
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class ProductReviewImage : BaseEntity
    {
        public Guid ProductReviewId { get; private set; }
        public string FileName { get; private set; } = string.Empty;
        public string StringBase64 { get; private set; } = string.Empty;
        public string MimeType { get; private set; } = string.Empty;
        public int DisplayOrder { get; private set; }

        public ProductReview ProductReview { get; private set; } = null!;

        protected ProductReviewImage() { }

        public ProductReviewImage(Guid productReviewId, string fileName, string mimeType, int displayOrder = 0)
        {
            Guard.AgainstEmptyGuid(productReviewId, nameof(productReviewId));
            Guard.AgainstNullOrEmpty(fileName, nameof(fileName));
            Guard.AgainstNullOrEmpty(mimeType, nameof(mimeType));

            ProductReviewId = productReviewId;
            FileName = fileName;
            MimeType = mimeType;
            DisplayOrder = displayOrder;
        }
    }
}
