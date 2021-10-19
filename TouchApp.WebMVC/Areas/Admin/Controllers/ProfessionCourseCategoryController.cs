using Core.Entities.Dtos.ProfessionCourseCategory;
using Core.Extensions;
using Core.Utilities.UsableModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfessionCourseCategoryController : Controller
    {
        private readonly IProfessionCourseCategoryService _professionCourseCategoryService;
        public ProfessionCourseCategoryController(IProfessionCourseCategoryService professionCourseCategoryService)
        {
            _professionCourseCategoryService = professionCourseCategoryService;
        }

        // GET: ProfessionCourseCategoryController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: ProfessionCourseCategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: ProfessionCourseCategoryController/Create
        public async Task<ActionResult> Create()
        {
            var model = new CreateManagementProfessionCourseCategoryDto();

            var resultBlogCatList = _professionCourseCategoryService.GetList(x => x.IsActive).Data;

            model.ParentProfessionCourseCategories = resultBlogCatList != null ? resultBlogCatList.Select(x =>
                        new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.NameKey.Translate()
                        }).ToList() : new System.Collections.Generic.List<SelectListItem>();

            return View(model);
        }

        // POST: ProfessionCourseCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, CreateManagementProfessionCourseCategoryDto createModel)
        {
            var resultProfessionCourseService = _professionCourseCategoryService.Add(createModel);

            if (resultProfessionCourseService != null)
            {
                if (resultProfessionCourseService.Success)
                {
                    var createProfessionCourseDtoModel = new CreateManagementProfessionCourseCategoryDto();

                    var resultProfessionCourseCatList = _professionCourseCategoryService.GetList(x => x.IsActive).Data;

                    createProfessionCourseDtoModel.ParentProfessionCourseCategories = resultProfessionCourseCatList != null ? resultProfessionCourseCatList.Select(x =>
                                new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.NameKey.Translate()
                                }).ToList() : new System.Collections.Generic.List<SelectListItem>();

                    createProfessionCourseDtoModel.ResponseMessages.Add(new AlertResult { AlertColor = "success", AlertMessage = resultProfessionCourseService.Message });

                    return View(createProfessionCourseDtoModel);
                }
                else
                {
                    createModel.ResponseMessages.Add(new AlertResult { AlertColor = "danger", AlertMessage = resultProfessionCourseService.Message });

                    return View(createModel);
                }
            }

            return View("ServerErrorPage");
        }

        // GET: ProfessionCourseCategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: ProfessionCourseCategoryController/Edit/5
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

        // GET: ProfessionCourseCategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: ProfessionCourseCategoryController/Delete/5
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
