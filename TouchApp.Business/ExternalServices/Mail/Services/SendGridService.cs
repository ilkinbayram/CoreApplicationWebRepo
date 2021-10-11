using AutoMapper;
using Business.ExternalServices.Mail.Services.Abstract;
using Core.Extensions;
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

        public async Task<bool> SendMailFromServerAsync(MailRequest mailRequest)
        {
            var modelSendGrid = new WelcomeMailTemplate()
            {
                SubjectMail = "MailTemplate.SubjectLocalization".Translate(mailRequest.LanguageID),
                Hello_Name = "MailTemplate.HelloNameLocalization".Translate(mailRequest.LanguageID)+", "+mailRequest.Name +" !",
                Message_By = "MailTemplate.MessageByLocalization".Translate(mailRequest.LanguageID),
                Best_Regards = "MailTemplate.BestRegardsLocalization".Translate(mailRequest.LanguageID),
                Link_Of_Navigation = "MailTemplate.NavigationTextLocalization".Translate(mailRequest.LanguageID),
                Information_After_Hello_List_Header = "MailTemplate.InformationAfterHelloListHeaderLocalization".Translate(mailRequest.LanguageID),
                Last_Information = "MailTemplate.LastInformationLocalization".Translate(mailRequest.LanguageID),
                Go_To_Our_Website = "MailTemplate.GoToOurWebsiteLocalization".Translate(mailRequest.LanguageID),
                List1_Text = "MailTemplate.List1TextLocalization".Translate(mailRequest.LanguageID),
                List2_Text = "MailTemplate.List2TextLocalization".Translate(mailRequest.LanguageID),
                List3_Text = "MailTemplate.List3TextLocalization".Translate(mailRequest.LanguageID),
                Welcome_Message = "MailTemplate.WelcomeMessageLocalization".Translate(mailRequest.LanguageID)
            };

            var fromRegisterServerMail = ConfigHelper.GetSettingsDataStatic<string>(
                ParentKeySettings.GlobalAccessibility_ContainerKeyword.ToString(),
                ChildKeySettings.RegisterMail_GlobalAccess.ToString());

            var toClientStaticEmail = mailRequest.FromEmail;

            var apiKey = ConfigHelper.GetSettingsDataStatic<string>(
                ParentKeySettings.EmailConfiguration.ToString(),
                ChildKeySettings.Email_SendGrid_ApiKey.ToString());

            var client = new SendGridClient(apiKey);

            var sendGridMessage = new SendGridMessage();

            sendGridMessage.SetFrom(fromRegisterServerMail, $"Touch Academy : Server Admin");
            sendGridMessage.AddTo(toClientStaticEmail, $"Approver : {mailRequest.Name}");
            sendGridMessage.SetTemplateId("d-4673ce006f634ceb97a43a9bc0ed540f");
            sendGridMessage.SetTemplateData(modelSendGrid);

            var response = await client.SendEmailAsync(sendGridMessage);

            return response.IsSuccessStatusCode;
        }
    }
}