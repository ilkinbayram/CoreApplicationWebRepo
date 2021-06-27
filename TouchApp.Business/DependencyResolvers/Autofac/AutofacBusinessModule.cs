using Autofac;
using Autofac.Extras.DynamicProxy;
using TouchApp.Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Helpers;
using Core.Utilities.Helpers.Abstracts;
using Business.ExternalServices.Mail.Services;
using Business.ExternalServices.Mail.Services.Abstract;
using Core.Utilities.Services.Rest;
using Business.ExternalServices.Cloudinarys;
using Business.Libs;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();

            builder.RegisterType<HomeMetaTagGalleryManager>().As<IHomeMetaTagGalleryService>();

            builder.RegisterType<HomeMetaTagManager>().As<IHomeMetaTagService>();

            builder.RegisterType<LanguageManager>().As<ILanguageService>();

            builder.RegisterType<MessageManager>().As<IMessageService>();



            builder.RegisterType<UserManager>().As<IUserService>();


            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<ConfigHelper>().As<IConfigHelper>();
            builder.RegisterType<MailServiceMimeKit>().As<IMailService>();

            builder.RegisterType<CloudinaryService>().As<ICloudinaryService>();
            builder.RegisterType<FileManager>().As<IFileManager>();


            builder.RegisterType<AdminManager>().As<IAdminService>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
