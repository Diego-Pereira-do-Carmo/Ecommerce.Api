
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class StockTransaction : BaseEntity
    {
        public Guid ProductVariantId { get; private set; }
        public Guid? OrderId { get; private set; }
        public int Quantity { get; private set; }
        public int BalanceAfter { get; private set; }
        public StockTransactionTypeEnum StockTransactionType { get; private set; }
        public Guid StockTransactionReasonId { get; private set; }
        public Guid UserId { get; private set; }

        public ProductVariant ProductVariant { get; private set; } = null!;
        public Order? Order { get; private set; }
        public StockTransactionReason StockTransactionReason { get; private set; } = null!;
        public User User { get; private set; } = null!;


        protected StockTransaction() { }

        public StockTransaction(Guid productVariantId, int quantity, int balanceAfter, StockTransactionTypeEnum type, Guid reasonId, Guid userId, Guid? orderId = null)
        {
            Guard.AgainstEmptyGuid(productVariantId, nameof(productVariantId));
            Guard.AgainstMinValue(quantity, 1, nameof(quantity));
            Guard.AgainstMinValue(balanceAfter, 1, nameof(balanceAfter));
            Guard.AgainstEmptyGuid(reasonId, nameof(reasonId));
            Guard.AgainstEmptyGuid(userId, nameof(userId));

            ProductVariantId = productVariantId;
            Quantity = quantity;
            BalanceAfter = balanceAfter;
            StockTransactionType = type;
            StockTransactionReasonId = reasonId;
            UserId = userId;
            OrderId = orderId;
        }
    }
}
