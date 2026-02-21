
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public decimal PaidAmount { get; private set; }
        public int Installments { get; private set; } = 1;
        public DateTime? PaidOn { get; private set; }
        public DateTime? RefundedOn { get; private set; }
        public decimal? RefundedAmount { get; private set; }
        public string? GatewaysStatusMessage { get; private set; }
        public string? PaymentLink { get; private set; }
        public string? ReceiptLink { get; private set; }

        // Identificadores para conciliação com Gateways (Stripe, PagSeguro, etc)
        public string? ExternalTransactionId { get; private set; }
        public string? AuthorizationCode { get; private set; }

        public Guid OrderId { get; private set; }
        public Guid PaymentGatewayId { get; private set; }
        public Guid PaymentMethodId { get; private set; }
        public Guid PaymentStatusId { get; private set; }

        public Order Order { get; private set; } = null!;
        public PaymentGateway PaymentGateway { get; private set; } = null!;
        public PaymentMethod PaymentMethod { get; private set; } = null!;
        public PaymentStatus PaymentStatus { get; private set; } = null!;

        protected Payment() { }

        public Payment(Guid orderId, Guid gatewayId, Guid methodId, Guid statusId, decimal paidAmount, int installments = 1)
        {
            Guard.AgainstEmptyGuid(orderId, nameof(orderId));
            Guard.AgainstEmptyGuid(gatewayId, nameof(gatewayId));
            Guard.AgainstEmptyGuid(methodId, nameof(methodId));
            Guard.AgainstEmptyGuid(statusId, nameof(statusId));
            Guard.AgainstMinValue(paidAmount, 0.01m, nameof(paidAmount));
            Guard.AgainstMinValue(installments, 1, nameof(installments));

            OrderId = orderId;
            PaymentGatewayId = gatewayId;
            PaymentMethodId = methodId;
            PaymentStatusId = statusId;
            PaidAmount = paidAmount;
            Installments = installments;
        }
    }
}
