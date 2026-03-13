using Ecommerce.Domain.Common;
using MediatR;

namespace Ecommerce.Application.Commands.Users.RegisterUser
{
    public record RegisterUserCommand : IRequest<Result<Guid>>
    {
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public string EmailAddress { get; init; } = string.Empty;
        public string MobilePhone { get; init; } = string.Empty;


        public RegisterUserCommand(string firstName, string lastName, string emailAddress, string mobilePhone)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            MobilePhone = mobilePhone;
        }
    }
}
