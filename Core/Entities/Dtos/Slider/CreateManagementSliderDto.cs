using Microsoft.AspNetCore.Http;

using Core.Entities.Dtos.Base;
using Core.Resources.Enums;
using System.Collections.Generic;
using Core.Utilities.UsableModel;

namespace Core.Entities.Dtos.Slider
{
    public class CreateManagementSliderDto : BaseDto
    {
        public CreateManagementSliderDto()
        {
            ResponseMessages = new List<AlertResult>();
            ModelType = ProjectModelType.Slider;
        }
        public string MainTitleKey { get; set; }
        public string MainTitleTranslateAZE { get; set; }
        public string MainTitleTranslateTUR { get; set; }
        public string MainTitleTranslateRUS { get; set; }
        public string MainTitleTranslateENG { get; set; }
        public string ButtonTextKey { get; set; }
        public string ButtonTextTranslateAZE { get; set; }
        public string ButtonTextTranslateRUS { get; set; }
        public string ButtonTextTranslateENG { get; set; }
        public string ButtonTextTranslateTUR { get; set; }
        public string ButtonRoute { get; set; }
        public string SubTitleKey { get; set; }
        public string SubTitleTranslateAZE { get; set; }
        public string SubTitleTranslateTUR { get; set; }
        public string SubTitleTranslateENG { get; set; }
        public string SubTitleTranslateRUS { get; set; }
        public IFormFile SliderMediaSourceFile { get; set; }
        public string SliderMediaSource { get; set; }

        public List<AlertResult> ResponseMessages { get; set; }
    }
}
