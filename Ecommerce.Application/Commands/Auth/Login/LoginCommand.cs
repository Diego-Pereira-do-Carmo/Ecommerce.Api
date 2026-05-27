using Ecommerce.Domain.Common;
using Ecommerce.Domain.Dtos;
using MediatR;

namespace Ecommerce.Application.Commands.Auth.Login
{
    public record LoginCommand : IRequest<Result<LoginResponseDto>>
    {
        public string EmailAddress { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;

        public LoginCommand(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }
    }
}
