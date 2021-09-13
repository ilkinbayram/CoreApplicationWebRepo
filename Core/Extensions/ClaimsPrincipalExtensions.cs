using Core.Resources.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }

        public static long GetUserId(this ClaimsPrincipal principal)
        {
            var claims = principal.Claims;
            var claimIdResult = claims.SingleOrDefault(c => c.Type == CustomClaims.UserId);

            return claimIdResult == null ? default(long) : Convert.ToInt64(claimIdResult.Value);
        }

        public static string GetFirstName(this ClaimsPrincipal principal)
        {
            var claims = principal.Claims;
            var claimFirstNameResult = claims.SingleOrDefault(claim => claim.Type == ClaimTypes.Name);

            return claimFirstNameResult?.Value;
        }

        public static string GetFullName(this ClaimsPrincipal principal)
        {
            var claims = principal.Claims;
            var claimFullNameResult = claims.SingleOrDefault(claim => claim.Type == CustomClaims.FullName);

            return claimFullNameResult?.Value;
        }

        public static string GetEmail(this ClaimsPrincipal principal)
        {
            var claims = principal.Claims;
            var claimEmailResult = claims.SingleOrDefault(claim => claim.Type == ClaimTypes.Email);

            return claimEmailResult?.Value;
        }

        public static string GetLastName(this ClaimsPrincipal principal)
        {
            var claims = principal.Claims;
            var claimSurnameResult = claims.SingleOrDefault(claim => claim.Type == ClaimTypes.Surname);

            return claimSurnameResult?.Value;
        }
    }

}
