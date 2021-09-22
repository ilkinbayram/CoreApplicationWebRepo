using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Question;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.QuestionVariation
{
    public class GetQuestionVariationDto : BaseDto
    {
        public GetQuestionVariationDto()
        {
            ModelType = ProjectModelType.QuestionVariation;
        }

        public string VariationToken { get; set; }
        public string DefinitionKey { get; set; }
        public string OptionKey { get; set; }
        public bool IsTrue { get; set; }

        public long QuestionId { get; set; }

        public GetQuestionDto Question { get; set; }
    }
}
