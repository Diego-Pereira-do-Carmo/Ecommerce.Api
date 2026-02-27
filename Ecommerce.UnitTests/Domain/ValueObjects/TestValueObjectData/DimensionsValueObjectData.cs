
namespace Ecommerce.UnitTests.Domain.ValueObjects.TestValueObjectData
{
    public record DimensionsTestInput(decimal Length, decimal Width, decimal Height, decimal Weight);

    public static class DimensionsValueObjectData
    {
        public static DimensionsTestInput DimensionsTest => new(100m, 50m, 20m, 5.5m);

        public static IEnumerable<object[]> GetInvalidDimensions()
        {
            yield return new object[] { new DimensionsTestInput(0m, 10m, 10m, 1m) };
            yield return new object[] { new DimensionsTestInput(10m, -1m, 10m, 1m) };
            yield return new object[] { new DimensionsTestInput(10m, 10m, 0.005m, 1m) };
            yield return new object[] { new DimensionsTestInput(10m, 10m, 10m, 0.001m) };
        }
    }
}
