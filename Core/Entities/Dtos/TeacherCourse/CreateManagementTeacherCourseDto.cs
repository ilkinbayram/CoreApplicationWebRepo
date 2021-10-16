using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Course;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.TeacherCourse
{
    public class CreateManagementTeacherCourseDto : BaseDto
    {
        public CreateManagementTeacherCourseDto()
        {
            ModelType = ProjectModelType.TeacherCourse;
        }

        public long TeacherId { get; set; }
        public long CourseId { get; set; }

        public CreateManagementCourseDto Course { get; set; }
    }
}
