
namespace Ecommerce.UnitTests.Domain.ValueObjects.TestValueObjectData
{
    public static class EmailAddressValueObjectData
    {
        public const string EmailAddressTest = "  User.Test@gmail.com  ";

        public static IEnumerable<object[]> GetInvalidEmails()
        {
            yield return new object[] { "sem-arroba.com" };
            yield return new object[] { "usuario@" };
            yield return new object[] { "@dominio.com" };
            yield return new object[] { "usuario@dominio" };
            yield return new object[] { "usuario@.com" };
            yield return new object[] { "" };
            yield return new object[] { "   " };
            yield return new object[] { null };
        }
    }
}
