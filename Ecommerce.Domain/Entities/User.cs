
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; private set; } = string.Empty;
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string FullName { get; private set; } = string.Empty;
        public EmailAddressValueObject EmailAddress { get; private set; } = null!;
        public PhoneNumberValueObject Mobilephone { get; private set; } = null!;
        public string PasswordHash { get; private set; } = string.Empty;
        public DateTime? LastAccess { get; private set; }
        public int AccessFailedCount { get; private set; } = 0;
        public DateTime? DateAccessTry { get; private set; }
        public DateTime? LockoutEnd { get; private set; }
        public bool IsEmailAddressConfirmed { get; private set; } = false;
        public string SecurityStamp { get; private set; } = Guid.NewGuid().ToString();

        public Customer? Customer { get; private set; }
        public ICollection<AccessProfileUser> AccessProfileUsers { get; private set; } = new List<AccessProfileUser>();


        protected User()
        {
        }

        internal User(string userName, string firstName, string lastName, EmailAddressValueObject email, PhoneNumberValueObject mobile, string passwordHash)
        {
            Guard.AgainstNullOrEmpty(userName, nameof(userName));
            Guard.AgainstNullOrEmpty(firstName, nameof(firstName));
            Guard.AgainstNullOrEmpty(lastName, nameof(lastName));
            Guard.AgainstNullOrEmpty(passwordHash, nameof(passwordHash));

            UserName = userName.Trim().ToLower();
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            FullName = $"{FirstName} {LastName}";
            EmailAddress = email;
            Mobilephone = mobile;
            PasswordHash = passwordHash;
            AccessFailedCount = 0;
            IsEmailAddressConfirmed = false;
        }
    }
}
