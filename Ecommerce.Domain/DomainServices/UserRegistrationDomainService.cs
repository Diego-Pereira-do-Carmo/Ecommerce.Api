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

        public User CreateUser(string firstName, string lastName, EmailAddressValueObject emailAddress, PhoneNumberValueObject mobilePhone)
        {
            Guard.AgainstNullOrEmpty(firstName, nameof(firstName));
            Guard.AgainstNullOrEmpty(lastName, nameof(lastName));

            var password = _passwordService.GenerateRandomPassword();
            Guard.AgainstWeakPassword(password, nameof(password));
            var hash = _passwordService.HashPassword(password);

            return new User(emailAddress.GetUserName(), firstName, lastName, emailAddress, mobilePhone, hash);
        }
    }
}
