using Core.Entities.Concrete.Base;
using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.Exam;
using Core.Entities.Dtos.StudentStudyingGroup;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Dtos.StudyingGroup
{
    public class GetStudyingGroupDto : BaseEntity
    {
        public GetStudyingGroupDto()
        {
            ModelType = ProjectModelType.StudyingGroup;
        }

        public long CourseId { get; set; }

        public GetCourseDto Course { get; set; }
        public List<GetExamDto> Exams { get; set; }
        public List<GetStudentStudyingGroupDto> StudentStudyingGroups { get; set; }
    }
}
