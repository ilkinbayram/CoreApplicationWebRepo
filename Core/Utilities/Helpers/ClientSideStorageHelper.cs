using Core.Resources.Enums;
using Core.Utilities.Helpers.Abstracts;
using Microsoft.AspNetCore.Http;
using System;

namespace Core.Utilities.Helpers
{
    public class ClientSideStorageHelper : ISessionStorageHelper
    {
        private IHttpContextAccessor _httpContextAccessor;
        private static IHttpContextAccessor _httpContextAccessorStatic = new HttpContextAccessor();
        private IConfigHelper _configHelper;
        public ClientSideStorageHelper(IHttpContextAccessor httpContextAccessor,
                                       IConfigHelper configHelper)
        {
            _httpContextAccessor = httpContextAccessor;
            _configHelper = configHelper;
        }

        public void Remove(string key)
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
            var currentSameKeyValue = GetValue(key);

            if (!string.IsNullOrEmpty(currentSameKeyValue))
                Remove(key);

            CookieOptions option = new CookieOptions();

            option.Expires = DateTime.Now.AddMinutes(expirationMinute);

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value,option);
        }

        public void SetSessionLangIfNotExist()
        {
            var settingKeyParameterLangOid = _configHelper.GetSettingsData<string>(ParentKeySettings.SessionCache_ContainerKeyword.ToString(), ChildKeySettings.Session_Language_CurrentLangOid.ToString());
            var settledLangOid = GetValue(settingKeyParameterLangOid);
            if (settledLangOid == null || string.IsNullOrEmpty(settledLangOid))
            {
                var defaultValue = _configHelper.GetSettingsData<string>(ParentKeySettings.SessionCache_ContainerKeyword.ToString(), ChildKeySettings.Session_Language_CurrentLangOid.ToString());
                Set(settingKeyParameterLangOid, defaultValue, 1440);
            }
        }


        public static void RemoveStatic(string key)
        {
            _httpContextAccessorStatic.HttpContext.Response.Cookies.Delete(key);
        }

        public static string GetValueStatic(string key)
        {
            string cookieValueFromContext = _httpContextAccessorStatic.HttpContext.Request.Cookies[key];

            return cookieValueFromContext;
        }

        public static string GetLangOidStatic()
        {
            var currentLangOidKey = ConfigHelper.GetSettingsDataStatic<string>(
                                         ParentKeySettings.SessionCache_ContainerKeyword.ToString(),
                                         ChildKeySettings.Session_Language_CurrentLangOid.ToString()
                                         );
            string cookieValueFromContext = _httpContextAccessorStatic.HttpContext.
                                            Request.Cookies[currentLangOidKey];

            if (string.IsNullOrEmpty(cookieValueFromContext))
                cookieValueFromContext = ConfigHelper.GetSettingsDataStatic<string>(
                                         ParentKeySettings.SessionCache_ContainerKeyword.ToString(),
                                         ChildKeySettings.Session_Language_DefaultLangOid.ToString()
                                         );

            return cookieValueFromContext;
        }


        public static void SetStatic(string key, string value, int expirationMinute = 15)
        {
            var currentSameKeyValue = GetValueStatic(key);

            if (!string.IsNullOrEmpty(currentSameKeyValue))
                RemoveStatic(key);

            CookieOptions option = new CookieOptions();

            option.Expires = DateTime.Now.AddMinutes(expirationMinute);

            _httpContextAccessorStatic.HttpContext.Response.Cookies.Append(key, value, option);
        }

        public static void SetSessionLangIfNotExistStatic()
        {
            var settingKeyParameterLangOid = ConfigHelper.GetSettingsDataStatic<string>(ParentKeySettings.SessionCache_ContainerKeyword.ToString(), ChildKeySettings.Session_Language_CurrentLangOid.ToString());
            var settledLangOid = GetValueStatic(settingKeyParameterLangOid);
            if (settledLangOid == null || string.IsNullOrEmpty(settledLangOid))
            {
                var defaultValue = ConfigHelper.GetSettingsDataStatic<string>(ParentKeySettings.SessionCache_ContainerKeyword.ToString(), ChildKeySettings.Session_Language_CurrentLangOid.ToString());
                SetStatic(settingKeyParameterLangOid, defaultValue, 1440);
            }
        }
    }
}
