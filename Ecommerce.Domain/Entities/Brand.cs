
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;
using Ecommerce.Domain.ValueObjects;
using System.Reflection;

namespace Ecommerce.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string UrlKey { get; private set; } = string.Empty;
        public string? LogoUrl { get; private set; }
        public NationalIdValueObject Cnpj { get; private set; } = null!;
        public EmailAddressValueObject? EmailAddress { get; private set; } = null!;
        public PhoneNumberValueObject? Mobilephone { get; private set; }
        public PhoneNumberValueObject? Telephone { get; private set; }

        public ICollection<Product> Products { get; private set; } = new List<Product>();

        protected Brand() { }

        public Brand(
            string name,
            string urlKey,
            NationalIdValueObject cnpj,
            EmailAddressValueObject? emailAddress = null,
            PhoneNumberValueObject? mobileNumber = null,
            PhoneNumberValueObject? telephoneNumber = null,
            string? logoUrl = null)
        {
            Update(name, urlKey, cnpj, emailAddress, mobileNumber, telephoneNumber,  logoUrl);
        }


        public void Update(
            string name,
            string urlKey,
            NationalIdValueObject cnpj,
            EmailAddressValueObject? emailAddress = null,
            PhoneNumberValueObject? mobileNumber = null,
            PhoneNumberValueObject? telephoneNumber = null,
            string? logoUrl = null)
        {
            Guard.AgainstNullOrEmpty(name, nameof(name));
            Guard.AgainstNullOrEmpty(urlKey, nameof(urlKey));

            Name = name.Trim();
            UrlKey = urlKey.Trim().ToLower().Replace(" ", "-");
            Cnpj = cnpj;
            EmailAddress = emailAddress;
            Mobilephone = mobileNumber;
            Telephone = telephoneNumber;
            LogoUrl = logoUrl;
        }
    }
}
