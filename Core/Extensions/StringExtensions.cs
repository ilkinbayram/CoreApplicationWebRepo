using Core.CrossCuttingConcerns.Caching;
using Core.DependencyResolvers;
using Core.Entities.Concrete;
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

        private static byte lang_oid
        {
            get
            {
                try
                {
                    // TODO : Hard Code Should Be Refactored

                    HttpContextAccessor context = new HttpContextAccessor();
                    var response = context.HttpContext.Request.Cookies["language_oid_static_keyword_session"];

                    if (string.IsNullOrEmpty(response))
                    {
                        response = context.HttpContext.Request.Cookies["1"];
                        return Convert.ToByte(response);
                    }

                    return Convert.ToByte(response);
                }
                catch (Exception ex)
                {
                    return 1;
                }
            }
        }

        public static string Translate(this string key)
        {
            try
            {
                var _cacheManager = CoreInstanceFactory.GetInstance<ICacheManager>();

                // TODO : Hard Code Should Be Refactored

                var allResponse = _cacheManager.Get<Dictionary<string, string>>("language_oid_static_keyword_servercache");
                if (allResponse != null)
                {
                    return allResponse.ContainsKey(key) ? allResponse[key] : key;
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
            var resultRead = ConfigHelper.GetSettingsDataStatic<string>(configKey, "StaticMediaURL");

            return resultRead;
        }
    }
}
