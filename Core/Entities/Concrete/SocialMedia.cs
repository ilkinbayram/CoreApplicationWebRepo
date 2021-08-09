using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class SocialMedia : BaseEntity, IEntity
    {
        public string NameSocial { get; set; }
        public string Uri { get; set; }
        public string IconSource { get; set; }

        public virtual List<UserSocialMedia> UserSocialMedias { get; set; }
        public virtual List<TeacherSocialMedia> TeacherSocialMedias { get; set; }
    }
}
