using Core.Entities.Concrete.Base;
using Core.Resources.Enums;




namespace Core.Entities.Concrete
{
    public class Slider : BaseEntity, IEntity
    {
        public Slider()
        {
            ModelType = ProjectModelType.Slider;
        }
        
        public string TitleKey { get; set; }
        public string SubTitleKey { get; set; }
        public string SliderMediaSource { get; set; }
    }
}
