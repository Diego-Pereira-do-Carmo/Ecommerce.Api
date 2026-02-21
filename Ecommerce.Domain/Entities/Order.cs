
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        public decimal ItemsTotalAmount { get; private set; }
        public decimal DeliveryAmount { get; private set; }
        public decimal DiscountAmount { get; private set; }
        public decimal TotalPayableAmount { get; private set; }
        public string? Observation { get; private set; }
        public DateTime? ConfirmedOn { get; private set; }
        public Guid OrderStatusId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid? CouponId { get; private set; }
        public AddressValueObject FullAddress { get; private set; } = null!;

        public OrderStatus OrderStatus { get; private set; } = null!;
        public Invoice? Invoice { get; private set; }
        public Coupon? Coupon { get; private set; } 
        public Customer Customer { get; private set; } = null!;

        public ICollection<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();
        public ICollection<Payment> Payments { get; private set; } = new List<Payment>();
        public ICollection<Logistic> Logistics { get; private set; } = new List<Logistic>();

        protected Order() { }

        public Order(Guid customerId, Guid orderStatusId, decimal deliveryAmount, decimal discountAmount, AddressValueObject fullAddress)
        {
            Guard.AgainstEmptyGuid(customerId, nameof(customerId));

            CustomerId = customerId;
            DeliveryAmount = deliveryAmount;
            OrderStatusId = orderStatusId;
            FullAddress = fullAddress;

            //CalculateItemsAmountTotal(); aplicar o metodo para fazer a soma posteriormente
            //CalculateTotalPayableAmount()
        }
    }
}
