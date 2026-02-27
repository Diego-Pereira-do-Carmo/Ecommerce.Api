
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.Utils;
using System.Text.RegularExpressions;

namespace Ecommerce.Domain.ValueObjects
{
    public record PhoneNumberValueObject
    {
        private static readonly Regex _phoneNumberRegex = new Regex(@"[^\d]", RegexOptions.Compiled);
        public string Value { get; init; } = string.Empty;

        public PhoneNumberValueObject(string value)
        {
            Guard.AgainstNullOrEmpty(value, nameof(value));

            var cleanNumber = _phoneNumberRegex.Replace(value, "");

            if (cleanNumber.Length < 10 || cleanNumber.Length > 13)
                throw new DomainException($"O telefone '{value}' possui um formato inválido. Deve conter 10 ou 13 dígitos.");

            Value = cleanNumber;
        }

        public override string ToString() => Value;
    }
}
