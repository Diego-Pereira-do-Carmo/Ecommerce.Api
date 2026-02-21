
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Utils;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.Entities
{
    public class Address : BaseEntity
    {
        public Guid CustomerId { get; private set; }
        public AddressValueObject FullAddress { get; private set; } = null!;
        public AddressTypeEnum AddressType { get; private set; }

        public Customer? Customer { get; private set; } 


        protected Address() { }

        public Address(Guid customerId, AddressTypeEnum addressType, AddressValueObject fullAddress)
        {
            Guard.AgainstEmptyGuid(customerId, nameof(customerId));

            CustomerId = customerId;
            AddressType = addressType;
            FullAddress = fullAddress;
        }
    }
}
