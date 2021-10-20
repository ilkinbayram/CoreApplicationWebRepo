using System.Threading.Tasks;
using Core.Resources.Enums;
using Core.Utilities.Results;
using TouchApp.Business.ExternalServices.Mail;
using TouchApp.Business.ExternalServices.Mail.ModelAcceptor;

namespace Business.ExternalServices.Mail.Services.Abstract
{
    public interface ISendgridMailService
    {
        IDataResult<bool> SendInformationMailFromClient(InformationMailRequestModel mailRequest);
        IDataResult<bool> SendQuickRegisterMailFromClient(QuickRegisterMailRequestModel mailRequest);
        IDataResult<bool> SendRegisterMailFromClient(RegisterMailRequestModel mailRequest);
    }
}