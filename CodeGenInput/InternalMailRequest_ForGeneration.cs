using System.Collections.Immutable;
using CodeGenInput.Attributes;

namespace CodeGenInput
{
    [IncludeInGeneration]
    public class InternalMailRequest_ForGeneration
    {
        public string Company { get; set; }

        [ExcludeFromWith]
        [DefaultValue("Guid.NewGuid().ToString()")]
        public string CorrelationId { get; set; }

        [Optional]
        [DefaultValue("ImmutableArray<MailAttachmentFromBlob>.Empty")]
        public ImmutableArray<MailAttachmentFromBlob_ForGeneration> MailAttachementFromBlobs { get; set; }

        public string MailContent { get; set; }
        public string RecipientEmailAddress { get; set; }
        public string SenderEmailAddress { get; set; }
        public string Subject { get; set; }
    }
}