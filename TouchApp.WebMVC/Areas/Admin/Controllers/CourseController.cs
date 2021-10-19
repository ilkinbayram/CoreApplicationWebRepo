using Core.Entities.Dtos.Course;
using Core.Extensions;
using Core.Utilities.UsableModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.WebMVC.Filters;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SimpleDefaultAdminAuthorizationFilter]
    public class CourseController : Controller
    {

        private readonly ICourseService _courseService;
        private readonly IProfessionCourseCategoryService _professionCourseCategoryService;
        private readonly ITeacherService _teacherService;
        private readonly ILanguageService _languageService;
        public CourseController(ICourseService courseService,
                                IProfessionCourseCategoryService professionCourseCategoryService,
                                ITeacherService teacherService,
                                ILanguageService languageService)
        {
            _courseService = courseService;
            _professionCourseCategoryService = professionCourseCategoryService;
            _teacherService = teacherService;
            _languageService = languageService;
        }

        // GET: CourseController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: CourseController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public async Task<ActionResult> Create()
        {
            var dtoModel = new CreateManagementCourseDto();

            dtoModel.CurrentListTeachers = _teacherService.GetDtoList().Data.Select(x => new SelectListItem
            {
                Text = string.Format("{0} {1} / Profession is: {2}", x.FirstName, x.LastName, x.ProfessionNameKey.Translate()),
                Value = x.Id.ToString()
            }).ToList();

            dtoModel.CurrentListLanguageIds = _languageService.GetList().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.NameKey.Translate()
            }).ToList();

            dtoModel.CurrentListProfessionCourseCategoryIds = _professionCourseCategoryService.GetList().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.NameKey.Translate()
            }).ToList();

            return View(dtoModel);
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, CreateManagementCourseDto createModel)
        {
            var resultCourseService = _courseService.Add(createModel);

            if (resultCourseService != null)
            {
                if (resultCourseService.Success)
                {
                    var createCourseDtoModel = new CreateManagementCourseDto();

                    createCourseDtoModel.CurrentListTeachers = _teacherService.GetDtoList().Data.Select(x => new SelectListItem
                    {
                        Text = string.Format("{0} {1} / Profession is: {2}", x.FirstName, x.LastName, x.ProfessionNameKey.Translate()),
                        Value = x.Id.ToString()
                    }).ToList();

                    createCourseDtoModel.CurrentListLanguageIds = _languageService.GetList().Data.Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.NameKey.Translate()
                    }).ToList();

                    createCourseDtoModel.CurrentListProfessionCourseCategoryIds = _professionCourseCategoryService.GetList().Data.Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.NameKey.Translate()
                    }).ToList();

                    createCourseDtoModel.ResponseMessages.Add(new AlertResult { AlertColor = "success", AlertMessage = resultCourseService.Message });

                    return View(createCourseDtoModel);
                }
                else
                {
                    createModel.ResponseMessages.Add(new AlertResult { AlertColor = "danger", AlertMessage = resultCourseService.Message });

                    return View(createModel);
                }
            }

            return View("ServerErrorPage");
        }

        // GET: CourseController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
