
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Exceptions;

namespace Ecommerce.Domain.ValueObjects
{
    public record NationalIdValueObject
    {
        public string Number { get; init; }
        public CustomerTypeEnum Type { get; init; }

        public NationalIdValueObject(string number)
        {
            var cleanedNumber = string.Concat(number.Where(char.IsDigit));

            if (cleanedNumber.Length == 11)
            {
                if (!ValidateCPF(cleanedNumber)) 
                    throw new DomainException("CPF Inválido.");

                Type = CustomerTypeEnum.Physical;
            }
            else if (cleanedNumber.Length == 14)
            {
                if (!ValidateCNPJ(cleanedNumber))
                    throw new DomainException("CNPJ Inválido.");

                Type = CustomerTypeEnum.Legal;
            }
            else
            {
                throw new DomainException("Documento deve ter 11 (CPF) ou 14 (CNPJ) dígitos.");
            }

            Number = cleanedNumber;
        }

        private bool ValidateCPF(string cpf)
        {
            if (cpf.Distinct().Count() == 1) return false;

            int[] firstWeights = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string baseDigits = cpf.Substring(0, 9);
            int totalSum = 0;

            for (int i = 0; i < 9; i++)
                totalSum += int.Parse(baseDigits[i].ToString()) * firstWeights[i];

            int remainder = totalSum % 11;
            int firstDigit = remainder < 2 ? 0 : 11 - remainder;

            int[] secondWeights = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            baseDigits = baseDigits + firstDigit;

            totalSum = 0;

            for (int i = 0; i < 10; i++)
                totalSum += int.Parse(baseDigits[i].ToString()) * secondWeights[i];

            remainder = totalSum % 11;
            int secondDigit = remainder < 2 ? 0 : 11 - remainder;

            return cpf.EndsWith(firstDigit.ToString() + secondDigit.ToString());
        }

        private bool ValidateCNPJ(string cnpj)
        {
            if (cnpj.Distinct().Count() == 1) return false;

            int[] firstWeights = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            string baseDigits = cnpj.Substring(0, 12);
            int totalSum = 0;

            for (int i = 0; i < 12; i++)
                totalSum += int.Parse(baseDigits[i].ToString()) * firstWeights[i];

            int remainder = totalSum % 11;
            int firstDigit = remainder < 2 ? 0 : 11 - remainder;

            int[] secondWeights = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            baseDigits += firstDigit;
            totalSum = 0;

            for (int i = 0; i < 13; i++)
                totalSum += int.Parse(baseDigits[i].ToString()) * secondWeights[i];

            remainder = totalSum % 11;
            int secondDigit = remainder < 2 ? 0 : 11 - remainder;

            return cnpj.EndsWith(firstDigit.ToString() + secondDigit.ToString());
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Number) || Number.Length < 11) 
                return string.Empty;

            return Type switch
            {
                CustomerTypeEnum.Physical => FormatCPF(Number),
                CustomerTypeEnum.Legal => FormatCNPJ(Number),
                _ => string.Empty
            };
        }

        private string FormatCPF(string cpf)
        {
            return $@"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
        }

        private string FormatCNPJ(string cnpj)
        {
            return $@"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12, 2)}";
        }
    }
}
