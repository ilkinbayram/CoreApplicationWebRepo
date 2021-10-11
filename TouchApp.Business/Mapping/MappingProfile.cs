using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos.Language;
using Core.Entities.Dtos.Localization;
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

            #region Student

            #endregion

            #region Exam

            #endregion

            #region Blog

            #endregion

            #region BlogCategory

            #endregion

            #region Course

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

            #endregion

            #region Tag

            #endregion

            #region MailModels
            CreateMap<MailRequest, ClientStaticMailTemplate>()
                .ForMember(x => x.Client_Full_Name, from => from.MapFrom(p => p.Name))
                .ForMember(x => x.Client_Description, from => from.MapFrom(p => p.Message))
                .ForMember(x => x.Client_Subject, from => from.MapFrom(p => p.Subject))
                .ForMember(x => x.Client_Phone, from => from.MapFrom(p => p.Phone))
                .ForMember(x => x.Client_Language_Id, from => from.MapFrom(p => p.LanguageID))
                .ForMember(x => x.Client_Email, from => from.MapFrom(p => p.FromEmail));

            #endregion
        }
    }
}
