
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class StockTransactionReason : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        protected StockTransactionReason() { }

        public StockTransactionReason(string name, string description)
        {
            Update(name, description);
        }

        public void Update(string name, string description)
        {
            Guard.AgainstNullOrEmpty(name, nameof(name));
            Guard.AgainstNullOrEmpty(description, nameof(description));

            Name = name.Trim();
            Description = description.Trim();
        }
    }
}
