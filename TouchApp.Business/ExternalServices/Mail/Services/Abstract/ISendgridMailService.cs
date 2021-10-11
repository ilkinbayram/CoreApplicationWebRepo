using System.Threading.Tasks;
using Core.Resources.Enums;
using TouchApp.Business.ExternalServices.Mail;

namespace Business.ExternalServices.Mail.Services.Abstract
{
    public interface ISendgridMailService
    {
        Task<bool> SendMailFromClientAsync(MailRequest mailRequest);
        Task<bool> SendMailFromServerAsync(MailRequest mailRequest);
    }
}