using System;
using System.Collections.Immutable;

namespace ConsoleApplication1
{
    public class InternalMailRequest
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
        public ImmutableArray<MailAttachmentFromBlob> MailAttachementFromBlobs { get; }

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