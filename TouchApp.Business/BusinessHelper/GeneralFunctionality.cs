using Core.CrossCuttingConcerns.Caching;
using Core.Entities.Concrete;
using Core.Entities.Concrete.Base;
using Core.Entities.Dtos.Base;
using Core.Resources.Enums;
using Core.Utilities.Helpers.Abstracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using TouchApp.Business.Abstract;

namespace TouchApp.Business.BusinessHelper
{
    public static class GeneralFunctionality
    {
        public static void ConfigureLanguageLocalizationSetting(ISessionStorageHelper sessionStorageHelper,
                                                                ICacheManager cacheManager,
                                                                IConfigHelper configHelper,
                                                                ILanguageService languageService,
                                                                ILocalizationService localizationService,
                                                                ParentKeySettings parentKey,
                                                                ChildKeySettings childKey,
                                                                int expirationMinutes = 60)
        {
            sessionStorageHelper.SetSessionLangIfNotExist();

            var settingCacheKey = configHelper.GetSettingsData<string>(parentKey.ToString(), childKey.ToString());

            var checkCacheForLang = (Dictionary<short, Dictionary<string, string>>)cacheManager.Get(settingCacheKey);

            if (checkCacheForLang == null)
            {
                Dictionary<short, Dictionary<string,string>> dictionaryLang = new Dictionary<short, Dictionary<string, string>>();

                languageService.GetList().Data.Select(x => x.Language_oid).ToList().ForEach(x =>
                {
                    var dictionaryKeyValue = new Dictionary<string, string>();
                    localizationService.GetList(p=>p.Lang_oid==x).Data.ForEach(m =>
                    {
                        dictionaryKeyValue.Add(m.Key, m.Translate);
                    });
                    dictionaryLang.Add(x, dictionaryKeyValue);
                });

                cacheManager.Add(settingCacheKey, dictionaryLang, expirationMinutes);
            }
        }

        public static BaseEntity InitializeBaseFields(BaseEntity model, bool IsActive = true, string currentSystemUser = "System")
        {
            model.Created_at = model.Created_at == null
                               ? DateTime.Now
                               : model.Created_at;

            model.Modified_at = model.Modified_at == null ||
                                model.Modified_at.Value < DateTime.Now.Date
                                ? DateTime.Now
                                : model.Modified_at.Value;

            model.Created_by = string.IsNullOrEmpty(model.Created_by)
                               ? currentSystemUser
                               : model.Created_by;

            model.Modified_by = string.IsNullOrEmpty(model.Modified_by)
                               ? currentSystemUser
                               : model.Modified_by;

            return model;
        }

        public static List<Localization> ConverModelToLocalizationList(BaseDto model, short projectOid = 1)
        {
            var localizationList = new List<Localization>();
            var keyPropertyNames = model.GetType().GetProperties().ToList()
                .Select(x => x.Name).Where(x => x.ToLower().Contains("key")).ToList();

            var langDictionaries = new Dictionary<string, short>();

            Enum.GetValues<LanguageOidContainerEnum>().Cast<short>().ToList().ForEach(x =>
            {
                langDictionaries.Add(Enum.GetName(typeof(LanguageOidContainerEnum), x), x);
            });
           

            foreach (var keyOne in keyPropertyNames)
            {
                string parentKeyValue = model.GetType().GetProperty(keyOne).GetValue(model, null).ToString();

                var currentTranslateProperties = model.GetType().GetProperties().ToList()
                .Select(x => x.Name).Where(x => x.ToLower().Contains(keyOne.ToLower().Replace("key", string.Empty) + "translate")).ToList();

                foreach (var translateOne in currentTranslateProperties)
                {
                    var listModelOne = new Localization();

                    listModelOne = InitializeBaseFields(listModelOne) as Localization;

                    listModelOne.Key = parentKeyValue;

                    listModelOne.Translate = model.GetType().GetProperty(translateOne).GetValue(model, null).ToString();
                    listModelOne.Lang_oid = langDictionaries[
                                            translateOne.Substring(translateOne.IndexOf("Translate"),
                                            (translateOne.Length - translateOne.IndexOf("Translate")))
                                            .Replace("Translate", string.Empty)];
                    listModelOne.Project_oid = projectOid;

                    localizationList.Add(listModelOne);
                }
            }

            return localizationList;
        }
    }
}
