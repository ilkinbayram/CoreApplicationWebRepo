namespace Business.ExternalServices.Mail.Services.Abstract
{
    public interface IMailService
    {
        bool SendMail(MailRequest mailRequest);
    }
}
