﻿using Core.Entities.Dtos.Base;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.Slider
{
    public class GetSliderDto : BaseDto
    {
        public GetSliderDto()
        {
            ModelType = ProjectModelType.Slider;
        }
        public string TitleKey { get; set; }
        public string SubTitleKey { get; set; }
        public string SliderMediaSource { get; set; }
    }
}
