using System.Runtime.Serialization;

namespace ConsoleApplication1
{
    [DataContract]
    public class MailAttachmentFromBlob
    {
        [DataMember] public readonly string ContentBlobId;

        [DataMember] public readonly string MimeType;

        [DataMember] public readonly string Name;

        private MailAttachmentFromBlob(string name, string mimeType, string contentBlobId)
        {
            MimeType = mimeType;
            Name = name;
            ContentBlobId = contentBlobId;
        }

        public static MailAttachmentFromBlob Create(string name, string mimeType, string contentBlobId)
        {
            return new MailAttachmentFromBlob(name, mimeType, contentBlobId);
        }

        private MailAttachmentFromBlob With(string name = null, string mimeType = null, string contentBlobId = null)
        {
            var newName = name ?? Name;
            var newMimeType = mimeType ?? MimeType;
            var newContentBlobId = contentBlobId ?? ContentBlobId;

            if (newName == Name &&
                newMimeType == MimeType &&
                newContentBlobId == ContentBlobId)
            {
                return this;
            }

            return new MailAttachmentFromBlob(newName, newMimeType, newContentBlobId);
        }

        public MailAttachmentFromBlob WithName(string name)
        {
            return With(name: name);
        }

        public MailAttachmentFromBlob WithMimeType(string mimeType)
        {
            return With(mimeType: mimeType);
        }

        public MailAttachmentFromBlob WithContentBlobId(string contentBlobId)
        {
            return With(contentBlobId: contentBlobId);
        }
    }
}