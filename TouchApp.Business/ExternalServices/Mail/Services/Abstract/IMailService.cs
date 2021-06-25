using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.ExternalServices.Mail.Services.Abstract
{
    public interface IMailService
    {
        bool SendMail(MailRequest mailRequest);
    }
}
