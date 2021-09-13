using System.Collections.Generic;

using Core.Entities.Concrete.Base;
using Core.Resources.Enums;




namespace Core.Entities.Concrete
{
    public class Media : BaseEntity, IEntity
    {
        public Media()
        {
            ModelType = ProjectModelType.Media;
        }
        public string Source { get; set; }
        public string AltrKey { get; set; }
        public string UniqueParentToken { get; set; }
        public MediaType MediaType { get; set; }

        public virtual List<SharingTypeMedia> SharingTypeMedias { get; set; }
    }
}
