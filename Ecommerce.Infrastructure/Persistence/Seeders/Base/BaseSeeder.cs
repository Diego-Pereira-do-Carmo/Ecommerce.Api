
using Ecommerce.Infrastructure.Exceptions;
using Ecommerce.Infrastructure.Persistence.Seeders.SeederInterface;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Ecommerce.Infrastructure.Persistence.Seeders.Base
{
    internal abstract class BaseSeeder<T> : ISeeder<T> where T : class
    {
        public abstract IEnumerable<T> GetSeedData();

        protected Guid GenerateDeterministicGuid(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new SeedingException(nameof(input), "Não é possível gerar um GUID determinístico a partir de nulo ou vazio.");

            using var md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return new Guid(hash);
        }

        protected string GenerateDeterministicEntityCode(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new SeedingException(nameof(input), "...");

            using var md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return "EC-" + BitConverter.ToString(hash, 0, 2).Replace("-", "");
        }

        protected string GenerateFriendlyCode(string className, string statusName)
        {
            if (string.IsNullOrWhiteSpace(statusName))
                throw new SeedingException(className, "Não foi possível gerar o Friendlycode determinístico a partir de nulo ou vazio.");

            string suffix = GenerateDeterministicSuffixFriendlycode(statusName, 5);

            return $"-{suffix}";
        }

        private string GenerateDeterministicSuffixFriendlycode(string input, int length)
        {
            using var md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            var numberString = string.Join("", hash.Select(b => (b % 10).ToString()));
            return numberString.Substring(0, length);
        }

        protected string GenerateFlag(string statusName)
        {
            if (string.IsNullOrWhiteSpace(statusName))
                throw new SeedingException(nameof(statusName), $"Não foi possível gerar o Status determinístico a partir de nulo ou vazio.");

            string cleanName = RemoveAccents(statusName).ToUpper();
            var words = cleanName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var sb = new StringBuilder("#");

            int lettersPerWord = words.Length switch
            {
                1 => 9,
                2 => 4,
                3 => 3, 
                _ => 2 
            };

            foreach (var word in words)
            {      
                string part = SafeSubstring(word, lettersPerWord);

                if (sb.Length + part.Length <= 10)
                {
                    sb.Append(part);
                }
                else
                {
                    int remainingSpace = 10 - sb.Length;
                    if (remainingSpace > 0)
                    {
                        sb.Append(SafeSubstring(part, remainingSpace));
                    }
                    break;
                }
            }

            return sb.ToString();
        }

        private string RemoveAccents(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        private string SafeSubstring(string text, int length)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            return text.Length >= length ? text.Substring(0, length) : text;
        }
    }
}
