using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos.Blog;
using Core.Entities.Dtos.BlogCategory;
using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.CourseComment;
using Core.Entities.Dtos.Exam;
using Core.Entities.Dtos.ExamQuestion;
using Core.Entities.Dtos.Language;
using Core.Entities.Dtos.Localization;
using Core.Entities.Dtos.Media;
using Core.Entities.Dtos.OurService;
using Core.Entities.Dtos.Phrase;
using Core.Entities.Dtos.ProfessionCourseCategory;
using Core.Entities.Dtos.Question;
using Core.Entities.Dtos.QuestionResultExam;
using Core.Entities.Dtos.QuestionVariation;
using Core.Entities.Dtos.ResultExam;
using Core.Entities.Dtos.SharingType;
using Core.Entities.Dtos.SharingTypeMedia;
using Core.Entities.Dtos.Slider;
using Core.Entities.Dtos.SocialMedia;
using Core.Entities.Dtos.Student;
using Core.Entities.Dtos.StudyingGroup;
using Core.Entities.Dtos.Tag;
using Core.Entities.Dtos.TagBlog;
using Core.Entities.Dtos.Teacher;
using Core.Entities.Dtos.TeacherCourse;
using Core.Entities.Dtos.TeacherSocialMedia;
using Core.Entities.Dtos.User;
using System;
using TouchApp.Business.ExternalServices.Mail;
using TouchApp.Business.ExternalServices.Mail.MailTemplateModels.SendGrid;
using TouchApp.Business.ExternalServices.Mail.ModelAcceptor;

namespace TouchApp.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<GetUserDto, User>();
            CreateMap<CreateManagementUserDto, User>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<User, CreateManagementUserDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<User, GetUserDto>();
            #endregion

            #region Teacher
            CreateMap<GetTeacherDto, Teacher>();
            CreateMap<CreateManagementTeacherDto, Teacher>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<Teacher, CreateManagementTeacherDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<Teacher, GetTeacherDto>();
            #endregion

            #region TeacherSocialMedia
            CreateMap<GetTeacherSocialMediaDto, TeacherSocialMedia>();
            CreateMap<CreateManagementTeacherSocialMediaDto, TeacherSocialMedia>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<TeacherSocialMedia, CreateManagementTeacherSocialMediaDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<TeacherSocialMedia, GetTeacherSocialMediaDto>();
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
            CreateMap<GetStudentDto, Student>();
            CreateMap<CreateManagementStudentDto, Student>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<Student, CreateManagementStudentDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<Student, GetStudentDto>();
            #endregion

            #region Exam
            CreateMap<GetExamDto, Exam>();
            CreateMap<CreateManagementExamDto, Exam>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<Exam, CreateManagementExamDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<Exam, GetExamDto>();
            #endregion

            #region ExamQuestion
            CreateMap<GetExamQuestionDto, ExamQuestion>();
            CreateMap<CreateManagementExamQuestionDto, ExamQuestion>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<ExamQuestion, CreateManagementExamQuestionDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<ExamQuestion, GetExamQuestionDto>();
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

            #region CourseService
            CreateMap<GetCourseServiceDto, CourseService>();
            CreateMap<CreateManagementCourseServiceDto, CourseService>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<CourseService, CreateManagementCourseServiceDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<CourseService, GetCourseServiceDto>();
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
            CreateMap<GetPhraseDto, Phrase>();
            CreateMap<CreateManagementPhraseDto, Phrase>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<Phrase, CreateManagementPhraseDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<Phrase, GetPhraseDto>();
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

            #region ResultExam
            CreateMap<GetResultExamDto, ResultExam>();
            CreateMap<CreateManagementResultExamDto, ResultExam>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<ResultExam, CreateManagementResultExamDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<ResultExam, GetResultExamDto>();
            #endregion

            #region Question
            CreateMap<GetQuestionDto, Question>();
            CreateMap<CreateManagementQuestionDto, Question>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<Question, CreateManagementQuestionDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<Question, GetQuestionDto>();
            #endregion

            #region QuestionResultExam
            CreateMap<GetQuestionResultExamDto, QuestionResultExam>();
            CreateMap<CreateManagementQuestionResultExamDto, QuestionResultExam>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<QuestionResultExam, CreateManagementQuestionResultExamDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<QuestionResultExam, GetQuestionResultExamDto>();
            #endregion

            #region QuestionVariation
            CreateMap<GetQuestionVariationDto, QuestionVariation>();
            CreateMap<CreateManagementQuestionVariationDto, QuestionVariation>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<QuestionVariation, CreateManagementQuestionVariationDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<QuestionVariation, GetQuestionVariationDto>();
            #endregion

            #region SharingType
            CreateMap<GetSharingTypeDto, SharingType>();
            CreateMap<CreateManagementSharingTypeDto, SharingType>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<SharingType, CreateManagementSharingTypeDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<SharingType, GetSharingTypeDto>();
            #endregion

            #region SharingTypeMedia
            CreateMap<GetSharingTypeMediaDto, SharingTypeMedia>();
            CreateMap<CreateManagementSharingTypeMediaDto, SharingTypeMedia>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<SharingTypeMedia, CreateManagementSharingTypeMediaDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<SharingTypeMedia, GetSharingTypeMediaDto>();
            #endregion

            #region Slider
            CreateMap<GetSliderDto, Slider>();
            CreateMap<CreateManagementSliderDto, Slider>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<Slider, CreateManagementSliderDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<Slider, GetSliderDto>();
            #endregion

            #region SocialMedia
            CreateMap<GetSocialMediaDto, SocialMedia>();
            CreateMap<CreateManagementSocialMediaDto, SocialMedia>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<SocialMedia, CreateManagementSocialMediaDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<SocialMedia, GetSocialMediaDto>();
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

            #region Media
            CreateMap<GetMediaDto, Media>();
            CreateMap<CreateManagementMediaDto, Media>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(p => true));
            CreateMap<Media, CreateManagementMediaDto>()
                .ForMember(x => x.Created_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Created_by, opt => opt.MapFrom(p => "System Manager"))
                .ForMember(x => x.Modified_at, opt => opt.MapFrom(p => DateTime.Now))
                .ForMember(x => x.Modified_by, opt => opt.MapFrom(p => "System Manager"));
            CreateMap<Media, GetMediaDto>();
            #endregion

            #region MailModels
            CreateMap<MailRequest, ClientStaticMailTemplate>()
                .ForMember(x => x.Client_Full_Name, from => from.MapFrom(p => p.Name))
                .ForMember(x => x.Client_Description, from => from.MapFrom(p => p.Message))
                .ForMember(x => x.Client_Subject, from => from.MapFrom(p => p.Subject))
                .ForMember(x => x.Client_Phone, from => from.MapFrom(p => p.Phone))
                .ForMember(x => x.Client_Language_Id, from => from.MapFrom(p => p.Lang_oid))
                .ForMember(x => x.Client_Email, from => from.MapFrom(p => p.FromEmail));

            CreateMap<MailRequest, InformationMailRequestModel>();
            CreateMap<MailRequest, QuickRegisterMailRequestModel>();
            CreateMap<MailRequest, RegisterMailRequestModel>();
            #endregion
        }
    }
}
