
using Ecommerce.Domain.Utils;
using System.IO;

namespace Ecommerce.Domain.Entities
{
    public class EntityMetadata
    {
        public Guid Id { get; set; }
        public string EntityName { get; set; } = string.Empty;
        public string EntityCode { get; set; } = string.Empty;

        protected EntityMetadata() { }

        public EntityMetadata(Guid id, string entityName, string entityCode)
        {
            Guard.AgainstEmptyGuid(id, nameof(id));
            Guard.AgainstNullOrEmpty(entityName, nameof(entityName));
            Guard.AgainstNullOrEmpty(entityCode, nameof(entityCode));

            Id = id;
            EntityName = entityName;
            EntityCode = entityCode;
        }
    }
}
