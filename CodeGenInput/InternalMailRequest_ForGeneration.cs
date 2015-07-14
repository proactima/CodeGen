using System.Collections.Immutable;
using CodeGenInput.Attributes;

namespace CodeGenInput
{
    [IncludeInGeneration]
    public class InternalMailRequest_ForGeneration
    {
        public string Company { get; }

        [ExcludeFromWith]
        [NotInFactory("Guid.NewGuid().ToString()")]
        public string CorrelationId { get; }

        [Optional]
        [NotInFactory("ImmutableArray<MailAttachmentFromBlob>.Empty")]
        public ImmutableArray<MailAttachmentFromBlob_ForGeneration> MailAttachementFromBlobs { get; }

        public string MailContent { get; }
        public string RecipientEmailAddress { get; }
        public string SenderEmailAddress { get; }
        public string Subject { get; }
    }
}