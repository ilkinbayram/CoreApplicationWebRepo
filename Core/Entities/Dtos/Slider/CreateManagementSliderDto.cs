using Core.Entities.Dtos.Base;
using Core.Resources.Enums;
using Microsoft.AspNetCore.Http;

namespace Core.Entities.Dtos.Slider
{
    public class CreateManagementSliderDto : BaseDto
    {
        public CreateManagementSliderDto()
        {
            ModelType = ProjectModelType.Slider;
        }
        public string TitleKey { get; set; }
        public string TitleTranslateAZE { get; set; }
        public string TitleTranslateTUR { get; set; }
        public string TitleTranslateRUS { get; set; }
        public string TitleTranslateENG { get; set; }
        public string SubTitleKey { get; set; }
        public string SubTitleTranslateAZE { get; set; }
        public string SubTitleTranslateTUR { get; set; }
        public string SubTitleTranslateENG { get; set; }
        public string SubTitleTranslateRUS { get; set; }
        public IFormFile SliderMediaSourceFile { get; set; }
        public string SliderMediaSource { get; set; }
    }
}
