using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Section : BaseEntity, IEntity
    {
        public string TitleKey { get; set; }
        public string SubtitleKey { get; set; }
        public string DescKey { get; set; }
        public string IconSource { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
