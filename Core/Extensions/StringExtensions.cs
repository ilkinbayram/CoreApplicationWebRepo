using Core.CrossCuttingConcerns.Caching;
using Core.DependencyResolvers;
using Core.Entities.Concrete;
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

        public static string Translate(this string key, byte lang_oid)
        {
            var _cacheManager = CoreInstanceFactory.GetInstance<ICacheManager>();

            var result = _cacheManager.Get<List<Localization>>(key);

            return result.FirstOrDefault(x => x.Lang_oid == lang_oid).Translate;
        }
    }
}
