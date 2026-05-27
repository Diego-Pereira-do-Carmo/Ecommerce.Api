using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces.Security
{
    public interface ITokenService
    {
        JwtTokenResult GenerateToken(User user);
    }
}
