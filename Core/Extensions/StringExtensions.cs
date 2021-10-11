using Core.CrossCuttingConcerns.Caching;
using Core.DependencyResolvers;
using Core.Entities.Concrete;
using Core.Resources.Enums;
using Core.Utilities.Helpers;
using Core.Utilities.Helpers.Abstracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class StringExtensions
    {
        public static long[] ToFeatureIdArray(this string featureIdsJoined)
        {
            List<long> resultList = new List<long>();
            long[] emptyResult = new long[0];

            if (featureIdsJoined == default)
                return default;

            var initialArray = featureIdsJoined.Split(',');


            if (initialArray.Length == 1)
            {
                if (!long.TryParse(initialArray[0], out long result))
                    return emptyResult;

                resultList.Add(result);
                return resultList.ToArray();
            }

            foreach (var idStr in initialArray)
            {
                if (!long.TryParse(idStr, out long result))
                    return emptyResult;

                resultList.Add(result);
            }

            return resultList.ToArray();
        }

        public static string Translate(this string key)
        {
            try
            {
                var _cacheManager = CoreInstanceFactory.GetInstance<ICacheManager>();

                // TODO : Hard Code Should Be Refactored

                var serverLocalizationKey = ConfigHelper.GetSettingsDataStatic<string>(ParentKeySettings.ServerCache_ContainerKeyword.ToString(), ChildKeySettings.Server_Language_CachedForAll.ToString());

                var currentLangOid = Convert.ToInt16(ClientSideStorageHelper.GetLangOidStatic());

                var allResponse = _cacheManager.Get<Dictionary<short, Dictionary<string, string>>>(serverLocalizationKey);

                if (allResponse != null)
                {
                    return allResponse.ContainsKey(currentLangOid) && allResponse[currentLangOid].ContainsKey(key) 
                        ? allResponse[currentLangOid][key] 
                        : key;
                }

                return key;
            }
            catch (Exception ex)
            {
                return key;
            }
        }

        public static string Translate(this string key, short lang_oid)
        {
            try
            {
                var _cacheManager = CoreInstanceFactory.GetInstance<ICacheManager>();

                var serverLocalizationKey = ConfigHelper.GetSettingsDataStatic<string>(ParentKeySettings.ServerCache_ContainerKeyword.ToString(), ChildKeySettings.Server_Language_CachedForAll.ToString());

                var allResponse = _cacheManager.Get<Dictionary<short, Dictionary<string, string>>>(serverLocalizationKey);

                if (allResponse != null)
                {
                    return allResponse.ContainsKey(lang_oid) && allResponse[lang_oid].ContainsKey(key)
                        ? allResponse[lang_oid][key]
                        : key;
                }

                return key;
            }
            catch (Exception ex)
            {
                return key;
            }
        }

        public static string GetStaticMediaURL(this string configKey)
        {
            var resultRead = ConfigHelper.GetSettingsDataStatic<string>(ParentKeySettings.MediaServiceURL_ContainerKeyword.ToString(), configKey);

            return resultRead;
        }
    }
}
