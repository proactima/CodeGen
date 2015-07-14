using System;
using System.Collections.Immutable;

namespace ConsoleApplication1
{
    public class InternalMailRequest
    {
        public InternalMailRequest()
        {
        }

        private InternalMailRequest(
            ImmutableArray<MailAttachmentFromBlob> attachments,
            string company,
            string mailContent,
            string recipientEmail,
            string senderEmail,
            string subject,
            string correlationId)
        {
            MailAttachementFromBlobs = attachments;
            Company = company;
            MailContent = mailContent;
            RecipientEmailAddress = recipientEmail;
            SenderEmailAddress = senderEmail;
            Subject = subject;
            CorrelationId = correlationId;
        }

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

        public static InternalMailRequest Create(
            string company,
            string mailContent,
            string recipientEmail,
            string senderEmail,
            string subject)
        {
            var correlationId = Guid.NewGuid().ToString();

            return new InternalMailRequest(
                ImmutableArray<MailAttachmentFromBlob>.Empty,
                company,
                mailContent,
                recipientEmail,
                senderEmail,
                subject,
                correlationId);
        }

        private InternalMailRequest With(
            string company = null,
            string mailContent = null,
            string recipientEmail = null,
            string senderEmail = null,
            string subject = null,
            Optional<ImmutableArray<MailAttachmentFromBlob>> attachments =
                default(Optional<ImmutableArray<MailAttachmentFromBlob>>)
            )
        {
            var newCompany = company ?? Company;
            var newMailContent = mailContent ?? MailContent;
            var newRecipientEmail = recipientEmail ?? RecipientEmailAddress;
            var newSenderEmail = senderEmail ?? SenderEmailAddress;
            var newSubject = subject ?? Subject;
            var newAttachments = attachments.HasValue ? attachments.Value : MailAttachementFromBlobs;

            if (newCompany == Company &&
                newMailContent == MailContent &&
                newRecipientEmail == RecipientEmailAddress &&
                newSenderEmail == SenderEmailAddress &&
                newSubject == Subject &&
                newAttachments == MailAttachementFromBlobs)
            {
                return this;
            }

            return new InternalMailRequest(newAttachments, newCompany, newMailContent, newRecipientEmail, newSenderEmail,
                newSubject, CorrelationId);
        }

        public InternalMailRequest WithCompany(string company)
        {
            return With(company: company);
        }

        public InternalMailRequest WithAttachments(ImmutableArray<MailAttachmentFromBlob> attachments)
        {
            return With(attachments: attachments);
        }

        public InternalMailRequest AddAttachment(MailAttachmentFromBlob attachment)
        {
            var attachments = MailAttachementFromBlobs.Add(attachment);

            return With(attachments: attachments);
        }
    }
}