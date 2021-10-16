using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.StudentStudyingGroup;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Dtos.StudyingGroup
{
    public class CreateManagementStudyingGroupDto : BaseDto
    {
        public CreateManagementStudyingGroupDto()
        {
            ModelType = ProjectModelType.StudyingGroup;
        }

        public long CourseId { get; set; }

        public GetCourseDto Course { get; set; }
        public List<CreateManagementStudentStudyingGroupDto> StudentStudyingGroups { get; set; }
    }
}
