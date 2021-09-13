using Core.Entities.Concrete.Base;



namespace Core.Entities.Concrete
{
    public class TeacherCourse : BaseEntity, IEntity
    {
        public TeacherCourse()
        {
            ModelType = Resources.Enums.ProjectModelType.TeacherCourse;
        }

        public long TeacherId { get; set; }
        public long CourseId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Course Course { get; set; }
    }
}
