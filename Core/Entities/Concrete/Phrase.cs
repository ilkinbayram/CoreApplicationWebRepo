using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Phrase : BaseEntity, IEntity
    {
        public string Owner { get; set; }
        public string CaptionSource { get; set; }
        public string ProfessionKey { get; set; }
        public string ContentKey { get; set; }
        public string TitleKey { get; set; }
    }
}
