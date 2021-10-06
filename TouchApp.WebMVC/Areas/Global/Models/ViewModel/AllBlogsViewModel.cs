using Core.Entities.Dtos.Blog;
using Core.Entities.Dtos.BlogCategory;
using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.Tag;
using System.Collections.Generic;

namespace TouchApp.WebMVC.Areas.Global.Models.ViewModel
{
    public class AllBlogsViewModel
    {
        public List<GetBlogDto> AllBlogs { get; set; }
        public List<GetTagDto> Tags { get; set; }
        public List<GetCourseDto> RecentCourses { get; set; }
        public List<GetBlogCategoryDto> BlogCategories { get; set; }
    }
}
