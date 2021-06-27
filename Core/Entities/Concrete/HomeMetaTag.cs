using Core.Entities.Concrete.Base;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class HomeMetaTag : BaseEntity, IEntity
    {
        public virtual IEnumerable<HomeMetaTagGallery> HomeMetaTagGalleries { get; set; }
    }
}
