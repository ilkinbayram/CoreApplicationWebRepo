﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Dtos.BlogCategory;
using TouchApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Utilities.UsableModel;
using Core.Extensions;

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

            var resultBlogCatList = _blogCategoryService.GetList(x=>x.IsActive).Data;

            model.ParentBlogCategories = resultBlogCatList != null ? resultBlogCatList.Select(x =>
                        new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.NameKey.Translate()
                        }).ToList() : new System.Collections.Generic.List<SelectListItem>();

            return View(model);
        }

        // POST: BlogCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, CreateBlogCategoryManagementDto createModel)
        {
            var resultBlogService = _blogCategoryService.Add(createModel);

            if (resultBlogService != null)
            {
                if (resultBlogService.Success)
                {
                    var createBlogDtoModel = new CreateBlogCategoryManagementDto();

                    var resultBlogCatList = _blogCategoryService.GetList(x => x.IsActive).Data;

                    createBlogDtoModel.ParentBlogCategories = resultBlogCatList != null ? resultBlogCatList.Select(x =>
                                new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.NameKey.Translate()
                                }).ToList() : new System.Collections.Generic.List<SelectListItem>();

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
