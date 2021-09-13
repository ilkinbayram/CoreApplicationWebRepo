using Autofac;
using System;

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
