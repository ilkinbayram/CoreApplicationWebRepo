using System.Collections.Generic;
using Core.Entities.Dtos.Blog;
using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.Media;
using Core.Entities.Dtos.OurService;
using Core.Entities.Dtos.Phrase;
using Core.Entities.Dtos.Slider;
using Core.Entities.Dtos.Teacher;

namespace TouchApp.WebMVC.Areas.Global.Models.ViewModel
{
    public class HomeViewModel
    {
        public List<GetCourseServiceDto> CourseServices { get; set; }
        public List<GetSliderDto> Sliders { get; set; }
        public List<GetCourseDto> Courses { get; set; }
        public List<GetTeacherDto> Teachers { get; set; }
        public List<GetPhraseDto> Phrases { get; set; }
        public List<GetBlogDto> Blogs { get; set; }
        public List<GetMediaDto> Medias { get; set; }
    }
}
