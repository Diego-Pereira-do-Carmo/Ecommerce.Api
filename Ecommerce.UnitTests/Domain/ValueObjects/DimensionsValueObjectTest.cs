using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.ValueObjects;
using Ecommerce.UnitTests.Domain.ValueObjects.TestValueObjectData;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Ecommerce.UnitTests.Domain.ValueObjects
{
    public class DimensionsValueObjectTest
    {
        [Fact]
        public void Given_ConstructorWithValidValues_When_DimensionsIsInstantiated_Then_CalculateVolume()
        {
            var dimensionsTest = DimensionsValueObjectData.DimensionsTest;

            var dimensions =  new DimensionsValueObject(dimensionsTest.Length, dimensionsTest.Width, dimensionsTest.Height, dimensionsTest.Weight);

            var test = dimensions.VolumeInCubicMeters;
            dimensions.VolumeInCubicMeters.Should().Be(0.1m);
        }

        [Theory]
        [MemberData(nameof(DimensionsValueObjectData.GetInvalidDimensions), MemberType = typeof(DimensionsValueObjectData))]
        public void Given_Constructor_WithInvalidValues_When_DimensionsIsInstantiated_Then_ThrowDomainException(DimensionsTestInput dimensionsTest)
        {
            Action act = () => new DimensionsValueObject(dimensionsTest.Length, dimensionsTest.Width, dimensionsTest.Height, dimensionsTest.Weight);

            act.Should().Throw<DomainException>();
        }

        [Fact]
        public void Given_TwoDimensionsWithSameValues_Then_BeEqual()
        {
            var dimensionsTest = DimensionsValueObjectData.DimensionsTest;

            var dimensions1 = new DimensionsValueObject(dimensionsTest.Length, dimensionsTest.Width, dimensionsTest.Height, dimensionsTest.Weight);
            var dimensions2 = new DimensionsValueObject(dimensionsTest.Length, dimensionsTest.Width, dimensionsTest.Height, dimensionsTest.Weight);

            using (new AssertionScope())
            {
                dimensions1.Should().Be(dimensions2);
                (dimensions1 == dimensions2).Should().BeTrue();
                dimensions1.GetHashCode().Should().Be(dimensions2.GetHashCode());
            }
        }

        [Fact]
        public void Given_DimensionsToString_When_ValidData_Then_FormatCorrect()
        {
            var dimensionsTest = DimensionsValueObjectData.DimensionsTest;
            var dimensions = new DimensionsValueObject(dimensionsTest.Length, dimensionsTest.Width, dimensionsTest.Height, dimensionsTest.Weight);

            var result = dimensions.ToString();
            result.Should().Be("100,00 L x 50,00 C x 20,00 A cm - 5,50 kg");
        }
    }
}
