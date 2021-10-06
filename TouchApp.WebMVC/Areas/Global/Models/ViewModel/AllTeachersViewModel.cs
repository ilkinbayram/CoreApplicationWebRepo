using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.Teacher;
using System.Collections.Generic;

namespace TouchApp.WebMVC.Areas.Global.Models.ViewModel
{
    public class AllTeachersViewModel
    {
        public List<GetTeacherDto> AllTeachers { get; set; }
        public List<GetCourseDto> RecentCourses { get; set; }
    }
}
