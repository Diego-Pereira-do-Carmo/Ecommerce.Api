using Ecommerce.Infrastructure.Exceptions;
using Ecommerce.Infrastructure.Persistence.Seeders.SeederInterface;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Ecommerce.Infrastructure.Persistence.Seeders.Base
{
    internal abstract class BaseSeeder<T> : ISeeder<T> where T : class
    {
        public abstract void Seed(EntityTypeBuilder<T> builder);

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

        protected static string GenerateFriendlyCode(Guid id, string className)
        {
            var prefix = ExtractPrefix(className);
            var suffix = GenerateDeterministicSuffix(id.ToString(), 5);
            return $"{prefix}-{suffix}";
        }

        private static string GenerateDeterministicSuffix(string input, int length)
        {
            using var md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            var number = BitConverter.ToUInt32(hash, 0) % (uint)Math.Pow(10, length);
            return number.ToString($"D{length}");
        }

        private static string ExtractPrefix(string className)
        {
            if (className.Length <= 4)
                return className.ToUpper();

            var words = SplitPascalCase(className);
            var prefix = new StringBuilder();
            var charsPerWord = Math.Max(1, 4 / words.Count());

            foreach (var word in words)
            {
                var take = Math.Min(charsPerWord, word.Length);
                prefix.Append(word[..take]);
                if (prefix.Length >= 4) break;
            }

            if (prefix.Length < 4)
            {
                var firstWord = words.First();
                prefix.Append(firstWord[prefix.Length..Math.Min(4, firstWord.Length)]);
            }

            return prefix.ToString()[..4].ToUpper();
        }

        private static IEnumerable<string> SplitPascalCase(string input)
        {
            var words = new List<string>();
            var current = new StringBuilder();

            foreach (var c in input)
            {
                if (char.IsUpper(c) && current.Length > 0)
                {
                    words.Add(current.ToString());
                    current.Clear();
                }
                current.Append(c);
            }

            if (current.Length > 0)
                words.Add(current.ToString());

            return words;
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
