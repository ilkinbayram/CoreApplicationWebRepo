﻿using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class TagBlog : BaseEntity, IEntity
    {
        public long TagId { get; set; }
        public long BlogId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Blog Blog { get; set; }

    }
}
