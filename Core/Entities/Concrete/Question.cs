using Core.Entities.Concrete.Base;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Question : BaseEntity, IEntity
    {
        public Question()
        {
            ModelType = ProjectModelType.Question;
        }

        public string QuestionToken { get; set; }
        public QuestionType QuestionType { get; set; }
        public string QuestionTextKey { get; set; }
        public DifficultyDegree DifficultyDegree { get; set; }

        public byte EvaluationPoint { get; set; }


        public virtual List<QuestionVariation> MultiDefinitionVariations { get; set; }
        public virtual List<ExamQuestion> ExamQuestions { get; set; }
        public virtual List<QuestionResultExam> QuestionResults { get; set; }

    }
}
