using Core.Entities.Concrete.Base;
using Core.Resources.Enums;





namespace Core.Entities.Concrete
{
    public class SharingTypeMedia : BaseEntity, IEntity
    {
        public SharingTypeMedia()
        {
            ModelType = ProjectModelType.SharingTypeMedia;
        }

        public long MediaId { get; set; }
        public long SharingTypeId { get; set; }

        public virtual Media Media { get; set; }
        public virtual SharingType SharingType { get; set; }
    }
}
