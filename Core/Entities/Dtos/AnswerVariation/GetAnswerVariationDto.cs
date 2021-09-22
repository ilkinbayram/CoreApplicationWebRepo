using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.QuestionResultExam;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.AnswerVariation
{
    public class GetAnswerVariationDto : BaseDto
    {

        public GetAnswerVariationDto()
        {
            ModelType = ProjectModelType.AnswerVariation;
        }

        public string DefinitionKey { get; set; }
        public string OptionKey { get; set; }
        public bool IsTrue { get; set; }

        public long QuestionResultId { get; set; }

        public GetQuestionResultExamDto QuestionResult { get; set; }
    }
}
