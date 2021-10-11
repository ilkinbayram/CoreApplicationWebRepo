using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Concrete;
using Business.ExternalServices.Cloudinarys;
using Business.ExternalServices.Mail.Services;
using Business.ExternalServices.Mail.Services.Abstract;
using Business.Libs;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.Helpers;
using Core.Utilities.Helpers.Abstracts;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Services.Rest;
using Microsoft.AspNetCore.Http;
using TouchApp.Business.Abstract;
using TouchApp.DataAccess.Abstract;
using TouchApp.DataAccess.Concrete.EntityFramework;

namespace TouchApp.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();

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

            builder.RegisterType<StudentManager>().As<IStudentService>();
            builder.RegisterType<EfStudentDal>().As<IStudentDal>();

            builder.RegisterType<StudentOperationClaimManager>().As<IStudentOperationClaimService>();
            builder.RegisterType<EfStudentOperationClaimDal>().As<IStudentOperationClaimDal>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<TeacherOperationClaimManager>().As<ITeacherOperationClaimService>();
            builder.RegisterType<EfTeacherOperationClaimDal>().As<ITeacherOperationClaimDal>();

            builder.RegisterType<AnswerVariationManager>().As<IAnswerVariationService>();
            builder.RegisterType<EfAnswerVariationDal>().As<IAnswerVariationDal>();

            builder.RegisterType<ExamManager>().As<IExamService>();
            builder.RegisterType<EfExamDal>().As<IExamDal>();

            builder.RegisterType<ExamQuestionManager>().As<IExamQuestionService>();
            builder.RegisterType<EfExamQuestionDal>().As<IExamQuestionDal>();

            builder.RegisterType<QuestionManager>().As<IQuestionService>();
            builder.RegisterType<EfQuestionDal>().As<IQuestionDal>();

            builder.RegisterType<QuestionResultExamManager>().As<IQuestionResultExamService>();
            builder.RegisterType<EfQuestionResultExamDal>().As<IQuestionResultExamDal>();

            builder.RegisterType<QuestionVariationManager>().As<IQuestionVariationService>();
            builder.RegisterType<EfQuestionVariationDal>().As<IQuestionVariationDal>();

            builder.RegisterType<ResultExamManager>().As<IResultExamService>();
            builder.RegisterType<EfResultExamDal>().As<IResultExamDal>();

            builder.RegisterType<StudentStudyingGroupManager>().As<IStudentStudyingGroupService>();
            builder.RegisterType<EfStudentStudyingGroupDal>().As<IStudentStudyingGroupDal>();

            builder.RegisterType<StudyingGroupManager>().As<IStudyingGroupService>();
            builder.RegisterType<EfStudyingGroupDal>().As<IStudyingGroupDal>();


            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<ConfigHelper>().As<IConfigHelper>();
            builder.RegisterType<MailServiceMimeKit>().As<IMailService>();

            builder.RegisterType<CloudinaryService>().As<ICloudinaryService>();
            builder.RegisterType<FileManager>().As<IFileManager>();


            builder.RegisterType<AdminManager>().As<IAdminService>();


            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
            builder.RegisterType<ClientSideStorageHelper>().As<ISessionStorageHelper>();

            builder.RegisterType<SendGridService>().As<ISendgridMailService>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
