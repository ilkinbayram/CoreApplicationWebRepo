using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class StudyingGroup : BaseEntity, IEntity
    {
        public StudyingGroup()
        {
            ModelType = ProjectModelType.StudyingGroup;
        }

        public long CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual List<Exam> Exams { get; set; }
        public virtual List<StudentStudyingGroup> StudentStudyingGroups { get; set; }
    }
}
