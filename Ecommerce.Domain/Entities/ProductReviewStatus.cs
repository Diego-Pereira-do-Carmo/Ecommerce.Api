
using Ecommerce.Domain.Entities.Base;

namespace Ecommerce.Domain.Entities
{
    public class ProductReviewStatus : BaseStatusEntity
    {
        protected ProductReviewStatus() : base() { }

        public ProductReviewStatus(string flag, string name, string description)
        : base(flag, name, description)
        {
        }
    }
}
