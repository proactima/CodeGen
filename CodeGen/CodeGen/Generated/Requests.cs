
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

		}
    }
}