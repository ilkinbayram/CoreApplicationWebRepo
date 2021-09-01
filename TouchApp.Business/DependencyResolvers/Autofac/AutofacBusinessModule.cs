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
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Microsoft.AspNetCore.Http;

namespace TouchApp.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<CourseManager>().As<ICourseService>();
            builder.RegisterType<EfCourseDal>().As<ICourseDal>();

            builder.RegisterType<CourseCommentManager>().As<ICourseCommentService>();
            builder.RegisterType<EfCourseCommentDal>().As<ICourseCommentDal>();

            builder.RegisterType<CourseServiceManager>().As<ICourseServiceService>();
            builder.RegisterType<EfCourseServiceDal>().As<ICourseServiceDal>();

            builder.RegisterType<BlogCategoryManager>().As<IBlogCategoryService>();
            builder.RegisterType<EfBlogCategoryDal>().As<IBlogCategoryDal>();

            builder.RegisterType<ProfessionCourseCategoryManager>().As<IProfessionCourseCategoryService>();
            builder.RegisterType<EfProfessionCourseCategoryDal>().As<IProfessionCourseCategoryDal>();

            builder.RegisterType<SliderManager>().As<ISliderService>();
            builder.RegisterType<EfSliderDal>().As<ISliderDal>();

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

            builder.RegisterType<BlogManager>().As<IBlogService>();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>();

            builder.RegisterType<ProfessionManager>().As<IProfessionService>();
            builder.RegisterType<EfProfessionDal>().As<IProfessionDal>();

            builder.RegisterType<SharingTypeManager>().As<ISharingTypeService>();
            builder.RegisterType<EfSharingTypeDal>().As<ISharingTypeDal>();

            builder.RegisterType<SharingTypeMediaManager>().As<ISharingTypeMediaService>();
            builder.RegisterType<EfSharingTypeMediaDal>().As<ISharingTypeMediaDal>();

            builder.RegisterType<SocialMediaManager>().As<ISocialMediaService>();
            builder.RegisterType<EfSocialMediaDal>().As<ISocialMediaDal>();

            builder.RegisterType<TagManager>().As<ITagService>();
            builder.RegisterType<EfTagDal>().As<ITagDal>();

            builder.RegisterType<TagBlogManager>().As<ITagBlogService>();
            builder.RegisterType<EfTagBlogDal>().As<ITagBlogDal>();

            builder.RegisterType<TeacherManager>().As<ITeacherService>();
            builder.RegisterType<EfTeacherDal>().As<ITeacherDal>();

            builder.RegisterType<TeacherCourseManager>().As<ITeacherCourseService>();
            builder.RegisterType<EfTeacherCourseDal>().As<ITeacherCourseDal>();

            builder.RegisterType<TeacherSocialMediaManager>().As<ITeacherSocialMediaService>();
            builder.RegisterType<EfTeacherSocialMediaDal>().As<ITeacherSocialMediaDal>();

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


            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
            builder.RegisterType<ClientSideStorageHelper>().As<ISessionStorageHelper>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
