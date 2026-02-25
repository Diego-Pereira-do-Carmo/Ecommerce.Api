using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.Utils;
using System.Text.RegularExpressions;

namespace Ecommerce.Domain.ValueObjects
{
    public record EmailAddressValueObject
    {
        public string Value { get; init; } = string.Empty;

        public EmailAddressValueObject(string value)
        {
            Guard.AgainstNullOrEmpty(value, nameof(value));

            var cleanAddress = value.Trim().ToLower();
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if (!emailRegex.IsMatch(cleanAddress))
                throw new DomainException($"O e-mail '{value}' possui um formato inválido.");

            Value = cleanAddress;
        }

        public string GetUserName()
        {
            Guard.AgainstNullOrEmpty(Value, nameof(Value));

            return Value.Split('@')[0];
        }

        public override string ToString() => Value;
    }
}
