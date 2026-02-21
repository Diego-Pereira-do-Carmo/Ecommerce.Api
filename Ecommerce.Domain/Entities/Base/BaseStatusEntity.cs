
namespace Ecommerce.Domain.Entities.Base
{
    public abstract class BaseStatusEntity : BaseEntity
    {
        public string Flag { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
