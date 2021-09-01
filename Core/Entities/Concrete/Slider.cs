using Core.Entities.Concrete.Base;

namespace Core.Entities.Concrete
{
    public class Slider : BaseEntity, IEntity
    {
        public string TitleKey { get; set; }
        public string SubTitleKey { get; set; }
        public string SliderMediaSource { get; set; }
    }
}
