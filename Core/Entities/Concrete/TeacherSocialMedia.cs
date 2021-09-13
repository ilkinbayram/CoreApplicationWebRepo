using Core.Entities.Concrete.Base;
using Core.Resources.Enums;



namespace Core.Entities.Concrete
{
    public class TeacherSocialMedia : BaseEntity, IEntity
    {
        public TeacherSocialMedia()
        {
            ModelType = ProjectModelType.TeacherSocialMedia;
        }

        public string RedirectUrl { get; set; }

        public long TeacherId { get; set; }
        public long SocialMediaId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual SocialMedia SocialMedia { get; set; }
    }
}
