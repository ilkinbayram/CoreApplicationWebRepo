using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.SocialMedia;
using Core.Entities.Dtos.Teacher;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.TeacherSocialMedia
{
    public class GetTeacherSocialMediaDto : BaseDto
    {
        public GetTeacherSocialMediaDto()
        {
            ModelType = ProjectModelType.TeacherSocialMedia;
        }

        public string RedirectUrl { get; set; }

        public long TeacherId { get; set; }
        public long SocialMediaId { get; set; }

        public GetTeacherDto Teacher { get; set; }
        public GetSocialMediaDto SocialMedia { get; set; }

    }
}
