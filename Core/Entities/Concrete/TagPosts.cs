using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class TagPosts : BaseEntity, IEntity
    {
        public virtual Tag Tag { get; set; }
        public virtual Post Post { get; set; }

    }
}
