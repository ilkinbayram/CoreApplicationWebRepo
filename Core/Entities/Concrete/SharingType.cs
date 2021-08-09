using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class SharingType : BaseEntity, IEntity
    {
        public string NameKey { get; set; }
        public virtual List<SharingTypeMedia> SharingTypeMedias { get; set; }
    }
}
