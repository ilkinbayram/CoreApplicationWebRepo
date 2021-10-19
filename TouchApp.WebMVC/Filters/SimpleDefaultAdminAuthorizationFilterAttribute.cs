using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;

namespace TouchApp.WebMVC.Filters
{
    public class SimpleDefaultAdminAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var res = context.HttpContext.Request.Cookies["IsAdmin"];

            if (string.IsNullOrEmpty(res))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "SmpCred", action = "SetCred", area = "Global" }));
            }
        }
    }
}
