
using Ecommerce.Domain.Entities.Base;

namespace Ecommerce.Domain.Entities
{
    public class EmailStatus : BaseStatusEntity
    {
        protected EmailStatus() : base() { }

        public EmailStatus(string flag, string name, string description)
        : base(flag, name, description)
        {
        }
    }
}
