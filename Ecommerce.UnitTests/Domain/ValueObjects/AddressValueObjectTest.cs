using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.ValueObjects;
using Ecommerce.UnitTests.Domain.ValueObjects.TestValueObjectData;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Ecommerce.UnitTests.Domain.ValueObjects
{
    public class AddressValueObjectTest
    {
        [Fact]
        public void Given_ValidData_When_AddressIsInstantiated_Then_PropertiesShouldBeNormalized()
        {
            var addressTest = AddressValueObjectData.AddressTest;

            var address = new AddressValueObject(addressTest.Street, addressTest.Number, addressTest.District, addressTest.City, addressTest.State, addressTest.PostalCode);
           
            using (new AssertionScope())
            {
                address.Street.Should().Be("Rua Capri");
                address.Number.Should().Be("145 A");
                address.District.Should().Be("Pinheiros");
                address.City.Should().Be("São Paulo");
                address.State.Should().Be("SP");
                address.PostalCode.Should().Be("05425030");
                address.Country.Should().Be("Brasil");
            }
        }

        [Theory]
        [MemberData(nameof(AddressValueObjectData.GetTestCasesInvalidStates), MemberType = typeof(AddressValueObjectData))]
        public void Given_ConstructorWithInvalidState_Then_ThrowDomainException(string invalidState)
        {
            var addressTest = AddressValueObjectData.AddressTest;

            Action act = () => new AddressValueObject(addressTest.Street, addressTest.Number, addressTest.District, addressTest.City, invalidState, addressTest.PostalCode);

            act.Should().Throw<DomainException>();
        }

        [Theory]
        [MemberData(nameof(AddressValueObjectData.GetTestCasesInvalidCeps), MemberType = typeof(AddressValueObjectData))]
        public void Given_InvalidCep_When_AddressIsInstantiated_Then_ThrowDomainException(string invalidPostalCode)
        {
            var addressTest = AddressValueObjectData.AddressTest;

            Action act = () => new AddressValueObject(addressTest.Street, addressTest.Number, addressTest.District, addressTest.City, addressTest.State, invalidPostalCode);

            act.Should().Throw<DomainException>();
        }

        [Fact]
        public void Given_AddressValueObjectToString_When_ValidData_Then_FormatCorrect()
        {
            var addressTest = AddressValueObjectData.AddressTest;
            var address = new AddressValueObject(addressTest.Street, addressTest.Number, addressTest.District, addressTest.City, addressTest.State, addressTest.PostalCode);

            var result = address.ToString();
                               
            result.Should().Be("Rua Capri, 145 A, Pinheiros, São Paulo - SP - Brasil, 05425-030");
        }

        [Fact]
        public void Given_TwoAddressWithSameValues_Then_BeEqual()
        {
            var addressTest = AddressValueObjectData.AddressTest;

            var address1 = new AddressValueObject(addressTest.Street, addressTest.Number, addressTest.District, addressTest.City, addressTest.State, addressTest.PostalCode);
            var address2 = new AddressValueObject(addressTest.Street, addressTest.Number, addressTest.District, addressTest.City, addressTest.State, addressTest.PostalCode);

            using (new AssertionScope())
            {
                address1.Should().Be(address2);
                (address1 == address2).Should().BeTrue();
                address1.GetHashCode().Should().Be(address2.GetHashCode());
            }
        }
    }
}
