using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Localization : BaseEntity, IEntity
    {
        public string Key { get; set; }
        public string Translate { get; set; }
        public long Project_oid { get; set; }
        public byte Lang_oid { get; set; }
    }
}
