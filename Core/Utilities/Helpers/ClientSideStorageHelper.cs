using Core.Utilities.Helpers.Abstracts;
using Microsoft.AspNetCore.Http;
using System;

namespace Core.Utilities.Helpers
{
    public class ClientSideStorageHelper : ISessionStorageHelper
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IConfigHelper _configHelper;
        public ClientSideStorageHelper(IHttpContextAccessor httpContextAccessor,
                                       IConfigHelper configHelper)
        {
            _httpContextAccessor = httpContextAccessor;
            _configHelper = configHelper;
        }

        public void Remove(string key, string value)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }

        public string GetValue(string key)
        {
            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies[key];

            return cookieValueFromContext;
        }

        public void Set(string key, string value, int expirationMinute = 15)
        {
            CookieOptions option = new CookieOptions();

            option.Expires = DateTime.Now.AddMinutes(expirationMinute);

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value,option);
        }

        public void SetSessionLangIfNotExist()
        {
            var settingKeyParameterLangOid = _configHelper.GetSettingsData<string>("cookie_lang_oid_keyword", "CookieFixedKeywords");
            var settledLangOid = GetValue(settingKeyParameterLangOid);
            if (settledLangOid == null || string.IsNullOrEmpty(settledLangOid))
            {
                var defaultValue = _configHelper.GetSettingsData<string>("default_lang_oid", "CookieFixedKeywords");
                Set(settingKeyParameterLangOid, defaultValue, 1440);
            }
        }
    }
}
