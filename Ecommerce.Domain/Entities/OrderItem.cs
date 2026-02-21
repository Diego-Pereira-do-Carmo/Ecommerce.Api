
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; private set; }
        public Guid ProductVariantId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPriceAmount { get; private set; }
        public decimal TotalAmount { get; private set; }

        public Order Order { get; private set; } = null!;
        public virtual ProductVariant ProductVariant { get; private set; } = null!;

        protected OrderItem() { }

        public OrderItem(Guid orderId, Guid productVariantId, int quantity, decimal unitPriceAmount)
        {
            Guard.AgainstEmptyGuid(orderId, nameof(orderId));
            Guard.AgainstEmptyGuid(productVariantId, nameof(productVariantId));
            Guard.AgainstMinValue(quantity, 1, nameof(quantity));

            OrderId = orderId;
            ProductVariantId = productVariantId;
            Quantity = quantity;
            UnitPriceAmount = unitPriceAmount;

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            TotalAmount = Quantity * UnitPriceAmount;
        }

        public void UpdateQuantity(int newQuantity)
        {
            Guard.AgainstMinValue(newQuantity, 1, nameof(newQuantity));

            Quantity = newQuantity;
            CalculateTotal();
        }
    }
}
