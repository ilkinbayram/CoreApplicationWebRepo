using AutoMapper;
using Business.ExternalServices.Mail.Services.Abstract;
using Core.Resources.Enums;
using Core.Utilities.Helpers;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using TouchApp.Business.ExternalServices.Mail;
using TouchApp.Business.ExternalServices.Mail.MailTemplateModels.SendGrid;

namespace Business.ExternalServices.Mail.Services
{
    public class SendGridService : ISendgridMailService
    {
        private IMapper _mapper;

        public SendGridService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<bool> SendMailFromClientAsync(MailRequest mailRequest)
        {
            var modelSendGrid = _mapper.Map<ClientStaticMailTemplate>(mailRequest);

            var toRegisterServerMail = ConfigHelper.GetSettingsDataStatic<string>(
                ParentKeySettings.GlobalAccessibility_ContainerKeyword.ToString(),
                ChildKeySettings.RegisterMail_GlobalAccess.ToString());

            var clientStaticEmail = ConfigHelper.GetSettingsDataStatic<string>(
                ParentKeySettings.GlobalAccessibility_ContainerKeyword.ToString(),
                ChildKeySettings.Static_ClientEmailEquivalent.ToString());

            var apiKey = ConfigHelper.GetSettingsDataStatic<string>(
                ParentKeySettings.EmailConfiguration.ToString(), 
                ChildKeySettings.Email_SendGrid_ApiKey.ToString());
            
            var client = new SendGridClient(apiKey);

            var sendGridMessage = new SendGridMessage();

            sendGridMessage.SetFrom(clientStaticEmail, $"Client : {mailRequest.Name}");
            sendGridMessage.AddTo(toRegisterServerMail, "Server Register Admin");
            sendGridMessage.SetTemplateId("d-a747e832df4241deb750de7c0e617299");
            sendGridMessage.SetTemplateData(modelSendGrid);

            var response = await client.SendEmailAsync(sendGridMessage);

            return response.IsSuccessStatusCode;
        }

        public async Task SendMailFromServerAsync(MailRequest mailRequest)
        {
            
        }
    }
}