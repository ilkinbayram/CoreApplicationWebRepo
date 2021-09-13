using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Helpers.Abstracts;
using TouchApp.Business.Abstract;

namespace TouchApp.Business.BusinessHelper
{
    public static class GeneralFunctionality
    {
        public static void ConfigureLanguageLocalizationSetting(ISessionStorageHelper sessionStorageHelper,
                                                                ICacheManager         cacheManager,
                                                                IConfigHelper         configHelper,
                                                                ILocalizationService  localizationService,
                                                                string                configSettingKey,
                                                                string                configSettingParentProvider,
                                                                int                   expirationMinutes = 60)
        {
            sessionStorageHelper.SetSessionLangIfNotExist();

            if (cacheManager.Get(configHelper.GetSettingsData<string>(configSettingKey, configSettingParentProvider)) == null)
            {
                var cachableLocalizationList = localizationService.GetList();
                cacheManager.Add(configHelper.GetSettingsData<string>(configSettingKey, configSettingParentProvider), cachableLocalizationList.Data, expirationMinutes);
            }
        }
    }
}
