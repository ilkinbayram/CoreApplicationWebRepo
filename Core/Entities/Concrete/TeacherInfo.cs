using Core.Entities.Abstract;
using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class TeacherInfo : BaseEntity, IEntity
    {
        public string PreviewMoviePath { get; set; }
        public decimal? UnitPrice { get; set; }
        public string IconSource { get; set; }

        public virtual Profession Profession { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual List<UserCourse> UserCourses { get; set; }
    }
}
