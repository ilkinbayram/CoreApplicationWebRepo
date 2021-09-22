using Core.Entities.Concrete.Base;
using Core.Resources.Enums;

namespace Core.Entities.Concrete
{
    public class ExamQuestion : BaseEntity, IEntity
    {
        public ExamQuestion()
        {
            ModelType = ProjectModelType.ExamQuestion;
        }

        public long ExamId { get; set; }
        public long QuestionId { get; set; }


        public virtual Exam Exam { get; set; }
        public virtual Question Question { get; set; }

    }
}
