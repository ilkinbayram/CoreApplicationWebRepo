using Core.Entities.Dtos.Blog;
using Core.Extensions;
using Core.Resources.Enums;
using Core.Utilities.UsableModel;
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
    public class BlogController : Controller
    {
        private IBlogService _blogService;
        private IBlogCategoryService _blogCategoryService;
        public BlogController(IBlogService blogService,
                              IBlogCategoryService blogCategoryService)
        {
            _blogService = blogService;
            _blogCategoryService = blogCategoryService;
        }

        // GET: BlogController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: BlogController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: BlogController/Create
        public async Task<ActionResult> Create()
        {
            var dtoModel = new CreateManagementBlogDto();

            dtoModel.ScreenTypeSelectList = Enum.GetValues<PostScreenType>().Cast<byte>().ToList().
                               Select(x => new SelectListItem
                               {
                                   Value = x.ToString(),
                                   Text = string.Format("{0}PostScreenType.Localize", ((PostScreenType)x).ToString()).Translate()
                               }).ToList();

            dtoModel.BlogCategoryList = (await _blogCategoryService.GetListAsync(x => x.IsActive == true)).Data.
                               Select(x => new SelectListItem
                               {
                                   Value = x.Id.ToString(),
                                   Text = x.NameKey.Translate()
                               }).ToList();

            return View(dtoModel);
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, CreateManagementBlogDto createModel)
        {
            var resultBlogService = _blogService.Add(createModel);

            if (resultBlogService != null)
            {
                if (resultBlogService.Success)
                {
                    var createBlogDtoModel = new CreateManagementBlogDto();

                    createBlogDtoModel.BlogCategoryList = (await _blogCategoryService.GetListAsync(x => x.IsActive == true)).Data.
                               Select(x => new SelectListItem
                               {
                                   Value = x.Id.ToString(),
                                   Text = x.NameKey.Translate()
                               }).ToList();

                    createBlogDtoModel.ResponseMessages.Add(new AlertResult { AlertColor = "success", AlertMessage = resultBlogService.Message });

                    return View(createBlogDtoModel);
                }
                else
                {
                    createModel.ResponseMessages.Add(new AlertResult { AlertColor = "danger", AlertMessage = resultBlogService.Message });

                    return View(createModel);
                }
            }

            return View("ServerErrorPage");
        }

        // GET: BlogController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: BlogController/Edit/5
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

        // GET: BlogController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: BlogController/Delete/5
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
