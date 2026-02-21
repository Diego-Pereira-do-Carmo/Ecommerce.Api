using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public string FriendlyCode { get; private set; } = string.Empty;
        public DateTime CreatedOn { get; private set; }
        public Guid CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public Guid? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public Guid? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; }
        public bool IsActive { get; private set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            IsDeleted = false;
            IsActive = true;
        }

        protected void SetFriendlyCode(string prefix)
        {
            Guard.AgainstNullOrEmpty(prefix, nameof(prefix));

            string datePart = DateTime.UtcNow.ToString("yyMM");

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            string randomPart = new string(Enumerable.Repeat(chars, 3)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            FriendlyCode = $"{prefix.ToUpper()}-{datePart}-{randomPart}";
        }
    }
}
