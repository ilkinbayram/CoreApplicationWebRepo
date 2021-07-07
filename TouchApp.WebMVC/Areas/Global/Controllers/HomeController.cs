using Core.CrossCuttingConcerns.Caching;
using Core.Extensions;
using Core.Utilities.Helpers.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;

namespace TouchApp.WebMVC.Areas.Global.Controllers
{
    [Area("Global")]
    public class HomeController : Controller
    {
        public ICacheManager _cacheManager { get; set; }
        public ILocalizationService _localizationService { get; set; }
        public IConfigHelper _configHelper { get; set; }
        public HomeController(ICacheManager cacheManager, 
                              ILocalizationService localizationService, 
                              IConfigHelper configHelper)
        {
            _cacheManager = cacheManager;
            _localizationService = localizationService;
            _configHelper = configHelper;
        }

        [HttpGet]
        public IActionResult TouchIndex()
        {
            if (_cacheManager.Get(_configHelper.GetSettingsData<string>("staticLanguageCache", "ServerCache")) ==null)
            {
                var cachableLocalizationList = _localizationService.GetList();
                _cacheManager.Add(_configHelper.GetSettingsData<string>("staticLanguageCache", "ServerCache"), cachableLocalizationList.Data, 1440);
            }

            return View();
        }



        #region OpenToGlobal
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Gallery()
        {
            return View();
        }

        [HttpGet]
        public IActionResult StudyPackage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TeachersInfo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BlogDetails()
        {
            return View();
        }
        #endregion
    }
}
