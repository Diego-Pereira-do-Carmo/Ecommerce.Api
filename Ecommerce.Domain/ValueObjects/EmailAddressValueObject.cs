
using Ecommerce.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Ecommerce.Domain.ValueObjects
{
    public record EmailAddressValueObject
    {
        public string Value { get; init; } = string.Empty;

        public EmailAddressValueObject(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("O endereço de e-mail não pode estar vazio.");

            var cleanAddress = value.Trim().ToLower();
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if (!emailRegex.IsMatch(cleanAddress))
                throw new DomainException($"O e-mail '{value}' possui um formato inválido.");

            Value = cleanAddress;
        }

        public override string ToString() => Value;
    }
}
