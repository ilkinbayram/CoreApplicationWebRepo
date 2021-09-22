using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using System;

namespace Core.Entities.Concrete
{
    public class StudentStudyingGroup : BaseEntity, IEntity
    {
        public StudentStudyingGroup()
        {
            ModelType = ProjectModelType.StudentStudyingGroup;
        }

        public DateTime RegisteredDate { get; set; }

        public long StudentId { get; set; }
        public long StudyingGroupId { get; set; }


        public virtual Student Student { get; set; }
        public virtual StudyingGroup StudyingGroup { get; set; }
    }
}
