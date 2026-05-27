using Ecommerce.Domain.Entities;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.Interfaces.Services
{
    public interface IUserRegistrationDomainService
    {
        User CreateUser(string firstName, string lastName, Guid accessProfileId, EmailAddressValueObject emailAddress, PhoneNumberValueObject mobilePhone);
    }
}
