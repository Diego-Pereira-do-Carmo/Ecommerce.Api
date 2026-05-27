using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Security;
using Ecommerce.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Infrastructure.Security
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public JwtTokenResult GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _configuration["JwtSettings:Secret"] ?? throw new InvalidOperationException("JWT Secret não configurado.");

            var key = Encoding.ASCII.GetBytes(secretKey);
            var expirationMinutes = double.Parse(_configuration["JwtSettings:ExpirationInMinutes"] ?? "60");

            var expiresIn = DateTime.UtcNow.AddMinutes(expirationMinutes);

            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.EmailAddress.Value));

            if (user.AccessProfileUsers != null)
            {
                foreach (var profileUser in user.AccessProfileUsers)
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, profileUser.AccessProfileId.ToString()));
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = expiresIn,
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return new JwtTokenResult(tokenString, expiresIn);
        }
    }
}
