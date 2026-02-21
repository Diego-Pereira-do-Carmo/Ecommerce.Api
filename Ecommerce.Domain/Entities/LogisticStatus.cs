
using Ecommerce.Domain.Entities.Base;

namespace Ecommerce.Domain.Entities
{
    public class LogisticStatus : BaseStatusEntity
    {
        protected LogisticStatus() : base() { }

        public LogisticStatus(string flag, string name, string description)
        : base(flag, name, description)
        {
        }
    }
}
