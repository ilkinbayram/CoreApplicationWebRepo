using Core.Entities.Dtos.Base;
using Core.Entities.Dtos.TagBlog;
using Core.Resources.Enums;
using System.Collections.Generic;

namespace Core.Entities.Dtos.Tag
{
    public class GetTagDto : BaseDto
    {
        public GetTagDto()
        {
            ModelType = ProjectModelType.Tag;
        }

        public string Name { get; set; }
        public TagTypeEnum TagType { get; set; }
        public List<GetTagBlogDto> TagBlogs { get; set; }

    }
}
