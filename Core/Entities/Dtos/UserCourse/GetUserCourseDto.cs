using Core.Entities.Abstract;
using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.Teacher;
using Core.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.UserCourse
{
    public class GetUserCourseDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public DateTime RegisteredDate { get; set; }

        public long TeacherId { get; set; }
        public long UserId { get; set; }
        public long CourseId { get; set; }

        public GetTeacherDto Teacher { get; set; }
        public GetUserDto User { get; set; }
        public GetCourseDto Course { get; set; }
    }
}
