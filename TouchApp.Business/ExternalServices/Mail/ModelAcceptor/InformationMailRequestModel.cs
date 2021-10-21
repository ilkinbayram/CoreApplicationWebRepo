using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;

namespace TouchApp.Business.ExternalServices.Mail.ModelAcceptor
{
    public class InformationMailRequestModel
    {
        [DisplayName("FromEmail_MailProp.Localization")]
        public string FromEmail { get; set; }

        [DisplayName("Subject_MailProp.Localization")]
        public string Subject { get; set; }

        [DisplayName("Message_MailProp.Localization")]
        public string Message { get; set; }

        [DisplayName("Name_MailProp.Localization")]
        public string Name { get; set; }

        public short Lang_oid { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
