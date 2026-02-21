
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public Guid OrderId { get; private set; }
        public string? ExternalId { get; private set; }
        public Guid InvoiceStatusId { get; private set; }
        public string? Number { get; private set; }
        public string Series { get; private set; } = string.Empty;
        public string? AccessKey { get; private set; }
        public decimal TotalAmount { get; private set; }
        public string XmlUrl { get; private set; } = string.Empty;
        public string PdfUrl { get; private set; } = string.Empty;
        public string? ErrorMessage { get; private set; }
        public DateTime? AuthorizedOn { get; private set; }

        public Order Order { get; private set; } = null!;
        public InvoiceStatus InvoiceStatus { get; private set; } = null!;

        protected Invoice() { }

        public Invoice(Guid orderId, Guid invoiceStatusId, decimal totalAmount)
        {
            Guard.AgainstEmptyGuid(orderId, nameof(orderId));
            Guard.AgainstEmptyGuid(invoiceStatusId, nameof(invoiceStatusId));
            Guard.AgainstMinValue(totalAmount, 0.01m, nameof(totalAmount));

            OrderId = orderId;
            InvoiceStatusId = invoiceStatusId;
            TotalAmount = totalAmount;
        }
    }
}
