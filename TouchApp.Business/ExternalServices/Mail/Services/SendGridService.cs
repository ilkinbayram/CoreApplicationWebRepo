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
                SubjectMail = "MailTemplate.SubjectLocalization".Translate(mailRequest.Lang_oid),
                Hello_Name = "MailTemplate.HelloNameLocalization".Translate(mailRequest.Lang_oid)+", "+mailRequest.Name +" !",
                Message_By = "MailTemplate.MessageByLocalization".Translate(mailRequest.Lang_oid),
                Best_Regards = "MailTemplate.BestRegardsLocalization".Translate(mailRequest.Lang_oid),
                Link_Of_Navigation = "MailTemplate.NavigationTextLocalization".Translate(mailRequest.Lang_oid),
                Information_After_Hello_List_Header = "MailTemplate.InformationAfterHelloListHeaderLocalization".Translate(mailRequest.Lang_oid),
                Last_Information = "MailTemplate.LastInformationLocalization".Translate(mailRequest.Lang_oid),
                Go_To_Our_Website = "MailTemplate.GoToOurWebsiteLocalization".Translate(mailRequest.Lang_oid),
                List1_Text = "MailTemplate.List1TextLocalization".Translate(mailRequest.Lang_oid),
                List2_Text = "MailTemplate.List2TextLocalization".Translate(mailRequest.Lang_oid),
                List3_Text = "MailTemplate.List3TextLocalization".Translate(mailRequest.Lang_oid),
                Welcome_Message = "MailTemplate.WelcomeMessageLocalization".Translate(mailRequest.Lang_oid)
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

        public bool SendQuickRequestFromClientMail(MailRequest mailRequest)
        {
            var modelSendGridFromClient = _mapper.Map<ClientStaticMailTemplate>(mailRequest);

            var registerServerMail = ConfigHelper.GetSettingsDataStatic<string>(
                ParentKeySettings.GlobalAccessibility_ContainerKeyword.ToString(),
                ChildKeySettings.RegisterMail_GlobalAccess.ToString());

            var clientStaticEmail = ConfigHelper.GetSettingsDataStatic<string>(
                ParentKeySettings.GlobalAccessibility_ContainerKeyword.ToString(),
                ChildKeySettings.Static_ClientEmailEquivalent.ToString());

            var apiKey = ConfigHelper.GetSettingsDataStatic<string>(
                ParentKeySettings.EmailConfiguration.ToString(),
                ChildKeySettings.Email_SendGrid_ApiKey.ToString());

            var clientFromUser = new SendGridClient(apiKey);

            var sendGridMessageFromUser = new SendGridMessage();

            sendGridMessageFromUser.SetFrom(clientStaticEmail, "Client : No Name");
            sendGridMessageFromUser.AddTo(registerServerMail, "Server Quick Register");
            sendGridMessageFromUser.SetTemplateId("d-a747e832df4241deb750de7c0e617299");
            sendGridMessageFromUser.SetTemplateData(modelSendGridFromClient);

            var responseFromUser = clientFromUser.SendEmailAsync(sendGridMessageFromUser).Result;

            return responseFromUser.IsSuccessStatusCode;
        }

        public bool SendQuickRequestFromServerMail(MailRequest mailRequest)
        {
            var modelSendGridFromServer = new QuickRegisterMailTemplate()
            {
                Below_Link_Define = "QuickRegisterBelowLinkDefiner.TranslateLocalize".Translate(mailRequest.Lang_oid),
                Less_Contact_Description = "LessContactProblemDescription.TranslateLocalization".Translate(mailRequest.Lang_oid),
                Link_To_Telegram_Localize = "LinkToTelegramForMail.TranslateLocalization".Translate(mailRequest.Lang_oid),
                Link_To_Whatsapp_Localize = "LinkToWhatsappForMail.TranslateLocalization".Translate(mailRequest.Lang_oid),
                Subject_Mail = "SubjectQuickRegisterMail.TranslateLocalization".Translate(mailRequest.Lang_oid),
                Welcome_Quick_Register = "WelcomeTextQuickRegister.TranslateLocalization".Translate(mailRequest.Lang_oid)
            };

            var registerServerMail = ConfigHelper.GetSettingsDataStatic<string>(
                ParentKeySettings.GlobalAccessibility_ContainerKeyword.ToString(),
                ChildKeySettings.RegisterMail_GlobalAccess.ToString());

            var apiKey = ConfigHelper.GetSettingsDataStatic<string>(
                ParentKeySettings.EmailConfiguration.ToString(),
                ChildKeySettings.Email_SendGrid_ApiKey.ToString());

            var clientFromServer = new SendGridClient(apiKey);

            var sendGridMessageFromServer = new SendGridMessage();

            sendGridMessageFromServer.SetFrom(registerServerMail, $"Touch Academy : Server Quick Register");
            sendGridMessageFromServer.AddTo(mailRequest.FromEmail, $"Approver : No Name");
            sendGridMessageFromServer.SetTemplateId("d-d3cd3b0621794d9aa5d7563a6b9f1ab2");
            sendGridMessageFromServer.SetTemplateData(modelSendGridFromServer);

            var responseFromServer = clientFromServer.SendEmailAsync(sendGridMessageFromServer).Result;

            return responseFromServer.IsSuccessStatusCode;
        }

        public bool SendRegisterFromClientMail(MailRequest mailRequest)
        {
            var modelSendGridFromClient = _mapper.Map<ClientStaticMailTemplate>(mailRequest);

            var registerServerMail = ConfigHelper.GetSettingsDataStatic<string>(
                ParentKeySettings.GlobalAccessibility_ContainerKeyword.ToString(),
                ChildKeySettings.RegisterMail_GlobalAccess.ToString());

            var clientStaticEmail = ConfigHelper.GetSettingsDataStatic<string>(
                ParentKeySettings.GlobalAccessibility_ContainerKeyword.ToString(),
                ChildKeySettings.Static_ClientEmailEquivalent.ToString());

            var apiKey = ConfigHelper.GetSettingsDataStatic<string>(
                ParentKeySettings.EmailConfiguration.ToString(),
                ChildKeySettings.Email_SendGrid_ApiKey.ToString());

            var clientFromUser = new SendGridClient(apiKey);

            var sendGridMessageFromUser = new SendGridMessage();

            sendGridMessageFromUser.SetFrom(clientStaticEmail, $"Client : {mailRequest.Name}");
            sendGridMessageFromUser.AddTo(registerServerMail, "Server Register");
            sendGridMessageFromUser.SetTemplateId("d-a747e832df4241deb750de7c0e617299");
            sendGridMessageFromUser.SetTemplateData(modelSendGridFromClient);

            var responseFromUser = clientFromUser.SendEmailAsync(sendGridMessageFromUser).Result;

            return responseFromUser.IsSuccessStatusCode;
        }

        public bool SendRegisterFromServerMail(MailRequest mailRequest)
        {
            var modelSendGridFromServer = new WelcomeMailTemplate()
            {
                SubjectMail = "MailTemplate.SubjectLocalization".Translate(mailRequest.Lang_oid),
                Hello_Name = "MailTemplate.HelloNameLocalization".Translate(mailRequest.Lang_oid) + ", " + mailRequest.Name + " !",
                Message_By = "MailTemplate.MessageByLocalization".Translate(mailRequest.Lang_oid),
                Best_Regards = "MailTemplate.BestRegardsLocalization".Translate(mailRequest.Lang_oid),
                Link_Of_Navigation = "MailTemplate.NavigationTextLocalization".Translate(mailRequest.Lang_oid),
                Information_After_Hello_List_Header = "MailTemplate.InformationAfterHelloListHeaderLocalization".Translate(mailRequest.Lang_oid),
                Last_Information = "MailTemplate.LastInformationLocalization".Translate(mailRequest.Lang_oid),
                Go_To_Our_Website = "MailTemplate.GoToOurWebsiteLocalization".Translate(mailRequest.Lang_oid),
                List1_Text = "MailTemplate.List1TextLocalization".Translate(mailRequest.Lang_oid),
                List2_Text = "MailTemplate.List2TextLocalization".Translate(mailRequest.Lang_oid),
                List3_Text = "MailTemplate.List3TextLocalization".Translate(mailRequest.Lang_oid),
                Welcome_Message = "MailTemplate.WelcomeMessageLocalization".Translate(mailRequest.Lang_oid)
            };

            var registerServerMail = ConfigHelper.GetSettingsDataStatic<string>(
                ParentKeySettings.GlobalAccessibility_ContainerKeyword.ToString(),
                ChildKeySettings.RegisterMail_GlobalAccess.ToString());

            var apiKey = ConfigHelper.GetSettingsDataStatic<string>(
                ParentKeySettings.EmailConfiguration.ToString(),
                ChildKeySettings.Email_SendGrid_ApiKey.ToString());

            var clientFromServer = new SendGridClient(apiKey);

            var sendGridMessageFromServer = new SendGridMessage();

            sendGridMessageFromServer.SetFrom(registerServerMail, $"Touch Academy : Server Register");
            sendGridMessageFromServer.AddTo(mailRequest.FromEmail, $"Approver : {mailRequest.Name}");
            sendGridMessageFromServer.SetTemplateId("d-4673ce006f634ceb97a43a9bc0ed540f");
            sendGridMessageFromServer.SetTemplateData(modelSendGridFromServer);

            var responseFromServer = clientFromServer.SendEmailAsync(sendGridMessageFromServer).Result;

            return responseFromServer.IsSuccessStatusCode;
        }
    }
}