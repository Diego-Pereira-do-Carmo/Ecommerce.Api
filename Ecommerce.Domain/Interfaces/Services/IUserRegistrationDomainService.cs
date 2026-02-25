
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.Interfaces.Services
{
    public interface IUserRegistrationDomainService
    {
        User CreateUser(string userName, string firstName, string lastName, EmailAddressValueObject email, PhoneNumberValueObject mobile);
    }
}
