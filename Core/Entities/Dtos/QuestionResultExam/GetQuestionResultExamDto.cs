using Core.Entities.Dtos.AnswerVariation;
using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Question;
using Core.Entities.Dtos.ResultExam;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Dtos.QuestionResultExam
{
    public class GetQuestionResultExamDto : BaseDto
    {
        public GetQuestionResultExamDto()
        {
            ModelType = ProjectModelType.QuestionResultExam;
        }


        public long QuestionId { get; set; }
        public long ResultExamId { get; set; }

        public List<GetAnswerVariationDto> AnswerVariations { get; set; }

        public GetQuestionDto Question { get; set; }
        public GetResultExamDto ResultExam { get; set; }
    }
}
