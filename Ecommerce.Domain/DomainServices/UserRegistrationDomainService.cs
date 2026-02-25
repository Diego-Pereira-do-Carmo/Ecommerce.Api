
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Security;
using Ecommerce.Domain.Interfaces.Services;
using Ecommerce.Domain.Utils;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.DomainService
{
    public class UserRegistrationDomainService : IUserRegistrationDomainService
    {
        private readonly IPasswordService _passwordService;

        public UserRegistrationDomainService(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        public User CreateUser(string userName, string firstName, string lastName, EmailAddressValueObject email, PhoneNumberValueObject mobile)
        {
            Guard.AgainstNullOrEmpty(userName, nameof(userName));
            Guard.AgainstNullOrEmpty(firstName, nameof(firstName));
            Guard.AgainstNullOrEmpty(lastName, nameof(lastName));

            var password = _passwordService.GenerateRandomPassword();

            Guard.AgainstWeakPassword(password, nameof(password));

            var hash = _passwordService.HashPassword(password);

            return new User(userName, firstName, lastName, email, mobile, hash);
        }
    }
}
