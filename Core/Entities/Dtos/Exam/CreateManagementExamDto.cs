using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.ExamQuestion;
using Core.Resources.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.Exam
{
    public class CreateManagementExamDto : BaseDto
    {
        public CreateManagementExamDto()
        {
            ModelType = ProjectModelType.Exam;
        }

        public string ExamTitleKey { get; set; }
        public byte ExamPeriodMinute { get; set; }
        public DateTime ExamDateTime { get; set; }
        public decimal AverageResulPercentage { get; set; }

        public long StudyingGroupId { get; set; }

        public List<CreateManagementExamQuestionDto> ExamQuestions { get; set; }
    }
}
