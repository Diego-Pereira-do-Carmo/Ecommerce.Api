
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class TemplateEmail : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Subject { get; private set; } = string.Empty;
        public string Body { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public virtual ICollection<Email> Emails { get; private set; } = new List<Email>();


        protected TemplateEmail() { }

        public TemplateEmail(string name, string subject, string body, string? description = null)
        {
            Update(name, subject, body, description);
        }

        public void Update(string name, string subject, string body, string? description = null)
        {
            Guard.AgainstNullOrEmpty(name, nameof(name));
            Guard.AgainstNullOrEmpty(subject, nameof(subject));
            Guard.AgainstNullOrEmpty(body, nameof(body));

            Name = name.Trim().ToUpper().Replace(" ", "_");
            Subject = subject.Trim();
            Body = body;
            Description = description?.Trim();
        }
    }
}
