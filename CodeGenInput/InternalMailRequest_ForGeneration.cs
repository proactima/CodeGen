using System.Collections.Immutable;
using CodeGenInput.Attributes;

namespace CodeGenInput
{
    [IncludeInGeneration]
    public class InternalMailRequest_ForGeneration
    {
        [IncludeInGen]
        public string Company { get; }

        [IncludeInGen]
        [ExcludeFromWith]
        [NotInFactory("Guid.NewGuid().ToString()")]
        public string CorrelationId { get; }

        [IncludeInGen]
        [Optional]
        [NotInFactory("ImmutableArray<MailAttachmentFromBlob>.Empty")]
        public ImmutableArray<MailAttachmentFromBlob_ForGeneration> MailAttachementFromBlobs { get; }

        [IncludeInGen]
        public string MailContent { get; }

        [IncludeInGen]
        public string RecipientEmailAddress { get; }

        [IncludeInGen]
        public string SenderEmailAddress { get; }

        [IncludeInGen]
        public string Subject { get; }
        
    }
}