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
using TouchApp.DataAccess.Abstract;
using TouchApp.DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<HomeMetaTagGalleryManager>().As<IHomeMetaTagGalleryService>();
            builder.RegisterType<EfHomeMetaTagGalleryDal>().As<IHomeMetaTagGalleryDal>();

            builder.RegisterType<HomeMetaTagManager>().As<IHomeMetaTagService>();
            builder.RegisterType<EfHomeMetaTagDal>().As<IHomeMetaTagDal>();

            builder.RegisterType<LanguageManager>().As<ILanguageService>();
            builder.RegisterType<EfLanguageDal>().As<ILanguageDal>();

            builder.RegisterType<LocalizationManager>().As<ILocalizationService>();
            builder.RegisterType<EfLocalizationDal>().As<ILocalizationDal>();

            builder.RegisterType<MediaManager>().As<IMediaService>();
            builder.RegisterType<EfMediaDal>().As<IMediaDal>();

            builder.RegisterType<MessageManager>().As<IMessageService>();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>();

            builder.RegisterType<PhraseManager>().As<IPhraseService>();
            builder.RegisterType<EfPhraseDal>().As<IPhraseDal>();

            builder.RegisterType<PostManager>().As<IPostService>();
            builder.RegisterType<EfPostDal>().As<IPostDal>();

            builder.RegisterType<ProfessionManager>().As<IProfessionService>();
            builder.RegisterType<EfProfessionDal>().As<IProfessionDal>();

            builder.RegisterType<RoutingManager>().As<IRoutingService>();
            builder.RegisterType<EfRoutingDal>().As<IRoutingDal>();

            builder.RegisterType<SectionManager>().As<ISectionService>();
            builder.RegisterType<EfSectionDal>().As<ISectionDal>();

            builder.RegisterType<SharingTypeManager>().As<ISharingTypeService>();
            builder.RegisterType<EfSharingTypeDal>().As<ISharingTypeDal>();

            builder.RegisterType<SocialMediaManager>().As<ISocialMediaService>();
            builder.RegisterType<EfSocialMediaDal>().As<ISocialMediaDal>();

            builder.RegisterType<TagManager>().As<ITagService>();
            builder.RegisterType<EfTagDal>().As<ITagDal>();

            builder.RegisterType<TagPostsManager>().As<ITagPostsService>();
            builder.RegisterType<EfTagPostsDal>().As<ITagPostsDal>();

            builder.RegisterType<TeacherInfoManager>().As<ITeacherInfoService>();
            builder.RegisterType<EfTeacherInfoDal>().As<ITeacherInfoDal>();

            builder.RegisterType<UserSocialMediaManager>().As<IUserSocialMediaService>();
            builder.RegisterType<EfUserSocialMediaDal>().As<IUserSocialMediaDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();


            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

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
