using System.Collections.Generic;
using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.TeacherSocialMedia;
using Core.Entities.Dtos.UserSocialMedia;
using Core.Resources.Enums;


namespace Core.Entities.Dtos.SocialMedia
{
    public class GetSocialMediaDto : BaseDto
    {
        public GetSocialMediaDto()
        {
            ModelType = ProjectModelType.SocialMedia;
        }

        public SocialMediaType SocialMediaType { get; set; }
        public string NameSocial { get; set; }
        public string Uri { get; set; }
        public string IconSource { get; set; }
        public string IconHtml { get; set; }

        public List<GetUserSocialMediaDto> UserSocialMedias { get; set; }
        public List<GetTeacherSocialMediaDto> TeacherSocialMedias { get; set; }
    }
}
