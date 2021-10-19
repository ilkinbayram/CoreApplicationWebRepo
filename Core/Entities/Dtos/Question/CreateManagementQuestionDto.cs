using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.ExamQuestion;
using Core.Entities.Dtos.QuestionResultExam;
using Core.Entities.Dtos.QuestionVariation;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Dtos.Question
{
    public class CreateManagementQuestionDto : BaseDto
    {
        public CreateManagementQuestionDto()
        {
            ModelType = ProjectModelType.Question;
        }

        public string QuestionToken { get; set; }
        public QuestionType QuestionType { get; set; }
        public string QuestionTextKey { get; set; }
        public DifficultyDegree DifficultyDegree { get; set; }

        public byte EvaluationPoint { get; set; }


        public List<CreateManagementQuestionVariationDto> MultiDefinitionVariations { get; set; }
        public List<CreateManagementExamQuestionDto> ExamQuestions { get; set; }
        public List<CreateManagementQuestionResultExamDto> QuestionResults { get; set; }
    }
}
