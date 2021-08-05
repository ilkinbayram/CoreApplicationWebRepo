using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Course : BaseEntity, IEntity
    {
        public string UniqueCourseName { get; set; }
        public string DescriptionKey { get; set; }
        public byte PeriodAsMonth { get; set; }
        public decimal PricePerMonth { get; set; }

        public virtual ProfessionCourseCategory ProfessionCourseCategory { get; set; }
        public virtual TeacherInfo TeacherInfo { get; set; }
        public virtual List<UserCourse> UserCourses { get; set; }
    }
}
