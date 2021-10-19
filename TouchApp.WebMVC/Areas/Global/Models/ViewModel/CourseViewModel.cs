using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.CourseComment;
using Core.Entities.Dtos.Teacher;
using System.Collections.Generic;

namespace TouchApp.WebMVC.Areas.Global.Models.ViewModel
{
    public class CourseViewModel
    {
        public GetCourseDto CurrentCourse { get; set; }
        public List<GetTeacherDto> CurrentCourseTeachers { get; set; }
        public List<GetCourseCommentDto> ActiveCommentsOfCurrentCourse { get; set; }
        public List<GetCourseDto> RecentCourses { get; set; }
    }
}
