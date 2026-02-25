
namespace Ecommerce.Application.Commands.Users.RegisterUser
{
    public record RegisterUserCommand(string FirstName, string LastName, string Email, string MobilePhone, string Password);
}
