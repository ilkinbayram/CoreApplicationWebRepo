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
        
        public string MainTitleKey { get; set; }
        public string SubTitleKey { get; set; }
        public string ButtonTextKey { get; set; }
        public string ButtonRoute { get; set; }
        public string SliderMediaSource { get; set; }
    }
}
