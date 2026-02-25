
namespace Ecommerce.Domain.Exceptions
{
    public class ValueObjectException : Exception
    {
        public ValueObjectException(string message) : base(message) { }
    }
}
