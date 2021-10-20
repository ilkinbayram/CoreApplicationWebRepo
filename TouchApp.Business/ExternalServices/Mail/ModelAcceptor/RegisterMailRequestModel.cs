using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;

namespace TouchApp.Business.ExternalServices.Mail.ModelAcceptor
{
    public class RegisterMailRequestModel
    {
        public RegisterMailRequestModel()
        {
            Attachments = new List<IFormFile>();
        }

        [DisplayName("FromEmail_MailProp.Localization")]
        public string FromEmail { get; set; }

        [DisplayName("Phone_MailProp.Localization")]
        public string Phone { get; set; }

        [DisplayName("Message_MailProp.Localization")]
        public string Message { get; set; }

        [DisplayName("Name_MailProp.Localization")]
        public string Name { get; set; }

        public short Lang_oid { get; set; }
        public List<IFormFile> Attachments { get; set; }

    }
}
