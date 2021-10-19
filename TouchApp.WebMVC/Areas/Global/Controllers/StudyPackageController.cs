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
    public class StudyPackageController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IProfessionCourseCategoryService _courseCategoryService;
        private readonly IBlogService _blogService;
        public StudyPackageController(ICourseService courseService,
                                      IProfessionCourseCategoryService courseCategoryService,
                                      IBlogService blogService)
        {
            _courseService = courseService;
            _courseCategoryService = courseCategoryService;
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> Touch()
        {
            var viewModel = new AllCoursesViewModel();
            viewModel.AllCourses = _courseService.GetDtoList().Data;
            viewModel.CourseCategories = _courseCategoryService.GetListDto().Data;
            viewModel.RecentBlogs = _blogService.GetDtoList().Data.OrderByDescending(x => x.Created_at).Take(10).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrent(long id)
        {
            var viewModel = new CourseViewModel();
            var currentCourse = _courseService.GetDtoForGlobalView(x => x.Id == id).Data;
            viewModel.CurrentCourse = currentCourse;
            viewModel.CurrentCourseTeachers = currentCourse.TeacherCourses.Select(x => x.Teacher).ToList();
            viewModel.RecentCourses = _courseService.GetDtoList().Data.OrderByDescending(x => x.Created_at).Take(10).ToList();
            viewModel.ActiveCommentsOfCurrentCourse = currentCourse.CourseComments;

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> FilterByCourseCategoryId(long id)
        {
            var viewModel = new AllCoursesViewModel();
            viewModel.AllCourses = _courseService.GetFilteredCoursesByCourseCategoryId(id).Data;
            viewModel.CourseCategories = _courseCategoryService.GetListDto().Data;
            viewModel.RecentBlogs = _blogService.GetDtoList().Data.OrderByDescending(x => x.Created_at).Take(10).ToList();

            return View("Touch", viewModel);
        }
    }
}
