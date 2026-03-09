using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces.Services
{
    public interface IUserRegistrationDomainService
    {
        User CreateUser(string firstName, string lastName, string emailAddress, string mobilePhone);
    }
}
