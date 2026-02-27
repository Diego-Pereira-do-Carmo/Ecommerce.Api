
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.Utils;
using FluentAssertions;

namespace Ecommerce.UnitTests.Domain.Utils
{
    public class GuardTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Given_FieldIsNullOrEmpty_Then_ThrowException(string? value)
        {
            Action act = () => Guard.AgainstNullOrEmpty(value, "Campo");

            act.Should().Throw<DomainException>()
               .WithMessage("Campo não pode ser vazio.");
        }

        [Fact]
        public void Given_FieldIsMaxLength_Then_ThrowException()
        {
            var value = "123456";
            Action act = () => Guard.AgainstMaxLength(value, 5, "Campo");

            act.Should().Throw<DomainException>()
               .WithMessage("Campo deve ter no máximo 5 caracteres.");
        }

        [Fact]
        public void Given_GuidIsNullOrEmpty_Then_ThrowException()
        {
            Action act = () => Guard.AgainstEmptyGuid(Guid.Empty, "Campo");

            act.Should().Throw<DomainException>()
               .WithMessage("Campo deve ser um Id válido.");
        }

        [Fact]
        public void Given_FieldIsMinValue_Then_ThrowException()
        {
            Action act = () => Guard.AgainstMinValue(10m, 15m, "Campo");

            act.Should().Throw<DomainException>()
               .WithMessage("Campo não pode ser menor que 15.");
        }

        [Fact]
        public void Given_FieldIsMinDate_Then_ThrowException()
        {
            var minDate = new DateTime(2020, 01, 01);
            var invalidDate = new DateTime(2019, 12, 31);

            Action act = () => Guard.AgainstMinDate(invalidDate, minDate, "Campo");

            act.Should().Throw<DomainException>()
               .WithMessage($"Campo 31/12/2019 não pode ser anterior a 01/01/2020");
        }

        [Theory]
        [InlineData("invalid-url")]
        [InlineData("    ")]
        [InlineData("google.com")]
        public void Given_InvalidUrl_Then_ThrowException(string url)
        {
            Action act = () => Guard.AgainstInvalidUrl(url, "Site");

            act.Should().Throw<DomainException>()
               .WithMessage("Site não é uma URL válida.");
        }

        [Theory]
        [InlineData("123456")]
        [InlineData("Senha123")]
        [InlineData("senha!@#123")]
        [InlineData("SENHA!@#123")]
        public void Given_WeakPassword_Then_ThrowException(string password)
        {
            Action act = () => Guard.AgainstWeakPassword(password, "Campo");

            act.Should().Throw<DomainException>()
               .WithMessage("Campo a senha não atende aos padrões requeridos.");
        }

        [Fact]
        public void Given_FieldsWithValidData_Then_NotThrowException()
        {
            Action act = () =>
            {
                Guard.AgainstNullOrEmpty("Válido", "Campo");
                Guard.AgainstMaxLength("123", 5, "Campo");
                Guard.AgainstEmptyGuid(Guid.NewGuid(), "Campo");
                Guard.AgainstMinValue(100m, 50m, "Campo");
                Guard.AgainstInvalidUrl("https://www.google.com/", "Campo");
                Guard.AgainstWeakPassword("Teste@1234", "Campo");
            };

            act.Should().NotThrow();
        }
    }
}
