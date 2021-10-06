using Core.Entities.Dtos.Blog;
using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.ProfessionCourseCategory;
using System.Collections.Generic;

namespace TouchApp.WebMVC.Areas.Global.Models.ViewModel
{
    public class AllCoursesViewModel
    {
        public List<GetCourseDto> AllCourses { get; set; }
        public List<GetBlogDto> RecentBlogs { get; set; }
        public List<GetProfessionCourseCategoryDto> CourseCategories { get; set; }
    }
}
