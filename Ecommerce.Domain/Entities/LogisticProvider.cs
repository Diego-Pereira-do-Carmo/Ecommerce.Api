
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.Entities
{
    public class LogisticProvider : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public NationalIdValueObject Cnpj { get; private set; } = null!;
        public EmailAddressValueObject? EmailAddress { get; private set; } = null!;
        public PhoneNumberValueObject? Mobilephone { get; private set; }
        public PhoneNumberValueObject? Telephone { get; private set; }

        public string? Website { get; private set; }
        public string? LogoUrl { get; private set; }

        public ICollection<LogisticMethod> LogisticsMethods { get; private set; } = new List<LogisticMethod>();

        protected LogisticProvider() { }

        public LogisticProvider(string name, string code, NationalIdValueObject cnpj)
        {
            Guard.AgainstNullOrEmpty(name, nameof(name));
            Guard.AgainstNullOrEmpty(code, nameof(code));

            Name = name;
            Code = code.ToUpper().Trim();
            Cnpj = cnpj;
        }

        public void UpdateContact(EmailAddressValueObject? email, PhoneNumberValueObject? mobile, PhoneNumberValueObject? telephone)
        {
            EmailAddress = email;
            Mobilephone = mobile;
            Telephone = telephone;
        }
    }
}
