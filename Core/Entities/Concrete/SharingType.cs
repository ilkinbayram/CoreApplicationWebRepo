using System.Collections.Generic;

using Core.Entities.Concrete.Base;
using Core.Resources.Enums;





namespace Core.Entities.Concrete
{
    public class SharingType : BaseEntity, IEntity
    {
        public SharingType()
        {
            ModelType = ProjectModelType.SharingType;
        }

        public string NameKey { get; set; }
        public virtual List<SharingTypeMedia> SharingTypeMedias { get; set; }
    }
}
