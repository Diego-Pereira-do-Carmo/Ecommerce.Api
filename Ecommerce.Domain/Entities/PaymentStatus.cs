
using Ecommerce.Domain.Entities.Base;

namespace Ecommerce.Domain.Entities
{
    public class PaymentStatus : BaseStatusEntity
    {
        protected PaymentStatus() : base() { }

        public PaymentStatus(string flag, string name, string description)
        : base(flag, name, description)
        {
        }
    }
}
