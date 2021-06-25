using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class SecurityChecker
    {
        /// <summary>
        /// Expiration DateTime For Token Have To Merge The End Of Guid When it was generated
        /// </summary>
        /// <param name="token"></param>
        /// <param name="expirationMinute"></param>
        /// <returns></returns>
        public static bool CompareTokenExpiration(string token, int expirationMinute)
        {
            //string tokenDate = token.Substring(token.Length - 14, 14);
            //string tokenDay = tokenDate.Substring(2, 2);
            //string tokenMonth = tokenDate.Substring(0,2);
            //string tokenYear = tokenDate.Substring(4,4);
            //string tokenSecondPartFirst = tokenDate.Substring(8,2);
            //string tokenSecondPartSecond = tokenDate.Substring(10,2);
            //string tokenSecondPartThird = tokenDate.Substring(12,2);
            //string resultTokenDate = $"{tokenDay}.{tokenMonth}.{tokenYear} {tokenSecondPartFirst}:{tokenSecondPartSecond}:{tokenSecondPartThird}";
            //DateTime compareableTokenDate = Convert.ToDateTime(resultTokenDate);
            //return DateTime.Now.AddMinutes(-1 * expirationMinute) < compareableTokenDate;

            return true;
        }
    }
}
