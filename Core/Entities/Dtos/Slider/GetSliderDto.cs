using Core.Entities.Dtos.Base;
using Core.Resources.Enums;



namespace Core.Entities.Dtos.Slider
{
    public class GetSliderDto : BaseDto
    {
        public GetSliderDto()
        {
            ModelType = ProjectModelType.Slider;
        }
        public string MainTitleKey { get; set; }
        public string SubTitleKey { get; set; }
        public string SliderMediaSource { get; set; }
        public string ButtonTextKey { get; set; }
        public string ButtonRoute { get; set; }
    }
}
