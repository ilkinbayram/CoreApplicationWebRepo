using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.SocialMedia;
using Core.Entities.Dtos.User;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.UserSocialMedia
{
    public class CreateManagementUserSocialMediaDto : BaseDto
    {
        public CreateManagementUserSocialMediaDto()
        {
            ModelType = ProjectModelType.UserSocialMedia;
        }

        public string RedirectUrl { get; set; }

        public long UserId { get; set; }
        public long SocialMediaId { get; set; }

        public CreateManagementUserDto User { get; set; }
        public CreateManagementSocialMediaDto SocialMedia { get; set; }
    }
}
