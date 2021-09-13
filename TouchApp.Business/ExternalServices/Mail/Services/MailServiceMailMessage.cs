using Business.ExternalServices.Mail.Services.Abstract;
using Core.Utilities.Helpers.Abstracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Business.ExternalServices.Mail.Services
{
    public class MailServiceMailMessage : IMailService
    {
        private IConfigHelper _configHelper;
        MailMessage _mailService = new MailMessage();
        public MailServiceMailMessage(IConfigHelper configHelper)
        {
            _configHelper = configHelper;
        }


        public bool SendMail(MailRequest mailRequest)
        {
            return SendMail(mailRequest.Body, new List<string> { mailRequest.ToEmail }, mailRequest.Subject);
        }
        public bool SendMail(string body, List<string> to, string subject, bool isHMTL = true)
        {
            bool result = false;
            try
            {
                var message = _mailService;
                message.From = new MailAddress(_configHelper.GetSettingsData<string>("Mail", "MailSettings"));

                to.ForEach(x =>
                {
                    message.To.Add(new MailAddress(x));
                });
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = isHMTL;

                using (var smtp = new SmtpClient(
                    _configHelper.GetSettingsData<string>("Host", "MailSettings"),
                    _configHelper.GetSettingsData<int>("Port", "MailSettings")))
                {
                    smtp.EnableSsl = false;
                    smtp.Credentials = new NetworkCredential(_configHelper.GetSettingsData<string>("Mail", "MailSettings"), _configHelper.GetSettingsData<string>("Password", "MailSettings"));
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                    result = true;
                };
            }
            catch (Exception)
            {

            }


            return result;
        }
    }
}
