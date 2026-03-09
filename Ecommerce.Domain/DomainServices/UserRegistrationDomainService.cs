using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Security;
using Ecommerce.Domain.Interfaces.Services;
using Ecommerce.Domain.Utils;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.DomainServices
{
    public class UserRegistrationDomainService : IUserRegistrationDomainService
    {
        private readonly IPasswordService _passwordService;

        public UserRegistrationDomainService(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        public User CreateUser(string firstName, string lastName, string emailAddress, string mobilePhone)
        {
            Guard.AgainstNullOrEmpty(firstName, nameof(firstName));
            Guard.AgainstNullOrEmpty(lastName, nameof(lastName));

            var password = _passwordService.GenerateRandomPassword();
            Guard.AgainstWeakPassword(password, nameof(password));
            var hash = _passwordService.HashPassword(password);

            var emailVO = new EmailAddressValueObject(emailAddress);
            var mobilePhoneVO = new PhoneNumberValueObject(mobilePhone);

            return new User(emailVO.GetUserName(), firstName, lastName, emailVO, mobilePhoneVO, hash);
        }
    }
}
