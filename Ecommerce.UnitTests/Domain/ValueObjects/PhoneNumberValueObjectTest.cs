using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.ValueObjects;
using Ecommerce.UnitTests.Domain.ValueObjects.TestValueObjectData;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Ecommerce.UnitTests.Domain.ValueObjects
{
    public class PhoneNumberValueObjectTest
    {
        [Theory]
        [MemberData(nameof(PhoneNumberValueObjectData.GetValidPhoneNumbers), MemberType = typeof(PhoneNumberValueObjectData))]
        public void Given_ValidData_When_PhoneNumberIsInstantiated_Then_PropertyShouldBeNormalized(string validPhoneNumber, string expected)
        {
            var phoneNumber = new PhoneNumberValueObject(validPhoneNumber);

            phoneNumber.Value.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(PhoneNumberValueObjectData.GetInvalidPhoneNumbers), MemberType = typeof(PhoneNumberValueObjectData))]
        public void Given_InvalidNumber_When_Instantiated_Then_ShouldThrowDomainException(string invalidPhoneNumber)
        {
            Action act = () => new PhoneNumberValueObject(invalidPhoneNumber);

            act.Should().Throw<DomainException>();
        }

        [Fact]
        public void Given_TwoPhoneNumbersWithDifferentMasks_ShouldBeEqual()
        {
            var phoneNumber1 = new PhoneNumberValueObject("(11) 98888-7777");
            var phoneNumber2 = new PhoneNumberValueObject("11988887777");

            using (new AssertionScope())
            {
                phoneNumber1.Should().Be(phoneNumber2);
                (phoneNumber1 == phoneNumber2).Should().BeTrue();
                phoneNumber1.GetHashCode().Should().Be(phoneNumber1.GetHashCode());
            }
        }
    }
}
