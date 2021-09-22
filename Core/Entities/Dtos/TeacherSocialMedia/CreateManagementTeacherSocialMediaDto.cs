using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.SocialMedia;
using Core.Entities.Dtos.Teacher;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.TeacherSocialMedia
{
    public class CreateManagementTeacherSocialMediaDto : BaseDto
    {
        public CreateManagementTeacherSocialMediaDto()
        {
            ModelType = ProjectModelType.TeacherSocialMedia;
        }

        public string RedirectUrl { get; set; }

        public long TeacherId { get; set; }
        public long SocialMediaId { get; set; }

        public CreateManagementTeacherDto Teacher { get; set; }
        public CreateManagementSocialMediaDto SocialMedia { get; set; }

    }
}
