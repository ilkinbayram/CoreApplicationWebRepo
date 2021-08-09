using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class ProfessionCourseCategory : BaseEntity, IEntity
    {
        public string NameKey { get; set; }
        public bool HasMedia { get; set; }
        public string IconSource { get; set; }
        public string DescriptionKey { get; set; }

        public virtual HashSet<ProfessionCourseCategory> Children { get; set; } //ozunden ozune relation ucun ve childlari
        public virtual ProfessionCourseCategory ParentCategory { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
