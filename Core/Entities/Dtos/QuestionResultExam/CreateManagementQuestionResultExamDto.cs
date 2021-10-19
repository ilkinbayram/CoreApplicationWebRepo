using Core.Entities.Dtos.AnswerVariation;
using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Question;
using Core.Entities.Dtos.ResultExam;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Dtos.QuestionResultExam
{
    public class CreateManagementQuestionResultExamDto : BaseDto
    {
        public CreateManagementQuestionResultExamDto()
        {
            ModelType = ProjectModelType.QuestionResultExam;
        }


        public long QuestionId { get; set; }
        public long ResultExamId { get; set; }

        public List<CreateManagementAnswerVariationDto> AnswerVariations { get; set; }

        public CreateManagementQuestionDto Question { get; set; }
        public CreateManagementResultExamDto ResultExam { get; set; }
    }
}
