
using Ecommerce.Domain.Exceptions;

namespace Ecommerce.Domain.Utils
{
    public static class Guard
    {
        public static void AgainstNullOrEmpty(string? value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException($"{fieldName} não pode ser vazio.");
        }

        public static void AgainstMaxLength(string value, int max, string fieldName)
        {
            if (value.Length > max)
                throw new DomainException($"{fieldName} deve ter no máximo {max} caracteres.");
        }

        public static void AgainstEmptyGuid(Guid value, string fieldName)
        {
            if (value == Guid.Empty)
                throw new DomainException($"{fieldName} deve ser um ID válido.");
        }

        public static void AgainstMinValue(decimal value, decimal min, string fieldName)
        {
            if (value < min)
                throw new DomainException($"{fieldName} não pode ser menor que {min}.");
        }

        public static void AgainstMinDate(DateTime date, DateTime minDate, string fieldName)
        {
            if (date < minDate)
                throw new DomainException($"{fieldName} ({date:dd/MM/yyyy}) não pode ser anterior a {minDate:dd/MM/yyyy}");
        }

        public static void AgainstInvalidUrl(string url, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(url) || !Uri.TryCreate(url.Trim(), UriKind.Absolute, out _))
            {
                throw new DomainException($"{fieldName} não é uma URL válida.");
            }
        }
    }
}
