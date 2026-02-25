
using Ecommerce.Domain.Interfaces.Security;
using System.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace Ecommerce.Infrastructure.Security
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password) => BC.HashPassword(password);

        public bool VerifyPassword(string password, string hash) => BC.Verify(password, hash);

        public string GenerateRandomPassword(int length = 8)
        {
            const string upper = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            const string lower = "abcdefghijkmnpqrstuvwxyz";
            const string digits = "0123456789";
            const string specials = "!@#$%^&*?_-";
            const string allChars = upper + lower + digits + specials;

            var passwordChars = new List<char>
            {
                upper[RandomNumberGenerator.GetInt32(upper.Length)],
                lower[RandomNumberGenerator.GetInt32(lower.Length)],
                digits[RandomNumberGenerator.GetInt32(digits.Length)],
                specials[RandomNumberGenerator.GetInt32(specials.Length)]
            };

            while (passwordChars.Count < length)
            {
                passwordChars.Add(allChars[RandomNumberGenerator.GetInt32(allChars.Length)]);
            }

            return new string(passwordChars.OrderBy(_ => RandomNumberGenerator.GetInt32(100)).ToArray());
        }
    }
}
