using Core.Entities.Dtos.Base;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.TeacherCourse
{
    public class CreateManagementTeacherCourseDto : BaseDto
    {
        public CreateManagementTeacherCourseDto()
        {
            ModelType = ProjectModelType.TeacherCourse;
        }
    }
}
