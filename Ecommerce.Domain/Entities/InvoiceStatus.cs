
using Ecommerce.Domain.Entities.Base;

namespace Ecommerce.Domain.Entities
{
    public class InvoiceStatus : BaseStatusEntity
    {
        protected InvoiceStatus() : base() { }

        public InvoiceStatus(string flag, string name, string description)
        : base(flag, name, description)
        {
        }
    }
}
