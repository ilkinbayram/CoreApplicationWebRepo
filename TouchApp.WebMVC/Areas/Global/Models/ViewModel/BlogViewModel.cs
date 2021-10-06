using Core.Entities.Dtos.Blog;
using Core.Entities.Dtos.BlogCategory;
using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.Tag;
using System.Collections.Generic;

namespace TouchApp.WebMVC.Areas.Global.Models.ViewModel
{
    public class BlogViewModel
    {
        public GetBlogDto CurrentBlog { get; set; }
        public List<GetBlogDto> RelatedBlogs { get; set; }
        public List<GetTagDto> Tags { get; set; }
        public List<GetCourseDto> RecentCourses { get; set; }
        public List<GetBlogCategoryDto> BlogCategories { get; set; }
    }
}
