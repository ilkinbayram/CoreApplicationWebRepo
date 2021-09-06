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
    public class CreateTagBlogManagementDto : BaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public long TagId { get; set; }
        public long BlogId { get; set; }

        public CreateTagForManagementDto Tag { get; set; }
        public CreateBlogForManagementDto Blog { get; set; }
    }
}
