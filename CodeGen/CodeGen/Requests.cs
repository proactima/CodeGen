using System;
using System.Collections.Immutable;

namespace CodeGen
{
	public class Request
	{
		private Request(
            string company,
            string correlationid,
            ImmutableArray<MailAttachmentFromBlob> mailattachementfromblobs,
            string mailcontent,
            string recipientemailaddress,
            string senderemailaddress,
            string subject)
        {
            Company = company;
            CorrelationId = correlationid;
            MailAttachementFromBlobs = mailattachementfromblobs;
            MailContent = mailcontent;
            RecipientEmailAddress = recipientemailaddress;
            SenderEmailAddress = senderemailaddress;
            Subject = subject;
		}

        public string Company { get; }
        public string CorrelationId { get; }
        public ImmutableArray<MailAttachmentFromBlob> MailAttachementFromBlobs { get; }
        public string MailContent { get; }
        public string RecipientEmailAddress { get; }
        public string SenderEmailAddress { get; }
        public string Subject { get; }

        public static Request Create(
		    string company,
            string mailcontent,
            string recipientemailaddress,
            string senderemailaddress,
            string subject)
        {
		    return new Request(
			    company,
                Guid.NewGuid().ToString(),
                ImmutableArray<MailAttachmentFromBlob>.Empty,
                mailcontent,
                recipientemailaddress,
                senderemailaddress,
                subject
			    );
        }

		private Request With(
		    string company = null,
            Optional<ImmutableArray<MailAttachmentFromBlob>> mailattachementfromblobs
                = default(Optional<ImmutableArray<MailAttachmentFromBlob>>),
            string mailcontent = null,
            string recipientemailaddress = null,
            string senderemailaddress = null,
            string subject = null)
		{
            var newCompany = company ?? Company;
            var newMailAttachementFromBlobs = mailattachementfromblobs.HasValue
                ? mailattachementfromblobs.Value
                : MailAttachementFromBlobs;
            var newMailContent = mailcontent ?? MailContent;
            var newRecipientEmailAddress = recipientemailaddress ?? RecipientEmailAddress;
            var newSenderEmailAddress = senderemailaddress ?? SenderEmailAddress;
            var newSubject = subject ?? Subject;

            if(newCompany == Company &&
                newMailAttachementFromBlobs == MailAttachementFromBlobs &&
                newMailContent == MailContent &&
                newRecipientEmailAddress == RecipientEmailAddress &&
                newSenderEmailAddress == SenderEmailAddress &&
                newSubject == Subject)
			{
                return this;
			}

			return new Request(newCompany,
                CorrelationId,
                newMailAttachementFromBlobs,
                newMailContent,
                newRecipientEmailAddress,
                newSenderEmailAddress,
                newSubject);
		}

        public Request WithCompany(string company)
        {
            return With(company: company);
        }

        public Request WithMailAttachementFromBlobs(ImmutableArray<MailAttachmentFromBlob> mailattachementfromblobs)
        {
            return With(mailattachementfromblobs: mailattachementfromblobs);
        }

        public Request WithMailContent(string mailcontent)
        {
            return With(mailcontent: mailcontent);
        }

        public Request WithRecipientEmailAddress(string recipientemailaddress)
        {
            return With(recipientemailaddress: recipientemailaddress);
        }

        public Request WithSenderEmailAddress(string senderemailaddress)
        {
            return With(senderemailaddress: senderemailaddress);
        }

        public Request WithSubject(string subject)
        {
            return With(subject: subject);
        }
	}
}