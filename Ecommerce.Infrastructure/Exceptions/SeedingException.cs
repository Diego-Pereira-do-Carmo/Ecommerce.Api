
namespace Ecommerce.Infrastructure.Exceptions
{
    internal class SeedingException : Exception
    {
        public string EntityName { get; }
        public string Details { get; }

        public SeedingException(
            string entityName,
            string message,
            string details = null
        )
           : base($"{message} (Entidade: {entityName})")
        {
            EntityName = entityName;
            Details = details;
        }
    }
}
