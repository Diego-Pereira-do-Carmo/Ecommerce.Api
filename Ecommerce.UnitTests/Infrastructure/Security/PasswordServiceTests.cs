using Ecommerce.Infrastructure.Security;
using FluentAssertions;
using FluentAssertions.Execution;

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
        public void Given_HashPasswordIsGenerate_Then_ReturnValidHash()
        {
            var password = "User@123456";

            var hash = _passwordService.HashPassword(password);

            hash.Should().NotBeNullOrEmpty();
            hash.Should().StartWith("$2a$");
            hash.Should().NotBe(password);
        }

        [Fact]
        public void Given_PasswordWithCorrectCredentials_Then_ReturnTrue()
        {
            var password = "TopSecret@123";
            var hash = _passwordService.HashPassword(password);

            var result = _passwordService.VerifyPassword(password, hash);

            result.Should().BeTrue();
        }

        [Fact]
        public void Given_PasswordWithWrongCredentials_Then_ReturnFalse()
        {
            var passwordCorrect = "TopSecret@123";
            var wrongPassword = "WrongPassword@123";

            var hash = _passwordService.HashPassword(passwordCorrect);
            var result = _passwordService.VerifyPassword(wrongPassword, hash);

            result.Should().BeFalse();
        }

        [Fact]
        public void Given_GenerateRandomPassword_Then_ReturnEightLength()
        {
            const int passwordLength = 8;
            var password = _passwordService.GenerateRandomPassword();

            password.Length.Should().Be(passwordLength);
        }

        [Fact]
        public void Given_GenerateRandomPassword_Then_ShouldNotContainAmbiguousCharacters()
        {
            var password = _passwordService.GenerateRandomPassword(200);

            password.Should().NotContainAny("I", "O", "l", "o");
        }

        [Fact]
        public void Given_GenerateRandomPassword_Then_ShouldMeetAllComplexityRequirements()
        {
            var password = _passwordService.GenerateRandomPassword();

            using (new AssertionScope())
            {
                password.Any(char.IsUpper).Should().BeTrue();
                password.Any(char.IsLower).Should().BeTrue();
                password.Any(char.IsDigit).Should().BeTrue();
                password.Any(c => "!@#$%^&*?_-".Contains(c)).Should().BeTrue();
            }
        }
    }
}
