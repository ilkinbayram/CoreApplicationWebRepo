using Core.Entities.Dtos.Base;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.CourseComment
{
    public class CreateManagementCourseCommentDto : BaseDto
    {
        public CreateManagementCourseCommentDto()
        {
            ModelType = ProjectModelType.CourseComment;
        }

        public string OwnerEmail { get; set; }
        public string CommentContent { get; set; }

        public long CourseId { get; set; }
    }
}
