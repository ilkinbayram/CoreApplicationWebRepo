using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class CourseService : BaseEntity, IEntity
    {
        public string TitleKey { get; set; }
        public string DescriptionKey { get; set; }
        public string UniqueToken { get; set; }
        public string IconSource { get; set; }
    }
}
