using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class StringGenerator
    {
        public static string GenerateToken()
        {
            string result = Guid.NewGuid().ToString().Replace("-", string.Empty);
            return result;
        }
        public static string GenerateExpirableToken()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).ToUpper();
            var dtToString = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            string date = dtToString.Replace(".", string.Empty).Replace("/", string.Empty).Replace("-", string.Empty).Replace(":", string.Empty).Replace(" ", string.Empty);
            string result = guid + date;
            return result;
        }

        public static string GetFileIdFromUrlSource(string urlSource)
        {
            var arrayReverse = urlSource.Split("/").ToArray().Reverse().ToList();

            return arrayReverse[0];
        }
    }
}
