using Core.Entities.Dtos.BlogCategory;
using Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogCategoryController : Controller
    {
        private IBlogCategoryService _blogCategoryService;
        public BlogCategoryController(IBlogCategoryService blogCategoryService)
        {
            _blogCategoryService = blogCategoryService;
        }
        // GET: BlogCategoryController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: BlogCategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: BlogCategoryController/Create
        public async Task<ActionResult> Create()
        {
            var model = new CreateBlogCategoryManagementDto();
            var resultBlogCatList = (await _blogCategoryService.GetDtoListAsync(x=>x.IsActive)).Data;
            model.BlogCategories = resultBlogCatList.Select(x=> new BlogCategorySelectModel { Id = (int)x.Id, TranslateKey = x.NameKey.Translate()}).ToList() ?? new List<BlogCategorySelectModel>();
            return View(model);
        }

        // POST: BlogCategoryController/Create
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

        // GET: BlogCategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: BlogCategoryController/Edit/5
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

        // GET: BlogCategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: BlogCategoryController/Delete/5
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
