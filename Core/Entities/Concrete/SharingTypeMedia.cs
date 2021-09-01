using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class SharingTypeMedia : BaseEntity, IEntity
    {
        public long MediaId { get; set; }
        public long SharingTypeId { get; set; }

        public virtual Media Media { get; set; }
        public virtual SharingType SharingType { get; set; }
    }
}
