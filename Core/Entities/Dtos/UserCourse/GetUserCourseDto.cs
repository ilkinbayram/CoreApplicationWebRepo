using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.Teacher;
using Core.Entities.Dtos.User;
using Core.Resources.Enums;
using System;

namespace Core.Entities.Dtos.UserCourse
{
    public class GetUserCourseDto : BaseDto
    {
        public GetUserCourseDto()
        {
            ModelType = ProjectModelType.UserCourse;
        }

        public DateTime RegisteredDate { get; set; }

        public long TeacherId { get; set; }
        public long UserId { get; set; }
        public long CourseId { get; set; }

        public GetTeacherDto Teacher { get; set; }
        public GetUserDto User { get; set; }
        public GetCourseDto Course { get; set; }
    }
}
