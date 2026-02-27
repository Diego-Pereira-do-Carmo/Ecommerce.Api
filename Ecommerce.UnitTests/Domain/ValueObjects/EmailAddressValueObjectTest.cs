
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.ValueObjects;
using Ecommerce.UnitTests.Domain.ValueObjects.TestValueObjectData;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Ecommerce.UnitTests.Domain.ValueObjects
{
    public class EmailAddressValueObjectTest
    {
        [Fact]
        public void Given_ValidData_When_EmailAddressIsInstantiated_Then_PropertyShouldBeNormalized()
        {
            var emailAddress = new EmailAddressValueObject(EmailAddressValueObjectData.EmailAddressTest);

            emailAddress.Value.Should().Be("user.test@gmail.com");
        }

        [Theory]
        [MemberData(nameof(EmailAddressValueObjectData.GetInvalidEmails), MemberType = typeof(EmailAddressValueObjectData))]
        public void Given_InvalidEmail_When_EmailIsInstantiated_Then_ThrowDomainException(string invalidEmail)
        {
            Action act = () => new EmailAddressValueObject(invalidEmail);

            act.Should().Throw<DomainException>();
        }

        [Fact]
        public void Given_ValidEmail_When_GetUserName_Then_ReturnPartBeforeAt()
        {
            var email = new EmailAddressValueObject(EmailAddressValueObjectData.EmailAddressTest);

            var userName = email.GetUserName();

            userName.Should().Be("user.test");
        }

        [Fact]
        public void Given_TwoEmailAddressWithSameValues_Then_BeEqual()
        {
            var addressTest = AddressValueObjectData.AddressTest;

            var emailAddress1 = new EmailAddressValueObject(EmailAddressValueObjectData.EmailAddressTest);
            var emailAddress2 = new EmailAddressValueObject(EmailAddressValueObjectData.EmailAddressTest);

            using (new AssertionScope())
            {
                emailAddress1.Should().Be(emailAddress2);
                (emailAddress1 == emailAddress2).Should().BeTrue();
                emailAddress1.GetHashCode().Should().Be(emailAddress2.GetHashCode());
            }
        }
    }
}
