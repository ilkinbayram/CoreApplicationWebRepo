﻿using Core.CrossCuttingConcerns.Caching;
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
        private ICacheManager _cacheManager;
        private ISessionStorageHelper _sessionStorageHelper;
        private ILocalizationService _localizationService;
        private ILanguageService _languageService;
        private IConfigHelper _configHelper;
        public HomeController(ICacheManager cacheManager, 
                              ILocalizationService localizationService, 
                              IConfigHelper configHelper,
                              ISessionStorageHelper sessionStorageHelper,
                              ILanguageService languageService)
        {
            _cacheManager = cacheManager;
            _localizationService = localizationService;
            _configHelper = configHelper;
            _sessionStorageHelper = sessionStorageHelper;
            _languageService = languageService;
        }

        [HttpGet]
        public IActionResult TouchIndex()
        {
            _sessionStorageHelper.SetSessionLangIfNotExist();

            if (_cacheManager.Get(_configHelper.GetSettingsData<string>("staticLanguageCache", "ServerCache")) ==null)
            {
                var cachableLocalizationList = _localizationService.GetList();
                _cacheManager.Add(_configHelper.GetSettingsData<string>("staticLanguageCache", "ServerCache"), cachableLocalizationList.Data, 1440);
            }



            return View();
        }
    }
}