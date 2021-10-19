using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Exam;
using Core.Entities.Dtos.QuestionResultExam;
using Core.Entities.Dtos.Student;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Dtos.ResultExam
{
    public class CreateManagementResultExamDto : BaseDto
    {
        public CreateManagementResultExamDto()
        {
            ModelType = ProjectModelType.ResultExam;
        }

        public bool IsJoined { get; set; }

        public byte RightAnswerCount { get; set; }
        public byte WrongAnswerCount { get; set; }
        public byte NoAnswerCount { get; set; }

        public decimal TotalPoint { get; set; }
        public decimal TotalRightPercentage { get; set; }

        public long StudentId { get; set; }
        public long ExamId { get; set; }

        public CreateManagementExamDto Exam { get; set; }
        public CreateManagementStudentDto Student { get; set; }
        public List<CreateManagementQuestionResultExamDto> QuestionResults { get; set; }
    }
}
