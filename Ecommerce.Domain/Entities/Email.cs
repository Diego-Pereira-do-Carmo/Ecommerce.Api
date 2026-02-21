
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Utils;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.Entities
{
    public class Email : BaseEntity
    {
        public EmailAddressValueObject EmailAddress { get; private set; } = null!;
        public string Subject { get; private set; } = string.Empty;
        public string Body { get; private set; } = string.Empty;
        public int SentAttempts { get; private set; } = 0;
        public string? LastErrorMessage { get; private set; }
        public DateTime? SentAt { get; private set; }
        public Guid TemplateEmailId { get; private set; }
        public Guid EmailStatusId { get; private set; }
        public Guid EntityMetadataId { get; private set; }
        public Guid ReferenceId { get; private set; }

        public TemplateEmail? TemplateEmail { get; private set; } 
        public EmailStatus? EmailStatus { get; private set; } 
        public EntityMetadata? EntityMetadata { get; private set; } 

        protected Email() { }

        public Email(
        EmailAddressValueObject emailAddress,
        string subject,
        string body,
        Guid templateEmailId,
        Guid emailStatusId,
        Guid entityMetadataId,
        Guid referenceId)
        {
            Guard.AgainstNullOrEmpty(subject, nameof(subject));
            Guard.AgainstNullOrEmpty(body, nameof(body));
            Guard.AgainstEmptyGuid(templateEmailId, nameof(templateEmailId));
            Guard.AgainstEmptyGuid(emailStatusId, nameof(emailStatusId));
            Guard.AgainstEmptyGuid(entityMetadataId, nameof(entityMetadataId));
            Guard.AgainstEmptyGuid(referenceId, nameof(referenceId));

            EmailAddress = emailAddress;
            Subject = subject.Trim();
            Body = body.Trim();
            TemplateEmailId = templateEmailId;
            EmailStatusId = emailStatusId;
            EntityMetadataId = entityMetadataId;
            ReferenceId = referenceId;
            SentAttempts = 0;
        }

        public void MarkAsSent(Guid successStatusId)
        {
            SentAt = DateTime.UtcNow;
            EmailStatusId = successStatusId;
            LastErrorMessage = null;
            SentAttempts++;
            //colocar o userId depois
        }

        public void RecordFailure(Guid failedStatusId, string errorMessage)
        {
            SentAttempts++;
            LastErrorMessage = errorMessage;
            EmailStatusId = failedStatusId;
            //colocar o userId depois
        }
    }
}
