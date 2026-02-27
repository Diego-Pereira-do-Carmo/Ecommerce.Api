
namespace Ecommerce.UnitTests.Domain.ValueObjects.TestValueObjectData
{
    public class NationalIdValueObjectData
    {
        public const string ValidCpf = "433.333.550-78";
        public const string ValidCnpj = "30.050.763/0001-08";

        public static IEnumerable<object[]> GetInvalidNationalId()
        {
            yield return new object[] { "12345678901" };
            yield return new object[] { "11111111111" };
            yield return new object[] { "12345678000190" };
            yield return new object[] { "123" };
            yield return new object[] { "123456789012345" };
        }
    }
}
