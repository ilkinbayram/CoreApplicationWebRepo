using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Helpers.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;

namespace TouchApp.WebMVC.Areas.Global.Controllers
{
    [Area("Global")]
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
                string key = _configHelper.GetSettingsData<string>("cookie_lang_oid_keyword", "CookieFixedKeywords");

                if (_sessionStorageHelper.GetValue(key) != langOid.ToString())
                {
                    var cacheKey = _configHelper.GetSettingsData<string>("staticLanguageCache", "ServerCache");
                    _cacheManager.Remove(cacheKey);

                    Dictionary<string, string> dictionaryLang = new Dictionary<string, string>();
                    HttpContextAccessor context = new HttpContextAccessor();
                    _localizationService.GetList(x => x.Lang_oid == langOid).Data.ForEach(x =>
                    {
                        dictionaryLang.Add(x.Key, x.Translate);
                    });

                    _cacheManager.Add(cacheKey, dictionaryLang, 1440);
                }

                _sessionStorageHelper.Set(key, langOid.ToString(), 1440);

                return RedirectToAction(actionName, controllerName, new { area = areaName });
            }
            catch
            {
                return View();
            }
        }
    }
}
