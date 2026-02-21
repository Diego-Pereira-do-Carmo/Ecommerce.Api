
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities.Base
{
    public abstract class BaseStatusEntity : BaseEntity
    {
        public string Flag { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        protected BaseStatusEntity() { }

        protected BaseStatusEntity(string flag, string name, string description)
        {
            UpdateStatus(flag, name, description);
        }

        public void UpdateStatus(string flag, string name, string description)
        {
            Guard.AgainstNullOrEmpty(flag, nameof(flag));
            Guard.AgainstNullOrEmpty(name, nameof(name));
            Guard.AgainstNullOrEmpty(description, nameof(description));

            Flag = flag.Trim().ToUpper().Replace(" ", "_");
            Name = name.Trim();
            Description = description.Trim();
        }
    }
}
