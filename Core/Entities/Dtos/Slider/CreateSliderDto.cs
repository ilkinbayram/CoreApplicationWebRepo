﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.Slider
{
    public class CreateSliderDto
    {
        public string TitleKey { get; set; }
        public string SubTitleKey { get; set; }
        public string SliderMediaSource { get; set; }
    }
}