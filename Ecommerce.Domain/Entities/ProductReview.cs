
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class ProductReview : BaseEntity
    {
        public Guid CustomerId { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid OrderId { get; private set; }

        public string Title { get; private set; } = string.Empty;
        public string ReviewMessage { get; private set; } = string.Empty;
        public int Rating { get; private set; }
        public int HelpfulVotes { get; private set; }
        public string? ReplyMessage { get; private set; }
        public DateTime? RepliedOn { get; private set; }
        public Guid? ProductReviewStatusId { get; private set; }

        public Customer Customer { get; private set; } = null!;
        public Product Product { get; private set; } = null!;
        public Order? Order { get; private set; } = null!;
        public ProductReviewStatus? ProductReviewStatus { get; private set; }
        public ICollection<ProductReviewImage> Images { get; private set; } = new List<ProductReviewImage>();

        protected ProductReview() { }

        public ProductReview(Guid customerId, Guid productId, Guid orderId, string title, string message, int rating)
        {
            Guard.AgainstEmptyGuid(customerId, nameof(customerId));
            Guard.AgainstEmptyGuid(productId, nameof(productId));
            Guard.AgainstEmptyGuid(orderId, nameof(orderId));
            Guard.AgainstNullOrEmpty(title, nameof(title));
            Guard.AgainstNullOrEmpty(message, nameof(message));

            if (rating < 1 || rating > 5)
                throw new DomainException("A avaliação deve ser entre 1 e 5 estrelas.");

            CustomerId = customerId;
            ProductId = productId;
            OrderId = orderId;
            Title = title;
            ReviewMessage = message;
            Rating = rating;
            HelpfulVotes = 0;
        }

        public void Reply(string message)
        {
            Guard.AgainstNullOrEmpty(message, nameof(message));
            ReplyMessage = message;
            RepliedOn = DateTime.UtcNow;
        }

        public void AddHelpfulVote() => HelpfulVotes++;
    }
}
