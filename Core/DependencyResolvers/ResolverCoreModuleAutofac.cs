using Autofac;
using Autofac.Core;
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

namespace Core.DependencyResolvers
{
    public class ResolverCoreModuleAutofac : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ICacheManager>().As<MemoryCacheManager>();
            //builder.RegisterType<IHttpContextAccessor>().As<HttpContextAccessor>();
            //builder.RegisterType<ISessionStorageHelper>().As<ClientSideStorageHelper>();
            builder.RegisterType<IConfigHelper>().As<ConfigHelper>();
        }
    }
}
