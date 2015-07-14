
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

        private MailAttachmentFromBlob With(
            string contentBlobId = null,
            string mimeType = null,
            string name = null)
        {
            var newContentBlobId = contentBlobId ?? ContentBlobId;
            var newMimeType = mimeType ?? MimeType;
            var newName = name ?? Name;

            if(newContentBlobId == ContentBlobId &&
                newMimeType == MimeType &&
                newName == Name)
            {
                return this;
            }

            return new MailAttachmentFromBlob(
                newContentBlobId,
                newMimeType,
                newName);
        }
    }
}