using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.Teacher;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.TeacherCourse
{
    public class GetTeacherCourseDto : BaseDto
    {
        public GetTeacherCourseDto()
        {
            ModelType = ProjectModelType.TeacherCourse;
        }

        public long TeacherId { get; set; }
        public long CourseId { get; set; }

        public GetTeacherDto Teacher { get; set; }
        public GetCourseDto Course { get; set; }
    }
}
