using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class CartItem
    {
        public Guid ProductVariantId { get; private set; }
        public Guid CustomerId { get; private set; }
        public int Quantity { get; private set; }
        public DateTime AddedAt { get; private set; } = DateTime.UtcNow;

        public ProductVariant? ProductVariant { get; private set; }
        public Customer? Customer { get; private set; }


        protected CartItem() { }


        public CartItem(Guid customerId, Guid productVariantId, int quantity)
        {
            Guard.AgainstEmptyGuid(customerId, nameof(customerId));
            Guard.AgainstEmptyGuid(productVariantId, nameof(productVariantId));
            Guard.AgainstMinValue(quantity, 1, nameof(quantity));

            CustomerId = customerId;
            ProductVariantId = productVariantId;
            Quantity = quantity;
            AddedAt = DateTime.UtcNow;
        }

        public void UpdateQuantity(int newQuantity)
        {
            Guard.AgainstMinValue(newQuantity, 1, "Quantidade");
            Quantity = newQuantity;
        }
    }
}
