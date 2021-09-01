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
    public class LanguageController : Controller
    {

        private ICacheManager _cacheManager;
        private ISessionStorageHelper _sessionStorageHelper;
        private IConfigHelper _configHelper;
        private ILanguageService _languageService;
        public LanguageController(ICacheManager cacheManager,
                              IConfigHelper configHelper,
                              ISessionStorageHelper sessionStorageHelper,
                              ILanguageService languageService)
        {
            _cacheManager = cacheManager;
            _configHelper = configHelper;
            _sessionStorageHelper = sessionStorageHelper;
            _languageService = languageService;
        }


        // POST: LanguageController/Edit/id
        [HttpPost]
        public async Task<IActionResult> SetLanguage(int id, string controllerName, string actionName)
        {
            try
            {
                string key = _configHelper.GetSettingsData<string>("cookie_lang_oid_keyword", "CookieFixedKeywords");
                _sessionStorageHelper.Set(key, id.ToString(), 1440);

                return RedirectToAction(actionName, controllerName);
            }
            catch
            {
                return View();
            }
        }
    }
}
