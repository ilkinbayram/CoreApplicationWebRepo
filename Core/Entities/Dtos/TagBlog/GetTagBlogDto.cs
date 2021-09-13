using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.Blog;
using Core.Entities.Dtos.Tag;
using Core.Resources.Enums;



namespace Core.Entities.Dtos.TagBlog
{
    public class GetTagBlogDto : BaseDto
    {
        public GetTagBlogDto()
        {
            ModelType = ProjectModelType.TagBlog;
        }

        public long TagId { get; set; }
        public long BlogId { get; set; }

        public GetTagDto Tag { get; set; }
        public GetBlogDto Blog { get; set; }
    }
}
