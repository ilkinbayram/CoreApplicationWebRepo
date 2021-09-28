using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class SocialMedia : BaseEntity, IEntity
    {
        public SocialMedia()
        {
            ModelType = ProjectModelType.SocialMedia;
        }

        public SocialMediaType SocialMediaType { get; set; }
        public string NameSocial { get; set; }
        public string Uri { get; set; }
        public string IconSource { get; set; }
        public string IconHtml { get; set; }

        public virtual List<UserSocialMedia> UserSocialMedias { get; set; }
        public virtual List<TeacherSocialMedia> TeacherSocialMedias { get; set; }
    }
}
