
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.ValueObjects
{
    public record AddressValueObject
    {
        private static readonly HashSet<string> ValidUfs = new()
        {
            "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS",
            "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC",
            "SP", "SE", "TO"
        };

        public string Street { get; init; } = string.Empty;
        public string Number { get; init; } = string.Empty;
        public string District { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;
        public string State { get; init; } = string.Empty;
        public string PostalCode { get; init; } = string.Empty;
        public string Country { get; init; } = "Brasil";
        public string? Complement { get; init; }

        public AddressValueObject(
            string street,
            string number,
            string district,
            string city,
            string state,
            string postalCode,
            string? complement = null)
        {
            Guard.AgainstNullOrEmpty(street, nameof(street));
            Guard.AgainstNullOrEmpty(number, nameof(number));
            Guard.AgainstNullOrEmpty(district, nameof(district));
            Guard.AgainstNullOrEmpty(city, nameof(city));

            Street = street.Trim();
            Number = number.Trim();
            District = district.Trim();
            City = city.Trim();
            State = ValidateState(state);
            PostalCode = ValidatePostalCode(postalCode);
            Complement = complement?.Trim();
            Country = "Brasil";
        }

        public override string ToString() =>
            $"{Street}, {Number}{(string.IsNullOrEmpty(Complement) ? "" : " - " + Complement)}, {District}, {City} - {State} - {Country}, {PostalCode}";

        private string ValidateState(string state)
        {
            Guard.AgainstNullOrEmpty(state, nameof(state));

            var formattedValue = state.Trim().ToUpper();

            if (!ValidUfs.Contains(formattedValue))
                throw new ValueObjectException($"A sigla '{state}' não é um estado brasileiro válido.");

            return formattedValue;
        }

        private string ValidatePostalCode(string postalCode)
        {
            Guard.AgainstNullOrEmpty(postalCode, nameof(postalCode));

            var cleanValue = postalCode.Replace("-", "").Trim();

            if (cleanValue.Length != 8 || !long.TryParse(cleanValue, out _))
                throw new ValueObjectException("CEP inválido. Deve conter exatamente 8 dígitos numéricos.");

            return cleanValue;
        }
    }
}
