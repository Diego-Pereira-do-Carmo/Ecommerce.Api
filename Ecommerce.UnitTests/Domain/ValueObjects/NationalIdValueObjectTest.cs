
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.ValueObjects;
using Ecommerce.UnitTests.Domain.ValueObjects.TestValueObjectData;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Ecommerce.UnitTests.Domain.ValueObjects
{
    public class NationalIdValueObjectTest
    {
        [Fact]
        public void Given_ValidCpf_When_PhoneNumberIsInstantiated_Then_PropertyShouldBeNormalized()
        {
            var nationalId = new NationalIdValueObject(NationalIdValueObjectData.ValidCpf);

            using (new AssertionScope())
            {
                nationalId.Type.Should().Be(CustomerTypeEnum.Physical);
                nationalId.Number.Should().HaveLength(11);
                nationalId.Number.Should().Be("43333355078");
                nationalId.ToString().Should().Be("433.333.550-78");
            }
        }

        [Fact]
        public void Given_ValidCnpj_When_PhoneNumberIsInstantiated_Then_PropertyShouldBeNormalized()
        {
            var nationalId = new NationalIdValueObject(NationalIdValueObjectData.ValidCnpj);

            using (new AssertionScope())
            {
                nationalId.Type.Should().Be(CustomerTypeEnum.Legal);
                nationalId.Number.Should().HaveLength(14);
                nationalId.Number.Should().Be("30050763000108");
                nationalId.ToString().Should().Be($"30.050.763/0001-08");
            }
        }

        [Theory]
        [MemberData(nameof(NationalIdValueObjectData.GetInvalidNationalId), MemberType = typeof(NationalIdValueObjectData))]
        public void Given_NationalId_When_Instantiated_Then_ThrowDomainException(string number)
        {
            Action act = () => new NationalIdValueObject(number);
            act.Should().Throw<DomainException>();
        }

        [Fact]
        public void Given_TwoNationalIdTypePhysicalWithSameValues_Then_BeEqual()
        {
            var addressTest = AddressValueObjectData.AddressTest;

            var nationalId1 = new NationalIdValueObject("433.333.550-78");
            var nationalId2 = new NationalIdValueObject("43333355078");

            using (new AssertionScope())
            {
                nationalId1.Should().Be(nationalId2);
                (nationalId1 == nationalId2).Should().BeTrue();
                nationalId1.GetHashCode().Should().Be(nationalId2.GetHashCode());
            }
        }

        [Fact]
        public void Given_TwoNationalIdTypeLegalWithSameValues_Then_BeEqual()
        {
            var addressTest = AddressValueObjectData.AddressTest;

            var nationalId1 = new NationalIdValueObject("30.050.763/0001-08");
            var nationalId2 = new NationalIdValueObject("30050763000108");

            using (new AssertionScope())
            {
                nationalId1.Should().Be(nationalId2);
                (nationalId1 == nationalId2).Should().BeTrue();
                nationalId1.GetHashCode().Should().Be(nationalId2.GetHashCode());
            }
        }
    }
}
