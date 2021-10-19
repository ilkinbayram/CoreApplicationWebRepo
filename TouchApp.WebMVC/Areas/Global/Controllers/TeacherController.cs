using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.WebMVC.Areas.Global.Models.ViewModel;
using TouchApp.WebMVC.Filters;

namespace TouchApp.WebMVC.Areas.Global.Controllers
{
    [Area("Global")]
    [LocalizationFilter]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;
        public TeacherController(ITeacherService teacherService,
                                 ICourseService courseService)
        {
            _teacherService = teacherService;
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> Touch()
        {
            var viewModel = new AllTeachersViewModel();
            viewModel.AllTeachers = _teacherService.GetDtoList().Data;
            viewModel.RecentCourses = _courseService.GetDtoList().Data.OrderByDescending(x => x.Created_at).Take(10).ToList();
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrent(long id)
        {
            var viewModel = new TeacherViewModel();
            var currentTeacher = _teacherService.GetDto(x => x.Id == id).Data;
            viewModel.CurrentTeacher = currentTeacher;
            viewModel.TeacherCourses = currentTeacher.TeacherCourses.Select(x => x.Course).ToList();

            return View(viewModel);
        }
    }
}
