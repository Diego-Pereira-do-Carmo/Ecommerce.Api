using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class PaymentMethod : BaseEntity
    {
        public Guid PaymentGatewayId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public string GatewayFlag { get; private set; } = null!;
        public decimal TransactionFeePercentage { get; private set; }
        public string? IconUrl { get; private set; }

        public PaymentGateway PaymentGateway { get; private set; } = null!;

        protected PaymentMethod() { }

        public PaymentMethod(Guid paymentGatewayId, string name, string gatewayFlag, decimal feePercentage, string? description = null, string? iconUrl = null)
        {
            Guard.AgainstEmptyGuid(paymentGatewayId, nameof(paymentGatewayId));
            Guard.AgainstNullOrEmpty(name, nameof(name));
            Guard.AgainstNullOrEmpty(gatewayFlag, nameof(gatewayFlag));

            if (feePercentage < 0 || feePercentage > 100)
                throw new DomainException("A taxa de transação deve estar entre 0 e 100.");

            PaymentGatewayId = paymentGatewayId;
            Name = name.Trim();
            GatewayFlag = gatewayFlag.Trim().ToUpper();
            TransactionFeePercentage = feePercentage;
            Description = description;
            IconUrl = iconUrl;
        }
    }
}
