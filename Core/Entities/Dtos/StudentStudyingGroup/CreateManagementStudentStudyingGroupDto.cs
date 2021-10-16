using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Student;
using Core.Entities.Dtos.StudyingGroup;
using Core.Resources.Enums;
using System;

namespace Core.Entities.Dtos.StudentStudyingGroup
{
    public class CreateManagementStudentStudyingGroupDto : BaseDto
    {
        public CreateManagementStudentStudyingGroupDto()
        {
            ModelType = ProjectModelType.StudentStudyingGroup;
        }

        public DateTime RegisteredDate { get; set; }

        public long StudentId { get; set; }
        public long StudyingGroupId { get; set; }


        public GetStudentDto Student { get; set; }
        public GetStudyingGroupDto StudyingGroup { get; set; }
    }
}
