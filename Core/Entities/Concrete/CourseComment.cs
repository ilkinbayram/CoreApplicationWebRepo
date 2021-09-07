using Core.Entities.Concrete.Base;
using Core.Resources.Enums;

namespace Core.Entities.Concrete
{
    public class CourseComment : BaseEntity, IEntity
    {
        public CourseComment()
        {
            ModelType = ProjectModelType.CourseComment;
        }

        public string OwnerEmail { get; set; }
        public string CommentContent { get; set; }

        public long CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
