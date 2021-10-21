using Core.Entities.Dtos.SocialMedia;
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
    public class SocialMediaController : AdminBaseController
    {
        private readonly ISocialMediaService _socialMediaService;
        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        // GET: SocialMediaController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: SocialMediaController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: SocialMediaController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var dtoModel = new CreateManagementSocialMediaDto();
            dtoModel.SocialMediaTypeList = Enum.GetValues<SocialMediaType>().Cast<byte>().ToList().
                               Select(x => new SelectListItem
                               {
                                   Value = x.ToString(),
                                   Text = string.Format("{0}SocialMediaType.Localize", ((SocialMediaType)x).ToString()).Translate()
                               }).ToList();

            return View(dtoModel);
        }

        // POST: SocialMediaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, CreateManagementSocialMediaDto createModel)
        {
            var resultSocial = _socialMediaService.Add(createModel);

            if (resultSocial != null)
            {
                if (resultSocial.Success)
                {
                    var createLangDtoModel = new CreateManagementSocialMediaDto();

                    createLangDtoModel.SocialMediaTypeList = Enum.GetValues<SocialMediaType>().Cast<byte>().ToList().
                   Select(x => new SelectListItem
                   {
                       Value = x.ToString(),
                       Text = string.Format("{0}SocialMediaType.Localize", ((SocialMediaType)x).ToString()).Translate()
                   }).ToList();

                    createLangDtoModel.ResponseMessages.Add(new AlertResult { AlertColor = "success", AlertMessages = resultSocial.Responses.Select(x=>x.Message).ToList() });

                    return View(createLangDtoModel);
                }
                else
                {
                    createModel.ResponseMessages.Add(new AlertResult { AlertColor = "danger", AlertMessages = resultSocial.Responses.Select(x=>x.Message).ToList() });

                    return View(createModel);
                }
            }

            return View("ServerErrorPage");
        }

        // GET: SocialMediaController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: SocialMediaController/Edit/5
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

        // GET: SocialMediaController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: SocialMediaController/Delete/5
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
