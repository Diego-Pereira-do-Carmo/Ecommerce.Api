
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.Utils;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public NationalIdValueObject NationalId { get; private set; } = null!;
        public string? CorporateName { get; private set; }
        public string? TradeName { get; private set; }
        public string? StateRegistration { get; private set; }
        public CustomerTypeEnum CustomerType { get; private set; }
        public GenderTypeEnum? GenderType { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public bool NewsletterSubscribed { get; private set; } = false;
        public Guid UserId { get; private set; }
        public User? User { get; private set; }
        public ICollection<Address> Addresses { get; private set; } = new List<Address>();
        public ICollection<CartItem> CartItems { get; private set; } = new List<CartItem>();


        protected Customer() { }

        public Customer(
            NationalIdValueObject nationalId,
            string? corporateName,
            string? tradeName,
            string? stateRegistration,
            CustomerTypeEnum customerType,
            GenderTypeEnum? genderType,
            DateTime? birthDate,
            Guid userId)
        {
            Update(nationalId, corporateName, tradeName, stateRegistration, customerType, genderType, birthDate, userId);
        }

        public void Update(
            NationalIdValueObject nationalId,
            string? corporateName,
            string? tradeName,
            string? stateRegistration,
            CustomerTypeEnum customerType,
            GenderTypeEnum? genderType,
            DateTime? birthDate,
            Guid userId)
        {
            Guard.AgainstEmptyGuid(userId, "UserId");

            if (customerType != nationalId.Type)
            {
                throw new DomainException("O tipo de pessoa não corresponde ao instanciar o Customer e o NationalIdValueObject");
            }

            if (customerType == CustomerTypeEnum.Legal)
            {
                ValidateLegalEntity(corporateName, birthDate, genderType);
            }
            else if (customerType == CustomerTypeEnum.Physical)
            {
                ValidatePhysicalPerson(birthDate, corporateName, tradeName, genderType, stateRegistration);
            }
            else
            {
                throw new DomainException("Deve ser indicado se é uma pessoa fisica ou jutidica");
            }

            NationalId = nationalId;
            CustomerType = nationalId.Type;
            UserId = userId;
            CorporateName = corporateName?.Trim();
            TradeName = tradeName?.Trim();
            StateRegistration = stateRegistration?.Trim();
            BirthDate = birthDate;
            GenderType = genderType;
        }

        private void ValidateLegalEntity(string? corporateName, DateTime? birthDate, GenderTypeEnum? genderType)
        {
            if (string.IsNullOrWhiteSpace(corporateName))
                throw new DomainException("Razão Social é obrigatória para Pessoa Jurídica.");

            if (birthDate.HasValue)
                throw new DomainException("Pessoa Jurídica não deve possuir data de nascimento.");

            if(genderType is not null)
                throw new DomainException("Pessoa Jurídica não deve possuir genero");
        }

        private void ValidatePhysicalPerson(DateTime? birthDate, string? corporateName, string? tradeName, GenderTypeEnum? genderType, string? stateRegistration)
        {
            if (!birthDate.HasValue)
                throw new DomainException("Data de nascimento é obrigatória para Pessoa Física.");

            if (birthDate > DateTime.UtcNow)
                throw new DomainException("A data de nascimento não pode ser no futuro.");

            if (!string.IsNullOrWhiteSpace(corporateName) || !string.IsNullOrWhiteSpace(tradeName) || !string.IsNullOrWhiteSpace(stateRegistration))
                throw new DomainException("Pessoa Física não deve possuir Razão Social, Nome Fantasia ou Inscrição Estadual.");

            if (!genderType.HasValue)
                throw new DomainException("Genero é obrigatório para Pessoa Física.");
        }
    }
}
