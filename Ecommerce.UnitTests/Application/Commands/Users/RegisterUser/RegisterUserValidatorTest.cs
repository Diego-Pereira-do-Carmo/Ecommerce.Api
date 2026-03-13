using Ecommerce.Application.Commands.Users.RegisterUser;
using FluentValidation.TestHelper;

namespace Ecommerce.UnitTests.Application.Commands.Users.RegisterUser
{
    public class RegisterUserValidatorTests
    {
        private readonly RegisterUserValidator _validator;

        public RegisterUserValidatorTests()
        {
            _validator = new RegisterUserValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("A")]
        [InlineData("Este nome e muito longo e certamente ultrapassa os cinquenta caracteres permitidos")]
        public void Given_FirstNameInvalid_Then_ReturnError(string? firstName)
        {
            var command = new RegisterUserCommand(firstName, "LastName", "teste@teste.com", "(11) 94002-8922");
            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("A")]
        [InlineData("Este nome e muito longo e certamente ultrapassa os cinquenta caracteres permitidos, Este nome e muito longo e certamente ultrapassa os cinquenta caracteres permitidos")]
        public void Given_LastNameInvalid_Then_ReturnError(string? lastName)
        {
            var command = new RegisterUserCommand("FirstName", lastName, "teste@teste.com", "(11) 94002-8922");
            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("email-invalido")]
        [InlineData("usuario@")]
        [InlineData("@dominio.com")]
        public void Given_EmailAddressInvalid_Then_ReturnError(string? email)
        {
            var command = new RegisterUserCommand("FirstName", "LastName", email, "(11) 94002-8922");
            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.EmailAddress);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("123456789")]
        [InlineData("12345678901234")]
        public void Given_MobilePhoneInvalid_Then_ReturnError(string? mobilePhone)
        {
            var command = new RegisterUserCommand("FirstName", "LastName", "teste@teste.com", mobilePhone);
            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.MobilePhone);
        }

        [Fact]
        public void Given_CommandWithValidData_Then_NotReturnError()
        {
            var command = new RegisterUserCommand("Teste", "Usuário", "teste.usuario@email.com", "11940028922");
            var result = _validator.TestValidate(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
