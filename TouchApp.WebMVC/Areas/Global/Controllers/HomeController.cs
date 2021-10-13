﻿using Business.ExternalServices.Mail.Services.Abstract;
using Core.CrossCuttingConcerns.Caching;
using Core.Extensions;
using Core.Resources.Enums;
using Core.Utilities.Helpers.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.Business.BusinessHelper;
using TouchApp.Business.ExternalServices.Mail;
using TouchApp.WebMVC.Areas.Global.Models.ViewModel;

namespace TouchApp.WebMVC.Areas.Global.Controllers
{
    [Area("Global")]
    public class HomeController : Controller
    {
        private ICacheManager _cacheManager;
        private ISessionStorageHelper _sessionStorageHelper;
        private ILocalizationService _localizationService;
        private IBlogService _blogService;
        private ICourseService _courseService;
        private ICourseServiceService _courseServiceService;
        private IMediaService _mediaService;
        private IPhraseService _phraseService;
        private ISliderService _sliderService;
        private ITeacherService _teacherService;
        private ILanguageService _languageService;
        private IConfigHelper _configHelper;
        private ISendgridMailService _mailService;

        private HomeViewModel _viewModel;
        public HomeController(ICacheManager cacheManager, 
                              ILocalizationService localizationService, 
                              IConfigHelper configHelper,
                              ISessionStorageHelper sessionStorageHelper,
                              ILanguageService languageService,
                              ICourseService courseService,
                              IBlogService blogService,
                              ICourseServiceService courseServiceService,
                              IMediaService mediaService,
                              IPhraseService phraseService,
                              ISliderService sliderService,
                              ITeacherService teacherService,
                              ISendgridMailService mailService)
        {
            _cacheManager = cacheManager;
            _localizationService = localizationService;
            _mediaService = mediaService;
            _courseService = courseService;
            _blogService = blogService;
            _configHelper = configHelper;
            _sessionStorageHelper = sessionStorageHelper;
            _languageService = languageService;
            _courseServiceService = courseServiceService;
            _phraseService = phraseService;
            _sliderService = sliderService;
            _teacherService = teacherService;
            _mailService = mailService;
        }

        [HttpGet]
        public async Task<IActionResult> TouchIndex()
        {
            GeneralFunctionality.ConfigureLanguageLocalizationSetting(_sessionStorageHelper, _cacheManager, _configHelper, _languageService, _localizationService, ParentKeySettings.ServerCache_ContainerKeyword, ChildKeySettings.Server_Language_CachedForAll, 1440);

            _viewModel = new HomeViewModel 
            { 
                Blogs = (await _blogService.GetDtoListAsync(takeCount:100)).Data, 
                Courses = (await _courseService.GetDtoListAsync()).Data, 
                CourseServices = (await _courseServiceService.GetDtoListAsync()).Data, 
                Medias = (await _mediaService.GetDtoListAsync()).Data, 
                Phrases = (await _phraseService.GetDtoListAsync()).Data, 
                Sliders = (await _sliderService.GetDtoListAsync()).Data, 
                Teachers = (await _teacherService.GetDtoListAsync()).Data
            };

            var cacheData = _cacheManager.Get("");

            return View(_viewModel);
        }

        [HttpPost("/Global/Home/SendMailAsync")]
        public async Task<string> SendMailAsync(MailRequest mailRequest)
        {
            var successMessage = string.Empty;

            var languageOid = _sessionStorageHelper.GetValue(_configHelper.GetSettingsData<string>(
                    ParentKeySettings.SessionCache_ContainerKeyword.ToString(),
                    ChildKeySettings.Session_Language_CurrentLangOid.ToString()));

            languageOid = string.IsNullOrEmpty(languageOid) ? "1" : languageOid;

            mailRequest.Lang_oid = Convert.ToByte(languageOid);

            bool responseIsTrueClient = false;
            bool responseIsTrueServer = false;

            switch (mailRequest.MailType)
            {
                case (byte)MailType.Information_Email:
                    responseIsTrueClient = responseIsTrueServer = await _mailService.SendMailFromClientAsync(mailRequest);
                    successMessage = "GeneralMailSuccessNotificationForMail.Localization".Translate();
                    break;
                case (byte)MailType.Register_email:
                    responseIsTrueClient = _mailService.SendRegisterFromClientMail(mailRequest);
                    responseIsTrueServer = _mailService.SendRegisterFromServerMail(mailRequest);
                    successMessage = "EmailSuccessNotificationGeneralRegister.Localization".Translate();
                    break;
                case (byte)MailType.Quick_Register:
                    responseIsTrueClient = _mailService.SendQuickRequestFromClientMail(mailRequest);
                    responseIsTrueServer = _mailService.SendQuickRequestFromServerMail(mailRequest);
                    successMessage = "EmailSuccessNotificationQuickRegister.Localization".Translate();
                    break;
                default:
                    break;
            }

            if (responseIsTrueClient && responseIsTrueServer)
                return successMessage;

            return "EmailFailedNotification.GeneralLocalization".Translate();
        }
    }
}
