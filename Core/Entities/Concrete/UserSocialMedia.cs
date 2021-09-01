using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class UserSocialMedia : BaseEntity, IEntity
    {
        public string RedirectUrl { get; set; }

        public long UserId { get; set; }
        public long SocialMediaId { get; set; }

        public virtual User User { get; set; }
        public virtual SocialMedia SocialMedia { get; set; }
    }
}
