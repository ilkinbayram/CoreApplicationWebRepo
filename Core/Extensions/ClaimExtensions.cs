using Core.Resources.Custom;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email,email));
        }

        public static void AddFirstName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddFullName(this ICollection<Claim> claims, string fullName)
        {
            claims.Add(new Claim(CustomClaims.FullName, fullName));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role=>claims.Add(new Claim(ClaimTypes.Role, role)));
        }

        public static void AddLastName(this ICollection<Claim> claims, string surname)
        {
            claims.Add(new Claim(ClaimTypes.Surname, surname));
        }

        public static void AddUserId(this ICollection<Claim> claims, long userId)
        {
            claims.Add(new Claim(CustomClaims.UserId, userId.ToString()));
        }
    }
}
