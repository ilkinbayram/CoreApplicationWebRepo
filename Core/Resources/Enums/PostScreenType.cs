﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Resources.Enums
{
    public enum PostScreenType : byte
    {
        FullDetailed = 1,
        TitleContent = 2,
        TitleSubTitleContent = 3,
        TitleMedia = 4,
        OnlyContent = 5,
        OnlyMedia = 6
    }
}