using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.SocialMedia;
using Core.Entities.Dtos.User;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.UserSocialMedia
{
    public class GetUserSocialMediaDto : BaseDto
    {
        public GetUserSocialMediaDto()
        {
            ModelType = ProjectModelType.UserSocialMedia;
        }

        public string RedirectUrl { get; set; }

        public long UserId { get; set; }
        public long SocialMediaId { get; set; }

        public GetUserDto User { get; set; }
        public GetSocialMediaDto SocialMedia { get; set; }
    }
}
