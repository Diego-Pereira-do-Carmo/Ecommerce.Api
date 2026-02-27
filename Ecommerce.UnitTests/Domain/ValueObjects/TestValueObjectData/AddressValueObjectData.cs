
namespace Ecommerce.UnitTests.Domain.ValueObjects.TestValueObjectData
{
    public record AddressTestInput(string Street, string Number, string District, string City, string State, string PostalCode);

    public static class AddressValueObjectData
    {
        public static AddressTestInput AddressTest => new("  Rua Capri  ", " 145 A ", "Pinheiros", "São Paulo", "sp", "05425-030");

        public static IEnumerable<object[]> GetTestCasesInvalidCeps()
        {
            yield return new object[] { "1234567" };
            yield return new object[] { "123456789" };
            yield return new object[] { "123A5678" };
            yield return new object[] { "        " };
            yield return new object[] { "12-345-6" };
            yield return new object[] { null };
        }

        public static IEnumerable<object[]> GetTestCasesInvalidStates()
        {
            yield return new object[] { "ZZ" };
            yield return new object[] { " XX " };
            yield return new object[] { "11" };
            yield return new object[] { "  " };
            yield return new object[] { "" };
            yield return new object[] { null };
        }
    }
}