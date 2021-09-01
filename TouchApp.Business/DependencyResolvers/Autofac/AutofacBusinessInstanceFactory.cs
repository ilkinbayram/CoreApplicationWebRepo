using Autofac;
using Business.Concrete;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.Helpers;
using Core.Utilities.Helpers.Abstracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;

namespace TouchApp.Business.DependencyResolvers.Autofac
{
    public static class AutoFacBusinessInstanceFactory
    {
        public static T GetInstance<T>()
        {
            try
            {
                ContainerBuilder builder = new ContainerBuilder();

                builder.RegisterModule<AutofacBusinessModule>();

                using (var container = builder.Build())
                using (var scope = container.BeginLifetimeScope())
                {
                    var finalFactory = scope.Resolve<T>();
                    return finalFactory;
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            
        }
    }
}
