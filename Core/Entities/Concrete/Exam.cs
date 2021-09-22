using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Exam : BaseEntity, IEntity
    {
        public Exam()
        {
            ModelType = ProjectModelType.Exam;
        }

        public string ExamTitleKey { get; set; }
        public byte ExamPeriodMinute { get; set; }
        public DateTime ExamDateTime { get; set; }
        public decimal AverageResulPercentage { get; set; }

        public long StudyingGroupId { get; set; }

        public virtual List<ExamQuestion> ExamQuestions { get; set; }
        public virtual List<ResultExam> Results { get; set; }
        public virtual StudyingGroup StudyingGroup { get; set; }
    }
}
