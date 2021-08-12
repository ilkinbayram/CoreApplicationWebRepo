﻿using Core.Entities.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Course : BaseEntity, IEntity
    {
        public string UniqueToken { get; set; }
        public string TitleKey { get; set; }
        public string DescriptionKey { get; set; }
        public byte MinTotalMonths { get; set; }
        public byte MaxTotalMonths { get; set; }
        public short TotalHours { get; set; }
        public decimal PricePerMonth { get; set; }
        public string ScheduleHtmlRawKey { get; set; }
        public string ContentHtmlRawKey { get; set; }
        public string OverViewHtmlRawKey { get; set; }
        public DateTime PublishDate { get; set; }


        public virtual List<TeacherCourse> TeacherCourses { get; set; }
        public virtual List<UserCourse> UserCourses { get; set; }
        public virtual List<CourseComment> CourseComments { get; set; }
        public virtual ProfessionCourseCategory ProfessionCourseCategory { get; set; }
    }
}