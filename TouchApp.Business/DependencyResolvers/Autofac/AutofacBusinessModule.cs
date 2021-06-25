using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<CategoryLanguageManager>().As<ICategoryLanguageService>();
            builder.RegisterType<EfCategoryLanguageDal>().As<ICategoryLanguageDal>();

            builder.RegisterType<CategoryFeatureManager>().As<ICategoryFeatureService>();
            builder.RegisterType<EfCategoryFeatureDal>().As<ICategoryFeatureDal>();

            builder.RegisterType<FeatureLanguageManager>().As<IFeatureLanguageService>();
            builder.RegisterType<EfFeatureLanguageDal>().As<IFeatureLanguageDal>();

            builder.RegisterType<FeatureManager>().As<IFeatureService>();
            builder.RegisterType<EfFeatureDal>().As<IFeatureDal>();

            builder.RegisterType<FeatureValueLanguageManager>().As<IFeatureValueLanguageService>();
            builder.RegisterType<EfFeatureValueLanguageDal>().As<IFeatureValueLanguageDal>();

            builder.RegisterType<FeatureValueManager>().As<IFeatureValueService>();
            builder.RegisterType<EfFeatureValueDal>().As<IFeatureValueDal>();

            builder.RegisterType<HomeMetaTagGalleryManager>().As<IHomeMetaTagGalleryService>();
            builder.RegisterType<EfHomeMetaTagGalleryDal>().As<IHomeMetaTagGalleryDal>();

            builder.RegisterType<HomeMetaTagLanguageManager>().As<IHomeMetaTagLanguageService>();
            builder.RegisterType<EfHomeMetaTagLanguageDal>().As<IHomeMetaTagLanguageDal>();

            builder.RegisterType<HomeMetaTagSectionManager>().As<IHomeMetaTagSectionService>();
            builder.RegisterType<EfHomeMetaTagSectionDal>().As<IHomeMetaTagSectionDal>();

            builder.RegisterType<HomeMetaTagManager>().As<IHomeMetaTagService>();
            builder.RegisterType<EfHomeMetaTagDal>().As<IHomeMetaTagDal>();

            builder.RegisterType<LanguageManager>().As<ILanguageService>();
            builder.RegisterType<EfLanguageDal>().As<ILanguageDal>();

            builder.RegisterType<MessageManager>().As<IMessageService>();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>();

            builder.RegisterType<MessageLanguageManager>().As<IMessageLanguageService>();
            builder.RegisterType<EfMessageLanguageDal>().As<IMessageLanguageDal>();

            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();

            //builder.RegisterType<OrderOccasionManager>().As<IOrderOccasionService>();
            //builder.RegisterType<EfOrderOccasionDal>().As<IOrderOccasionDal>();

            //builder.RegisterType<OrderOccasionLanguageManager>().As<IOrderOccasionLanguageService>();
            //builder.RegisterType<EfOrderOccasionLanguageDal>().As<IOrderOccasionLanguageDal>();

            //builder.RegisterType<OrderPronounManager>().As<IOrderPronounService>();
            //builder.RegisterType<EfOrderPronounDal>().As<IOrderPronounDal>();

            //builder.RegisterType<OrderPronounLanguageManager>().As<IOrderPronounLanguageService>();
            //builder.RegisterType<EfOrderPronounLanguageDal>().As<IOrderPronounLanguageDal>();

            builder.RegisterType<RateManager>().As<IRateService>();
            builder.RegisterType<EfRateDal>().As<IRateDal>();

            builder.RegisterType<SectionLanguageManager>().As<ISectionLanguageService>();
            builder.RegisterType<EfSectionLanguageDal>().As<ISectionLanguageDal>();

            builder.RegisterType<SectionManager>().As<ISectionService>();
            builder.RegisterType<EfSectionDal>().As<ISectionDal>();

            builder.RegisterType<UserLanguageManager>().As<IUserLanguageService>();
            builder.RegisterType<EfUserLanguageDal>().As<IUserLanguageDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<UserLanguageManager>().As<IUserLanguageService>();
            builder.RegisterType<EfUserLanguageDal>().As<IUserLanguageDal>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<UserFeatureValueManager>().As<IUserFeatureValueService>();
            builder.RegisterType<EfUserFeatureValueDal>().As<IUserFeatureValueDal>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<ConfigHelper>().As<IConfigHelper>();
            builder.RegisterType<MailServiceMimeKit>().As<IMailService>();

            builder.RegisterType<CloudinaryService>().As<ICloudinaryService>();
            builder.RegisterType<FileManager>().As<IFileManager>();

            builder.RegisterType<EfCelebrityDal>().As<ICelebrityDal>();
            builder.RegisterType<CelebrityManager>().As<ICelebrityService>();

            builder.RegisterType<AdminManager>().As<IAdminService>();

            builder.RegisterType<ClientManager>().As<IClientService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
