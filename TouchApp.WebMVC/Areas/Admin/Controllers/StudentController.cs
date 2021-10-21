using Core.Entities.Dtos.Student;
using Core.Extensions;
using Core.Resources.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.WebMVC.Filters;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SimpleDefaultAdminAuthorizationFilter]
    public class StudentController : Controller
    {
        private ITeacherService _teacherService;
        private ICourseService _courseService;

        public StudentController(ITeacherService teacherService, ICourseService courseService)
        {
            _teacherService = teacherService;
            _courseService = courseService;
        }

        // GET: UserController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var dtoModel = new CreateManagementStudentDto();
            var teacherAsyncReq = _teacherService.GetListAsync();
            var courseAsyncReq = _courseService.GetListAsync();

            dtoModel.GenderSelectList = Enum.GetValues<Gender>().Cast<byte>().ToList().
                               Select(x => new SelectListItem
                               {
                                   Value = x.ToString(),
                                   Text = string.Format("{0}Gender.Localize", ((Gender)x).ToString()).Translate()
                               }).ToList();
            dtoModel.TeacherList = (await teacherAsyncReq).Data.
                               Select(x => new SelectListItem
                               {
                                   Value = x.Id.ToString(),
                                   Text = string.Format("{0} {1}",x.FirstName, x.LastName )
                               }).ToList();
            dtoModel.CourseList = (await courseAsyncReq).Data.
                               Select(x => new SelectListItem
                               {
                                   Value = x.Id.ToString(),
                                   Text = x.TitleKey.Translate()
                               }).ToList();


            return View(dtoModel);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
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

        // GET: UserController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
