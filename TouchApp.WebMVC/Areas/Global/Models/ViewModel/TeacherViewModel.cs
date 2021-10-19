using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Areas.Global.Models.ViewModel
{
    public class TeacherViewModel
    {
        public GetTeacherDto CurrentTeacher { get; set; }
        public List<GetCourseDto> TeacherCourses { get; set; }
    }
}
