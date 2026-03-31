using Ecommerce.Domain.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace Ecommerce.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public string FriendlyCode { get; private set; } = string.Empty;
        public DateTime CreatedOn { get; private set; }
        public Guid CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public Guid? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public Guid? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; }
        public bool IsActive { get; private set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            FriendlyCode = GenerateFriendlyCode();
            CreatedOn = DateTime.UtcNow;
            IsDeleted = false;
            IsActive = true;
        }

        protected string GenerateFriendlyCode()
        {
            var prefix = ExtractPrefix(GetType().Name);
            var suffix = GenerateDeterministicSuffix(Id.ToString(), 5);
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

            foreach (var caracter in input)
            {
                if (char.IsUpper(caracter) && current.Length > 0)
                {
                    words.Add(current.ToString());
                    current.Clear();
                }
                current.Append(caracter);
            }

            if (current.Length > 0)
                words.Add(current.ToString());

            return words;
        }
    }
}
