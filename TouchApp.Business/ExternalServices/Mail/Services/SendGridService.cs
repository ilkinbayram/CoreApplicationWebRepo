using AutoMapper;
using Business.ExternalServices.Mail.Services.Abstract;
using Core.Aspects.Autofac.Validation;
using Core.Extensions;
using Core.Resources.Enums;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using TouchApp.Business.ExternalServices.Mail;
using TouchApp.Business.ExternalServices.Mail.MailTemplateModels.SendGrid;
using TouchApp.Business.ExternalServices.Mail.ModelAcceptor;
using TouchApp.Business.ValidationRules.FluentValidation.MailModel;

namespace Business.ExternalServices.Mail.Services
{
    public class SendGridService : ISendgridMailService
    {
        private IMapper _mapper;

        public SendGridService(IMapper mapper)
        {
            _mapper = mapper;
        }

        [ValidationAspect(typeof(InformationMailRequestModelValidator))]
        public IDataResult<bool> SendInformationMailFromClient(InformationMailRequestModel mailRequest)
        {
            IDataResult<bool> result;
            try
            {
                var modelSendGrid = _mapper.Map<ClientStaticMailTemplate>(mailRequest);
                var serverModelSendGrid = new WelcomeMailTemplate()
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

                var serverInfoMail = ConfigHelper.GetSettingsDataStatic<string>(
                    ParentKeySettings.GlobalAccessibility_ContainerKeyword.ToString(),
                    ChildKeySettings.InfoMail_GlobalAccess.ToString());

                var clientStaticEmail = ConfigHelper.GetSettingsDataStatic<string>(
                    ParentKeySettings.GlobalAccessibility_ContainerKeyword.ToString(),
                    ChildKeySettings.Static_ClientEmailEquivalent.ToString());

                var apiKey = ConfigHelper.GetSettingsDataStatic<string>(
                    ParentKeySettings.EmailConfiguration.ToString(),
                    ChildKeySettings.Email_SendGrid_ApiKey.ToString());

                var client = new SendGridClient(apiKey);

                var sendGridMessage = new SendGridMessage();
                var sendGridMessageServer = new SendGridMessage();

                sendGridMessage.SetFrom(clientStaticEmail, $"Client : {mailRequest.Name}");
                sendGridMessage.AddTo(serverInfoMail, "Server Register Admin");
                sendGridMessage.SetTemplateId("d-a747e832df4241deb750de7c0e617299");
                sendGridMessage.SetTemplateData(modelSendGrid);

                sendGridMessageServer.SetFrom(serverInfoMail, $"Touch Academy : Server Admin");
                sendGridMessageServer.AddTo(mailRequest.FromEmail, $"Approver : {mailRequest.Name}");
                sendGridMessageServer.SetTemplateId("d-4673ce006f634ceb97a43a9bc0ed540f");
                sendGridMessageServer.SetTemplateData(modelSendGrid);

                var responseFromClient = client.SendEmailAsync(sendGridMessage).Result;
                var responseFromServer = client.SendEmailAsync(sendGridMessageServer).Result;

                if (!responseFromClient.IsSuccessStatusCode || !responseFromServer.IsSuccessStatusCode)
                    return new ErrorDataResult<bool>(false, false);

                result = new SuccessDataResult<bool>(true);
            }
            catch (Exception ex)
            {
                result = new ErrorDataResult<bool>(false, true, ex.Message);
            }
            
            return result;
        }

        [ValidationAspect(typeof(QuickRegisterMailModelValidator))]
        public IDataResult<bool> SendQuickRegisterMailFromClient(QuickRegisterMailRequestModel mailRequest)
        {
            IDataResult<bool> result;
            try
            {
                var modelSendGridFromClient = _mapper.Map<ClientStaticMailTemplate>(mailRequest);
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

                var clientStaticEmail = ConfigHelper.GetSettingsDataStatic<string>(
                    ParentKeySettings.GlobalAccessibility_ContainerKeyword.ToString(),
                    ChildKeySettings.Static_ClientEmailEquivalent.ToString());

                var apiKey = ConfigHelper.GetSettingsDataStatic<string>(
                    ParentKeySettings.EmailConfiguration.ToString(),
                    ChildKeySettings.Email_SendGrid_ApiKey.ToString());

                var client = new SendGridClient(apiKey);

                var sendGridMessageFromUser = new SendGridMessage();
                var sendGridMessageFromServer = new SendGridMessage();

                sendGridMessageFromUser.SetFrom(clientStaticEmail, "Client : No Name");
                sendGridMessageFromUser.AddTo(registerServerMail, "Server Quick Register");
                sendGridMessageFromUser.SetTemplateId("d-a747e832df4241deb750de7c0e617299");
                sendGridMessageFromUser.SetTemplateData(modelSendGridFromClient);

                sendGridMessageFromServer.SetFrom(registerServerMail, $"Touch Academy : Server Quick Register");
                sendGridMessageFromServer.AddTo(mailRequest.FromEmail, $"Approver : No Name");
                sendGridMessageFromServer.SetTemplateId("d-d3cd3b0621794d9aa5d7563a6b9f1ab2");
                sendGridMessageFromServer.SetTemplateData(modelSendGridFromServer);

                var responseFromUser = client.SendEmailAsync(sendGridMessageFromUser).Result;
                var responseFromServer = client.SendEmailAsync(sendGridMessageFromServer).Result;

                if (!responseFromUser.IsSuccessStatusCode || !responseFromServer.IsSuccessStatusCode)
                    return new ErrorDataResult<bool>(false, false);

                result = new SuccessDataResult<bool>(true);
            }
            catch (Exception ex)
            {
                result = new ErrorDataResult<bool>(true, ex.Message);
            }

            return result;
        }

        [ValidationAspect(typeof(RegisterMailRequestModelValidator))]
        public IDataResult<bool> SendRegisterMailFromClient(RegisterMailRequestModel mailRequest)
        {
            IDataResult<bool> result;
            try
            {
                var modelSendGridFromClient = _mapper.Map<ClientStaticMailTemplate>(mailRequest);
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

                var clientStaticEmail = ConfigHelper.GetSettingsDataStatic<string>(
                    ParentKeySettings.GlobalAccessibility_ContainerKeyword.ToString(),
                    ChildKeySettings.Static_ClientEmailEquivalent.ToString());

                var apiKey = ConfigHelper.GetSettingsDataStatic<string>(
                    ParentKeySettings.EmailConfiguration.ToString(),
                    ChildKeySettings.Email_SendGrid_ApiKey.ToString());

                var client = new SendGridClient(apiKey);

                var sendGridMessageFromUser = new SendGridMessage();
                var sendGridMessageFromServer = new SendGridMessage();

                sendGridMessageFromUser.SetFrom(clientStaticEmail, $"Client : {mailRequest.Name}");
                sendGridMessageFromUser.AddTo(registerServerMail, "Server Register");
                sendGridMessageFromUser.SetTemplateId("d-a747e832df4241deb750de7c0e617299");
                sendGridMessageFromUser.SetTemplateData(modelSendGridFromClient);

                sendGridMessageFromServer.SetFrom(registerServerMail, $"Touch Academy : Server Register");
                sendGridMessageFromServer.AddTo(mailRequest.FromEmail, $"Approver : {mailRequest.Name}");
                sendGridMessageFromServer.SetTemplateId("d-4673ce006f634ceb97a43a9bc0ed540f");
                sendGridMessageFromServer.SetTemplateData(modelSendGridFromServer);

                var responseFromUser = client.SendEmailAsync(sendGridMessageFromUser).Result;
                var responseFromServer = client.SendEmailAsync(sendGridMessageFromServer).Result;

                if (!responseFromUser.IsSuccessStatusCode || !responseFromServer.IsSuccessStatusCode)
                    return new ErrorDataResult<bool>();

                result = new SuccessDataResult<bool>(true);
            }
            catch (Exception ex)
            {
                result = new ErrorDataResult<bool>(true, ex.Message);
            }

            return result;
        }
    }
}