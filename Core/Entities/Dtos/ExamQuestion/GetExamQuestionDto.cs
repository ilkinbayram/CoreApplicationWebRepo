using Core.Entities.Concrete.Base;
using Core.Entities.Dtos.Exam;
using Core.Entities.Dtos.Question;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.ExamQuestion
{
    public class GetExamQuestionDto : BaseEntity
    {
        public GetExamQuestionDto()
        {
            ModelType = ProjectModelType.ExamQuestion;
        }

        public long ExamId { get; set; }
        public long QuestionId { get; set; }


        public GetExamDto Exam { get; set; }
        public GetQuestionDto Question { get; set; }

    }
}
