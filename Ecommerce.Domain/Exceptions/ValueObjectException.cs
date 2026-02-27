
namespace Ecommerce.Domain.Exceptions
{
    public class ValueObjectException : DomainException
    {
        public ValueObjectException(string message) : base(message) { }
    }
}
