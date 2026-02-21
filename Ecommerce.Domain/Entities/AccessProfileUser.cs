
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class AccessProfileUser : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid AccessProfileId { get; private set; }

        public User? User { get; private set; }
        public AccessProfile? AccessProfile { get; private set; }

        protected AccessProfileUser() { }

        public AccessProfileUser(Guid userId, Guid accessProfileId)
        {
            Guard.AgainstEmptyGuid(userId, nameof(userId));
            Guard.AgainstEmptyGuid(accessProfileId, nameof(accessProfileId));

            UserId = userId;
            AccessProfileId = accessProfileId;
        }
    }
}
