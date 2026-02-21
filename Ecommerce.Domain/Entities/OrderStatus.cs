
using Ecommerce.Domain.Entities.Base;

namespace Ecommerce.Domain.Entities
{
    public class OrderStatus : BaseStatusEntity
    {
        protected OrderStatus() : base() { }

        public OrderStatus(string flag, string name, string description)
        : base(flag, name, description)
        {
        }
    }
}
