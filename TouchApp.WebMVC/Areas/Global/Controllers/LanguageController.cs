using Core.CrossCuttingConcerns.Caching;
using Core.Resources.Enums;
using Core.Utilities.Helpers.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.WebMVC.Filters;

namespace TouchApp.WebMVC.Areas.Global.Controllers
{
    [Area("Global")]
    [LocalizationFilter]
    public class LanguageController : Controller
    {

        private ICacheManager _cacheManager;
        private ISessionStorageHelper _sessionStorageHelper;
        private IConfigHelper _configHelper;
        private ILanguageService _languageService;
        private ILocalizationService _localizationService;
        public LanguageController(ICacheManager cacheManager,
                              IConfigHelper configHelper,
                              ISessionStorageHelper sessionStorageHelper,
                              ILanguageService languageService,
                              ILocalizationService localizationService)
        {
            _cacheManager = cacheManager;
            _configHelper = configHelper;
            _sessionStorageHelper = sessionStorageHelper;
            _languageService = languageService;
            _localizationService = localizationService;
        }


        // POST: LanguageController/Edit/id
        [HttpPost]
        public async Task<IActionResult> SetLanguage(int langOid, string areaName, string controllerName, string actionName)
        {
            try
            {
                string key = _configHelper.GetSettingsData<string>(ParentKeySettings.SessionCache_ContainerKeyword.ToString(), ChildKeySettings.Session_Language_CurrentLangOid.ToString());

                string cacheKey = _configHelper.GetSettingsData<string>(ParentKeySettings.ServerCache_ContainerKeyword.ToString(), ChildKeySettings.Server_Language_CachedForAll.ToString());

                _sessionStorageHelper.Set(key, langOid.ToString(), 1440);

                var data = _cacheManager.Get<Dictionary<short, Dictionary<string,string>>>(cacheKey);

                return RedirectToAction(actionName, controllerName, new { area = areaName });
            }
            catch
            {
                return View();
            }
        }
    }
}
