using System.Collections.Generic;
using Core.Entities.Concrete.Base;

namespace Core.Entities.Concrete
{
    public class SocialMedia : BaseEntity, IEntity
    {
        public SocialMedia()
        {
            ModelType = Resources.Enums.ProjectModelType.SocialMedia;
        }

        public string NameSocial { get; set; }
        public string Uri { get; set; }
        public string IconSource { get; set; }

        public virtual List<UserSocialMedia> UserSocialMedias { get; set; }
        public virtual List<TeacherSocialMedia> TeacherSocialMedias { get; set; }
    }
}
