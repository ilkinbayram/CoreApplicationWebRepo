using Autofac;
using Microsoft.AspNetCore.Http;

using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.Helpers;
using Core.Utilities.Helpers.Abstracts;




namespace Core.DependencyResolvers
{
    public class ResolverCoreModuleAutofac : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
            builder.RegisterType<ClientSideStorageHelper>().As<ISessionStorageHelper>();
            builder.RegisterType<ConfigHelper>().As<IConfigHelper>();
        }
    }
}
