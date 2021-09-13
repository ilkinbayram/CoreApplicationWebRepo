using Business.ExternalServices.Mail.Services.Abstract;
using Core.Utilities.Helpers.Abstracts;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.IO;

namespace Business.ExternalServices.Mail.Services
{
    public class MailServiceMimeKit : IMailService
    {
        private IConfigHelper _configHelper;
        public MailServiceMimeKit(IConfigHelper configHelper)
        {
            _configHelper = configHelper;
        }

        public bool SendMail(MailRequest mailRequest)
        {
            bool result = false;
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_configHelper.GetSettingsData<string>("Mail", "MailSettings"));
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using(var smtp = new SmtpClient())
            {
                smtp.CheckCertificateRevocation = false;
                smtp.Connect(
                    host: _configHelper.GetSettingsData<string>("Host", "MailSettings"),
                    port: _configHelper.GetSettingsData<int>("Port", "MailSettings"),
                    options: SecureSocketOptions.StartTls);
                smtp.Authenticate(
                    userName:_configHelper.GetSettingsData<string>("Mail", "MailSettings"), 
                    password:_configHelper.GetSettingsData<string>("Password", "MailSettings"));
                if (smtp.IsConnected && smtp.IsAuthenticated)
                    result = true;
                smtp.Send(email);
                smtp.Disconnect(true);
            };

            return result;
        }
    }
}
