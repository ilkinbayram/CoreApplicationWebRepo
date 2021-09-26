using Core.CrossCuttingConcerns.Caching;
using Core.DependencyResolvers;
using Core.Resources.Enums;
using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Filters
{
    public class LocalizationFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                var cacheManager = CoreInstanceFactory.GetInstance<ICacheManager>();

                var configKey = Startup.StaticConfiguration
                    .GetSection(ParentKeySettings.ServerCache_ContainerKeyword.ToString())[ChildKeySettings.Server_Language_CachedForAll.ToString()];

                var localizationCache = cacheManager.Get<Dictionary<short, Dictionary<string, string>>>(configKey);

                if (localizationCache == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "TouchIndex", area = "Global" }));
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
