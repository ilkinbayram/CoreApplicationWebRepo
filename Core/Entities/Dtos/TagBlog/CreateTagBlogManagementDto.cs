using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Blog;
using Core.Entities.Dtos.Tag;
using Core.Resources.Enums;



namespace Core.Entities.Dtos.TagBlog
{
    public class CreateTagBlogManagementDto : BaseDto
    {
        public CreateTagBlogManagementDto()
        {
            ModelType = ProjectModelType.TagBlog;
            Created_at = System.DateTime.Now;
            Created_by = "System Manager";
            Modified_at = System.DateTime.Now;
            Modified_by = "System Manager";
        }

        public long TagId { get; set; }
        public long BlogId { get; set; }

        public CreateTagForManagementDto Tag { get; set; }
        public CreateManagementBlogDto Blog { get; set; }
    }
}
