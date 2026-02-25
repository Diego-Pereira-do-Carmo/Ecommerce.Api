

using Ecommerce.Infrastructure.Security;
using FluentAssertions;

namespace Ecommerce.UnitTests.Infrastructure.Security
{
    public class PasswordServiceTests
    {
        private readonly PasswordService _passwordService;

        public PasswordServiceTests()
        {
            _passwordService = new PasswordService();
        }

        [Fact]
        public void When_Hash_Password_Is_Generate_Should_Return_Valid_Hash()
        {
            var password = "User@123456";

            var hash = _passwordService.HashPassword(password);

            hash.Should().NotBeNullOrEmpty();
            hash.Should().StartWith("$2a$");
            hash.Should().NotBe(password);
        }

        [Fact]
        public void When_Password_With_Correct_Credentials_Should_Return_True()
        {
            var password = "TopSecret@123";
            var hash = _passwordService.HashPassword(password);

            var result = _passwordService.VerifyPassword(password, hash);

            result.Should().BeTrue();
        }

        [Fact]
        public void When_Password_With_Wrong_Password_Should_Return_False()
        {
            var passwordCorrect = "TopSecret@123";
            var wrongPassword = "WrongPassword@123";

            var hash = _passwordService.HashPassword(passwordCorrect);
            var result = _passwordService.VerifyPassword(wrongPassword, hash);

            result.Should().BeFalse();
        }

        [Fact]
        public void When_Generate_Random_Password_Should_Return_Eight_Length()
        {
            const int passwordLength = 8;
            var password = _passwordService.GenerateRandomPassword();

            password.Length.Should().Be(passwordLength);
        }

        [Fact]
        public void When_Generate_Random_Password_Should_Not_Contain_Ambiguous_Characters()
        {
            var password = _passwordService.GenerateRandomPassword(200);

            password.Should().NotContainAny("I", "O", "l", "o");
        }
    }
}
