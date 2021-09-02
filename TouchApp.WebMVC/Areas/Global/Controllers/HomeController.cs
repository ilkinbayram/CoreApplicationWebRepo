using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Helpers.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.Business.BusinessHelper;
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
                              ITeacherService teacherService)
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
        }

        [HttpGet]
        public async Task<IActionResult> TouchIndex()
        {
            GeneralFunctionality.ConfigureLanguageLocalizationSetting(_sessionStorageHelper, _cacheManager, _configHelper, _localizationService, "staticLanguageCache", "ServerCache", 1440);

            _viewModel = new HomeViewModel 
            { 
                Blogs = (await _blogService.GetDtoListAsync(takeCount:6)).Data, 
                Courses = (await _courseService.GetDtoListAsync()).Data, 
                CourseServices = (await _courseServiceService.GetDtoListAsync()).Data, 
                Medias = (await _mediaService.GetDtoListAsync()).Data, 
                Phrases = (await _phraseService.GetDtoListAsync()).Data, 
                Sliders = (await _sliderService.GetDtoListAsync()).Data, 
                Teachers = (await _teacherService.GetDtoListAsync()).Data
            };

            return View(_viewModel);
        }
    }
}
