﻿using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Tag : BaseEntity, IEntity
    {
        public string NameKey { get; set; }
        public TagTypeEnum TagType { get; set; }


        public virtual List<TagPosts> TagPosts { get; set; }
    }
}
