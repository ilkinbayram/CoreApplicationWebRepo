using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class QuestionResultExam : BaseEntity, IEntity
    {
        public QuestionResultExam()
        {
            ModelType = ProjectModelType.QuestionResultExam;
        }


        public long QuestionId { get; set; }
        public long ResultExamId { get; set; }

        public virtual List<AnswerVariation> AnswerVariations { get; set; }

        public virtual Question Question { get; set; }
        public virtual ResultExam ResultExam { get; set; }

    }
}
