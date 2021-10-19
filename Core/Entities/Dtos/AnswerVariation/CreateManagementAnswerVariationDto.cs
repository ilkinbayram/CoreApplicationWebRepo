using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.QuestionResultExam;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.AnswerVariation
{
    public class CreateManagementAnswerVariationDto : BaseDto
    {
        public CreateManagementAnswerVariationDto()
        {
            ModelType = ProjectModelType.AnswerVariation;
        }

        public string DefinitionKey { get; set; }
        public string OptionKey { get; set; }
        public bool IsTrue { get; set; }

        public long QuestionResultId { get; set; }

        public CreateManagementQuestionResultExamDto QuestionResult { get; set; }
    }
}
