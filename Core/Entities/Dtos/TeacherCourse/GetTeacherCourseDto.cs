using Core.Entities.Abstract;
using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.TeacherCourse
{
    public class GetTeacherCourseDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public long TeacherId { get; set; }
        public long CourseId { get; set; }

        public GetTeacherDto Teacher { get; set; }
        public GetCourseDto Course { get; set; }
    }
}
