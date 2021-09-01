using Core.Entities.Abstract;
using Core.Entities.Dtos.Blog;
using Core.Entities.Dtos.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.TagBlog
{
    public class GetTagBlogDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public long TagId { get; set; }
        public long BlogId { get; set; }

        public GetTagDto Tag { get; set; }
        public GetBlogDto Blog { get; set; }
    }
}
