using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace TouchApp.Business.ExternalServices.Mail
{
    public class MailRequest
    {
        public MailRequest()
        {
            Lang_oid = 0;
            MailType = 0;
            ToEmail = "";
            FromEmail = "";
            Subject = "";
            Attachments = new List<IFormFile>();
            Message = "";
            Phone = "";
            BodyHtml = "";
        }

        public string ToEmail { get; set; }
        public string FromEmail { get; set; }

        public string Subject { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Phone { get; set; }

        public string BodyHtml { get; set; }

        public byte MailType { get; set; }
        public short Lang_oid { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
