using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class ResultExam : BaseEntity, IEntity
    {
        public ResultExam()
        {
            ModelType = ProjectModelType.ResultExam;
        }

        public bool IsJoined { get; set; }

        public byte RightAnswerCount { get; set; }
        public byte WrongAnswerCount { get; set; }
        public byte NoAnswerCount { get; set; }

        public decimal TotalPoint { get; set; }
        public decimal TotalRightPercentage { get; set; }

        public long StudentId { get; set; }
        public long ExamId { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual Student Student { get; set; }
        public virtual List<QuestionResultExam> QuestionResults { get; set; }

    }
}
