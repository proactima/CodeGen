using CodeGenInput.Attributes;

namespace CodeGenInput
{
    [IncludeInGeneration]
    public class MailAttachmentFromBlob_ForGeneration
    {
        public string ContentBlobId { get; }
        public string MimeType { get; }
        public string Name { get; }
    }
}