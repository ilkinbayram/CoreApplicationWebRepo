using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Media : BaseEntity, IEntity
    {
        public string Source { get; set; }
        public string AltrKey { get; set; }
        public MediaType MediaType { get; set; }

        public virtual Post Post { get; set; }
    }
}
