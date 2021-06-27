using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public static class CoreInstanceFactory
    {
        public static T GetInstance<T>()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ResolverCoreModuleAutofac());

            var result = builder.Build().Resolve<T>();

            return result;
        }
    }
}
