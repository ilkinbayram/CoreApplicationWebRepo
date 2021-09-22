using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Exam;
using Core.Entities.Dtos.QuestionResultExam;
using Core.Entities.Dtos.Student;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Dtos.ResultExam
{
    public class GetResultExamDto : BaseDto
    {
        public GetResultExamDto()
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

        public GetExamDto Exam { get; set; }
        public GetStudentDto Student { get; set; }
        public List<GetQuestionResultExamDto> QuestionResults { get; set; }
    }
}
