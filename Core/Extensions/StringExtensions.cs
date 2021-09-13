using Core.CrossCuttingConcerns.Caching;
using Core.DependencyResolvers;
using Core.Entities.Concrete;
using Core.Utilities.Helpers.Abstracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

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
                if(!long.TryParse(initialArray[0], out long result))
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

        private static byte lang_oid
        {
            get
            {
                var _configHelper = CoreInstanceFactory.GetInstance<IConfigHelper>();
                
                HttpContextAccessor context = new HttpContextAccessor();
                var response = context.HttpContext.Request.Cookies[_configHelper.GetSettingsData<string>("cookie_lang_oid_keyword", "CookieFixedKeywords")];

                if (string.IsNullOrEmpty(response))
                {
                    response = context.HttpContext.Request.Cookies[_configHelper.GetSettingsData<string>("default_lang_oid", "CookieFixedKeywords")];
                    return Convert.ToByte(response);
                }

                return Convert.ToByte(response);
            }
        }

        public static string Translate(this string key)
        {
            var _cacheManager = CoreInstanceFactory.GetInstance<ICacheManager>();

            var unfilteredResponse = _cacheManager.Get<List<Localization>>(key);

            if (unfilteredResponse != null)
            {
                return unfilteredResponse.FirstOrDefault(x => x.Lang_oid == lang_oid).Translate;
            }

            return key;
        }
    }
}
