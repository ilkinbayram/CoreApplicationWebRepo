using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Course;
using Core.Resources.Enums;

namespace Core.Entities.Dtos.CourseComment
{
    public class GetCourseCommentDto : BaseDto
    {
        public GetCourseCommentDto()
        {
            ModelType = ProjectModelType.CourseComment;
        }
        public string OwnerEmail { get; set; }
        public string CommentContent { get; set; }

        public long CourseId { get; set; }

        public GetCourseDto Course { get; set; }
    }
}
