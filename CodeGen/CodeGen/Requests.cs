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
	}
}