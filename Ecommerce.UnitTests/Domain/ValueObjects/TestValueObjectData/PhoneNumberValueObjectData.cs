
namespace Ecommerce.UnitTests.Domain.ValueObjects.TestValueObjectData
{
    public class PhoneNumberValueObjectData
    {
        public static IEnumerable<object[]> GetValidPhoneNumbers()
        {
            yield return new object[] { "(11) 4004-1234", "1140041234" };
            yield return new object[] { "11 98888-7777", "11988887777" };
            yield return new object[] { "+55 (11) 98888-7777", "5511988887777" };
        }

        public static IEnumerable<object[]> GetInvalidPhoneNumbers()
        {
            yield return new object[] { "123456789" };
            yield return new object[] { "11988887777665" };
            yield return new object[] { "abcdefghijk" };
            yield return new object[] { "" };
            yield return new object[] { null };
        }
    }
}
