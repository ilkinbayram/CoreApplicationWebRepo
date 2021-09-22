using Core.Entities.Concrete.Base;
using Core.Resources.Enums;

namespace Core.Entities.Concrete
{
    public class AnswerVariation : BaseEntity, IEntity
    {
        public AnswerVariation()
        {
            ModelType = ProjectModelType.AnswerVariation;
        }

        public string DefinitionKey { get; set; }
        public string OptionKey { get; set; }
        public bool IsTrue { get; set; }

        public long QuestionResultId { get; set; }

        public virtual QuestionResultExam QuestionResult { get; set; }
    }
}
