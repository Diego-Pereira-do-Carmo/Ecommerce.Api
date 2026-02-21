
namespace Ecommerce.Domain.Exceptions
{
    internal class ValueObjectException : Exception
    {
        public ValueObjectException(string message) : base(message) { }
    }
}
