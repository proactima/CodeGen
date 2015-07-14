  using System;
using System.Collections.Immutable;
using CodeGenInput;

namespace CodeGen
{
    public partial class InternalMailRequest
    {
        private InternalMailRequest(
            string company,
            string correlationId,
            ImmutableArray<MailAttachmentFromBlob> mailAttachementFromBlobs,
            string mailContent,
            string recipientEmailAddress,
            string senderEmailAddress,
            string subject)
        {
            Company = company;
            CorrelationId = correlationId;
            MailAttachementFromBlobs = mailAttachementFromBlobs;
            MailContent = mailContent;
            RecipientEmailAddress = recipientEmailAddress;
            SenderEmailAddress = senderEmailAddress;
            Subject = subject;
        }

        public string Company { get; }
        public string CorrelationId { get; }
        public ImmutableArray<MailAttachmentFromBlob> MailAttachementFromBlobs { get; }
        public string MailContent { get; }
        public string RecipientEmailAddress { get; }
        public string SenderEmailAddress { get; }
        public string Subject { get; }

        public static InternalMailRequest Create(
            string company,
            string mailContent,
            string recipientEmailAddress,
            string senderEmailAddress,
            string subject)
        {
            return new InternalMailRequest(
                company,
                Guid.NewGuid().ToString(),
                ImmutableArray<MailAttachmentFromBlob>.Empty,
                mailContent,
                recipientEmailAddress,
                senderEmailAddress,
                subject);
        }

        private InternalMailRequest With(
            string company = null,
            Optional<ImmutableArray<MailAttachmentFromBlob>> mailAttachementFromBlobs
                = default(Optional<ImmutableArray<MailAttachmentFromBlob>>),
            string mailContent = null,
            string recipientEmailAddress = null,
            string senderEmailAddress = null,
            string subject = null)
        {
            var newCompany = company ?? Company;
            var newMailAttachementFromBlobs = mailAttachementFromBlobs.HasValue
                ? mailAttachementFromBlobs.Value
                : MailAttachementFromBlobs;

            var newMailContent = mailContent ?? MailContent;
            var newRecipientEmailAddress = recipientEmailAddress ?? RecipientEmailAddress;
            var newSenderEmailAddress = senderEmailAddress ?? SenderEmailAddress;
            var newSubject = subject ?? Subject;

            if (newCompany == Company &&
                newMailAttachementFromBlobs == MailAttachementFromBlobs &&
                newMailContent == MailContent &&
                newRecipientEmailAddress == RecipientEmailAddress &&
                newSenderEmailAddress == SenderEmailAddress &&
                newSubject == Subject)
            {
                return this;
            }

            return new InternalMailRequest(
                newCompany,
                CorrelationId,
                newMailAttachementFromBlobs,
                newMailContent,
                newRecipientEmailAddress,
                newSenderEmailAddress,
                newSubject);
        }

        public InternalMailRequest WithCompany(string company)
        {
            return With(company: company);
        }

        public InternalMailRequest WithMailAttachementFromBlobs(ImmutableArray<MailAttachmentFromBlob> mailAttachementFromBlobs)
        {
            return With(mailAttachementFromBlobs: mailAttachementFromBlobs);
        }

        public InternalMailRequest WithMailContent(string mailContent)
        {
            return With(mailContent: mailContent);
        }

        public InternalMailRequest WithRecipientEmailAddress(string recipientEmailAddress)
        {
            return With(recipientEmailAddress: recipientEmailAddress);
        }

        public InternalMailRequest WithSenderEmailAddress(string senderEmailAddress)
        {
            return With(senderEmailAddress: senderEmailAddress);
        }

        public InternalMailRequest WithSubject(string subject)
        {
            return With(subject: subject);
        }
    }
}
  