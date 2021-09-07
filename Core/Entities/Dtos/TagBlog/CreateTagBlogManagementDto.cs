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
        }

        public long TagId { get; set; }
        public long BlogId { get; set; }

        public CreateTagForManagementDto Tag { get; set; }
        public CreateBlogForManagementDto Blog { get; set; }
    }
}
