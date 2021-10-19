using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Exam;
using Core.Entities.Dtos.Question;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.ExamQuestion
{
    public class CreateManagementExamQuestionDto : BaseDto
    {
        public CreateManagementExamQuestionDto()
        {
            ModelType = ProjectModelType.ExamQuestion;
        }

        public long ExamId { get; set; }
        public long QuestionId { get; set; }


        public CreateManagementExamDto Exam { get; set; }
        public CreateManagementQuestionDto Question { get; set; }
    }
}
