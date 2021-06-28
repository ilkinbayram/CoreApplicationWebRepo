using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Routing : BaseEntity, IEntity
    {
        public string AreaNameKey { get; set; }
        public string ControllerNameKey { get; set; }
        public string ActionNameKey { get; set; }
    }
}
