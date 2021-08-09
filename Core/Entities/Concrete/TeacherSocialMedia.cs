using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class TeacherSocialMedia : BaseEntity, IEntity
    {
        public string RedirectUrl { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual SocialMedia SocialMedia { get; set; }
    }
}
