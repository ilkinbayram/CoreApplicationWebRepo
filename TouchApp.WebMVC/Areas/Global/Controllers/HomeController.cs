using AutoMapper;
using Business.ExternalServices.Mail.Services.Abstract;
using Core.CrossCuttingConcerns.Caching;
using Core.Extensions;
using Core.Resources.Enums;
using Core.Utilities.Helpers.Abstracts;
using Core.Utilities.Results;
using Core.Utilities.UsableModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.Business.BusinessHelper;
using TouchApp.Business.ExternalServices.Mail;
using TouchApp.Business.ExternalServices.Mail.ModelAcceptor;
using TouchApp.WebMVC.Areas.Global.Models.ViewModel;

namespace TouchApp.WebMVC.Areas.Global.Controllers
{
    [Area("Global")]
    public class HomeController : Controller
    {
        private readonly ICacheManager _cacheManager;
        private readonly ISessionStorageHelper _sessionStorageHelper;
        private readonly ILocalizationService _localizationService;
        private readonly IBlogService _blogService;
        private readonly ICourseService _courseService;
        private readonly ICourseServiceService _courseServiceService;
        private readonly IMediaService _mediaService;
        private readonly IPhraseService _phraseService;
        private readonly ISliderService _sliderService;
        private readonly ITeacherService _teacherService;
        private readonly ILanguageService _languageService;
        private readonly IConfigHelper _configHelper;
        private readonly ISendgridMailService _mailService;
        private readonly IMapper _mapper;

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
                              ISendgridMailService mailService,
                              IMapper mapper)
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
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> TouchIndex()
        {
            GeneralFunctionality.ConfigureLanguageLocalizationSetting(_sessionStorageHelper, _cacheManager, _configHelper, _languageService, _localizationService, ParentKeySettings.ServerCache_ContainerKeyword, ChildKeySettings.Server_Language_CachedForAll, 1440);

            _viewModel = new HomeViewModel
            {
                Blogs = _blogService.GetDtoList(takeCount: 100).Data,
                Courses = _courseService.GetDtoList().Data,
                CourseServices = _courseServiceService.GetDtoList().Data,
                Medias = _mediaService.GetDtoList().Data,
                Phrases = _phraseService.GetDtoList().Data,
                Sliders = _sliderService.GetDtoList().Data,
                Teachers = _teacherService.GetDtoList().Data
            };

            var cacheData = _cacheManager.Get("");

            return View(_viewModel);
        }

        [HttpPost("/Global/Home/SendMailAsync")]
        public async Task<PartialViewResult> SendMailAsync(MailRequest mailRequest)
        {
            var languageOid = _sessionStorageHelper.GetValue(_configHelper.GetSettingsData<string>(
                    ParentKeySettings.SessionCache_ContainerKeyword.ToString(),
                    ChildKeySettings.Session_Language_CurrentLangOid.ToString()));

            languageOid = string.IsNullOrEmpty(languageOid) ? "1" : languageOid;

            mailRequest.Lang_oid = Convert.ToByte(languageOid);

            IDataResult<bool> response = new ErrorDataResult<bool>();

            var notificationModel = new AlertResult();

            switch (mailRequest.MailType)
            {
                case (byte)MailType.Information_Email:
                    response = _mailService.SendInformationMailFromClient(_mapper.Map<InformationMailRequestModel>(mailRequest));
                    notificationModel.AlertMessages.Add("GeneralMailSuccessNotificationForMail.Localization".Translate());
                    break;
                case (byte)MailType.Register_email:
                    response = _mailService.SendRegisterMailFromClient(_mapper.Map<RegisterMailRequestModel>(mailRequest));
                    notificationModel.AlertMessages.Add("EmailSuccessNotificationGeneralRegister.Localization".Translate());
                    break;
                case (byte)MailType.Quick_Register:
                    response = _mailService.SendQuickRegisterMailFromClient(_mapper.Map<QuickRegisterMailRequestModel>(mailRequest));
                    notificationModel.AlertMessages.Add("EmailSuccessNotificationQuickRegister.Localization".Translate());
                    break;
            }

            if (!response.Success || response.IsProcessBroken)
            {
                notificationModel.Status = AlertStatus.Danger;
                notificationModel.AlertMessages = response.Responses.Select(x => x.Message).ToList();
            }
            else
            {
                notificationModel.Status = AlertStatus.Success;
            }
            
            return PartialView("_PartialNotificationAlert", notificationModel);
        }
    }
}
