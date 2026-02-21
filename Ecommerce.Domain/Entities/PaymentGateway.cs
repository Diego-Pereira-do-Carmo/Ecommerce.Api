
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.Entities
{
    public class PaymentGateway : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Flag { get; private set; } = string.Empty;
        public EmailAddressValueObject? EmailAddress { get; private set; } = null!;
        public PhoneNumberValueObject? Mobilephone { get; private set; }
        public PhoneNumberValueObject? Telephone { get; private set; }
        public int Priority { get; private set; }
        public string? EnvironmentKey { get; private set; }
        public string? ApiBaseUrl { get; private set; }

        public ICollection<PaymentMethod> PaymentMethods { get; private set; } = new List<PaymentMethod>();

        protected PaymentGateway() { }

        public PaymentGateway(string name, string flag, string environmentKey, int priority = 0)
        {
            Update(name, flag, priority, environmentKey);
        }

        public void Update(
            string name,
            string flag,
            int priority,
            string? environmentKey = null,
            string? apiBaseUrl = null,
            EmailAddressValueObject? email = null,
            PhoneNumberValueObject? mobile = null,
            PhoneNumberValueObject? telephone = null)
        {
            Guard.AgainstNullOrEmpty(name, nameof(name));
            Guard.AgainstNullOrEmpty(flag, nameof(flag));
            Guard.AgainstNullOrEmpty(environmentKey, nameof(environmentKey));

            Name = name.Trim();
            Flag = flag.Trim().ToUpper();
            EnvironmentKey = environmentKey;
            Priority = priority;
            ApiBaseUrl = apiBaseUrl;
            EmailAddress = email;
            Mobilephone = mobile;
            Telephone = telephone;
        }
    }
}
