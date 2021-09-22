using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.ExamQuestion;
using Core.Entities.Dtos.ResultExam;
using Core.Entities.Dtos.StudyingGroup;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;

namespace Core.Entities.Dtos.Exam
{
    public class GetExamDto : BaseDto
    {
        public GetExamDto()
        {
            ModelType = ProjectModelType.Exam;
        }

        public string ExamTitleKey { get; set; }
        public byte ExamPeriodMinute { get; set; }
        public DateTime ExamDateTime { get; set; }
        public decimal AverageResulPercentage { get; set; }

        public long StudyingGroupId { get; set; }

        public List<GetExamQuestionDto> ExamQuestions { get; set; }
        public List<GetResultExamDto> Results { get; set; }
        public GetStudyingGroupDto StudyingGroup { get; set; }
    }
}
