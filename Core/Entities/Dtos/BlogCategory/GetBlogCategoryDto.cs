using Core.Entities.Abstract;
using Core.Entities.Dtos.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Dtos.BlogCategory
{
    public class GetBlogCategoryDto : IBaseDto
    {
        public long Id { get; set; }
        public string Created_by { get; set; }
        public DateTime Created_at { get; set; }

        public string NameKey { get; set; }
        public string DescKey { get; set; }
        public string IconSource { get; set; }
        public long? ParentCategoryId { get; set; }

        public HashSet<GetBlogCategoryDto> Children { get; set; } //ozunden ozune relation ucun ve childlari
        public GetBlogCategoryDto ParentCategory { get; set; }
        public List<GetBlogDto> Blogs { get; set; }
    }
}
