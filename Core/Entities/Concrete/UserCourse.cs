using System;
using Core.Entities.Concrete.Base;

namespace Core.Entities.Concrete
{
    public class UserCourse : BaseEntity, IEntity
    {
        public UserCourse()
        {
            ModelType = Resources.Enums.ProjectModelType.UserCourse;
        }

        public DateTime RegisteredDate { get; set; }

        public long TeacherId { get; set; }
        public long UserId { get; set; }
        public long CourseId { get; set; }


        public virtual Teacher Teacher { get; set; }
        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
    }
}
