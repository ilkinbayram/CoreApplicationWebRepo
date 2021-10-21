using Core.Entities.Dtos.Media;
using Core.Extensions;
using Core.Resources.Enums;
using Core.Utilities.UsableModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using TouchApp.Business.Abstract;
using TouchApp.WebMVC.Filters;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SimpleDefaultAdminAuthorizationFilter]
    public class MediaGalleryController : Controller
    {
        private readonly IMediaService _mediaService;
        private readonly ISharingTypeService _sharingTypeService;
        public MediaGalleryController(IMediaService mediaService,
                                      ISharingTypeService sharingTypeService)
        {
            _mediaService = mediaService;
            _sharingTypeService = sharingTypeService;
        }

        // GET: MediaGalleryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MediaGalleryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MediaGalleryController/Create
        public ActionResult Create()
        {
            var media = new CreateManagementMediaDto();

            media.GivenDataesForSharingTypeIds = _sharingTypeService.GetDtoList().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.NameKey.Translate()
            }).ToList();

            media.MediaTypes = Enum.GetValues<MediaType>().Cast<byte>().ToList().
                   Select(x => new SelectListItem
                   {
                       Value = x.ToString(),
                       Text = string.Format("{0}MediaType.Localize", ((MediaType)x).ToString()).Translate()
                   }).ToList();

            return View(media);
        }

        // POST: MediaGalleryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, CreateManagementMediaDto createModel)
        {
            var resultBlogService = _mediaService.Add(createModel);

            if (resultBlogService != null)
            {
                if (resultBlogService.Success)
                {
                    var createBlogDtoModel = new CreateManagementMediaDto();

                    createBlogDtoModel.GivenDataesForSharingTypeIds = _sharingTypeService.GetDtoList().Data.Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.NameKey.Translate()
                    }).ToList();

                    createBlogDtoModel.MediaTypes = Enum.GetValues<MediaType>().Cast<byte>().ToList().Select(x => new SelectListItem
                    {
                        Value = x.ToString(),
                        Text = string.Format("{0}MediaType.Localize", ((MediaType)x).ToString()).Translate()
                    }).ToList();

                    createBlogDtoModel.ResponseMessages.Add(new AlertResult { AlertColor = "success", AlertMessages = resultBlogService.Responses.Select(x=>x.Message).ToList() });

                    return View(createBlogDtoModel);
                }
                else
                {
                    createModel.ResponseMessages.Add(new AlertResult { AlertColor = "danger", AlertMessages = resultBlogService.Responses.Select(x=>x.Message).ToList() });

                    return View(createModel);
                }
            }

            return View("ServerErrorPage");
        }

        // GET: MediaGalleryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MediaGalleryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: MediaGalleryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MediaGalleryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
