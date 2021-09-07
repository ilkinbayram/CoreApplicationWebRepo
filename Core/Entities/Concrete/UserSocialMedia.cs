using Core.Entities.Concrete.Base;
using Core.Resources.Enums;

namespace Core.Entities.Concrete
{
    public class UserSocialMedia : BaseEntity, IEntity
    {
        public UserSocialMedia()
        {
            ModelType = ProjectModelType.UserSocialMedia;
        }

        public string RedirectUrl { get; set; }

        public long UserId { get; set; }
        public long SocialMediaId { get; set; }

        public virtual User User { get; set; }
        public virtual SocialMedia SocialMedia { get; set; }
    }
}
