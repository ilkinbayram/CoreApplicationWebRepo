using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.ExamQuestion;
using Core.Entities.Dtos.QuestionResultExam;
using Core.Entities.Dtos.QuestionVariation;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Dtos.Question
{
    public class GetQuestionDto : BaseDto
    {
        public GetQuestionDto()
        {
            ModelType = ProjectModelType.Question;
        }

        public string QuestionToken { get; set; }
        public QuestionType QuestionType { get; set; }
        public string QuestionTextKey { get; set; }
        public DifficultyDegree DifficultyDegree { get; set; }

        public byte EvaluationPoint { get; set; }


        public List<GetQuestionVariationDto> MultiDefinitionVariations { get; set; }
        public List<GetExamQuestionDto> ExamQuestions { get; set; }
        public List<GetQuestionResultExamDto> QuestionResults { get; set; }
    }
}
