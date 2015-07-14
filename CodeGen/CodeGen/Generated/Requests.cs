
using System;
using System.Collections.Immutable;
using CodeGenInput;

namespace CodeGen
{
    public partial class MailAttachmentFromBlob
    {
        private MailAttachmentFromBlob(
            string contentBlobId,
            string mimeType,
            string name)
        {
            ContentBlobId = contentBlobId;
            MimeType = mimeType;
            Name = name;
        }

        public string ContentBlobId { get; }
        public string MimeType { get; }
        public string Name { get; }

        public static MailAttachmentFromBlob Create(
            string contentBlobId,
            string mimeType,
            string name)
        {
            return new MailAttachmentFromBlob(
                contentBlobId,
                mimeType,
                name);
        }
    }
}