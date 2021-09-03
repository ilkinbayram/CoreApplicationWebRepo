using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Filters
{
    public class AdminAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string currentUserRole = Convert.ToString(context.HttpContext.Session.GetString("UserRole"));

            if (!string.IsNullOrEmpty(currentUserRole))
            {
                if (currentUserRole != "Admin")
                {
                    context.Result = new RedirectToRouteResult
                (
                new RouteValueDictionary(new
                {
                    action = "Error",
                    controller = "Error"
                }));

                }
                else
                {
                    context.Result = new RedirectToRouteResult
               (
               new RouteValueDictionary(new
               {
                   action = "Error",
                   controller = "Error"
               }));

                }
            }
            else
            {
                context.Result = new RedirectToRouteResult
                (
                new RouteValueDictionary(new
                {
                    action = "Error",
                    controller = "Error"
                }));

            }
        }
    }
}