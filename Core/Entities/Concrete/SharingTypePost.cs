using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class SharingTypePost : BaseEntity, IEntity
    {
        public virtual Post Post { get; set; }
        public virtual SharingType SharingType { get; set; }
    }
}
