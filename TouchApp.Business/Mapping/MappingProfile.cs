using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos.Blog;
using Core.Entities.Dtos.BlogCategory;
using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.CourseComment;
using Core.Entities.Dtos.Language;
using Core.Entities.Dtos.Localization;
using Core.Entities.Dtos.ProfessionCourseCategory;
using Core.Entities.Dtos.StudyingGroup;
using Core.Entities.Dtos.Tag;
using Core.Entities.Dtos.TagBlog;
using Core.Entities.Dtos.TeacherCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using TouchApp.Business.ExternalServices.Mail;
using TouchApp.Business.ExternalServices.Mail.MailTemplateModels.SendGrid;

namespace TouchApp.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User

            #endregion

            #region Teacher

            #endregion

            #region TeacherCourse
            CreateMap<GetTeacherCourseDto, TeacherCourse>();
            CreateMap<CreateManagementTeacherCourseDto, TeacherCourse>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<TeacherCourse, CreateManagementTeacherCourseDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<TeacherCourse, GetTeacherCourseDto>();
            #endregion

            #region Student

            #endregion

            #region Exam

            #endregion

            #region Blog
            CreateMap<GetBlogDto, Blog>();
            CreateMap<CreateManagementBlogDto, Blog>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<Blog, CreateManagementBlogDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<Blog, GetBlogDto>();
            #endregion

            #region TagBlog
            CreateMap<GetTagBlogDto, TagBlog>();
            CreateMap<CreateTagBlogManagementDto, TagBlog>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<TagBlog, GetTagBlogDto>();
            CreateMap<CreateTagBlogManagementDto, TagBlog>().ForMember(x => x.TagId, opt => opt.MapFrom(x => x.TagId));
            #endregion

            #region BlogCategory
            CreateMap<GetBlogCategoryDto, BlogCategory>();
            CreateMap<CreateBlogCategoryManagementDto, BlogCategory>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<BlogCategory, GetBlogCategoryDto>();
            #endregion

            #region Course
            CreateMap<GetCourseDto, Course>();
            CreateMap<CreateManagementCourseDto, Course>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<Course, CreateManagementCourseDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<Course, GetCourseDto>();
            #endregion

            #region CourseComments
            CreateMap<GetCourseCommentDto, CourseComment>();
            CreateMap<CreateManagementCourseCommentDto, CourseComment>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<CourseComment, CreateManagementCourseCommentDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<CourseComment, GetCourseCommentDto>();
            #endregion

            #region Language
            CreateMap<GetLanguageDto, Language>();
            CreateMap<CreateManagementLanguageDto, Language>()
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => p.Created_at))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => p.Created_by))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<Language, GetLanguageDto>();
            #endregion

            #region Localization
            CreateMap<GetLocalizationDto, Localization>();
            CreateMap<CreateLocalizationDto, Localization>()
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => p.Created_at))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => p.Created_by))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<Localization, GetLocalizationDto>();
            #endregion

            #region Our Service

            #endregion

            #region Phrase

            #endregion

            #region ProfessionCourseCategory
            CreateMap<GetProfessionCourseCategoryDto, ProfessionCourseCategory>();
            CreateMap<CreateManagementProfessionCourseCategoryDto, ProfessionCourseCategory>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<ProfessionCourseCategory, GetProfessionCourseCategoryDto>();
            #endregion

            #region Question

            #endregion

            #region SharingType

            #endregion

            #region Slider

            #endregion

            #region SocialMedia

            #endregion

            #region StudyingGroup
            CreateMap<GetStudyingGroupDto, StudyingGroup>();
            CreateMap<CreateManagementStudyingGroupDto, StudyingGroup>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<StudyingGroup, CreateManagementStudyingGroupDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<StudyingGroup, GetStudyingGroupDto>();
            #endregion

            #region Tag
            CreateMap<GetTagDto, Tag>();
            CreateMap<CreateTagForManagementDto, Tag>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<Tag, CreateTagForManagementDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<Tag, GetTagDto>();
            #endregion

            #region MailModels
            CreateMap<MailRequest, ClientStaticMailTemplate>()
                .ForMember(x => x.Client_Full_Name, from => from.MapFrom(p => p.Name))
                .ForMember(x => x.Client_Description, from => from.MapFrom(p => p.Message))
                .ForMember(x => x.Client_Subject, from => from.MapFrom(p => p.Subject))
                .ForMember(x => x.Client_Phone, from => from.MapFrom(p => p.Phone))
                .ForMember(x => x.Client_Language_Id, from => from.MapFrom(p => p.Lang_oid))
                .ForMember(x => x.Client_Email, from => from.MapFrom(p => p.FromEmail));
            #endregion
        }
    }
}
