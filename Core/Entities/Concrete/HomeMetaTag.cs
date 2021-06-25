using Core.Entities.Concrete.Base;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class HomeMetaTag : BaseEntity, IEntity
    {
        public virtual IEnumerable<HomeMetaTagLanguage> HomeMetaTagLanguages { get; set; }
        public virtual IEnumerable<HomeMetaTagGallery> HomeMetaTagGalleries { get; set; }
        public virtual IEnumerable<HomeMetaTagSection> HomeMetaTagSections { get; set; }
    }
}
