using Core.Entities.Dtos.Teacher;
using Core.Entities.Dtos.TeacherSocialMedia;
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
    public class TeacherController : AdminBaseController
    {

        private ITeacherService _teacherService;
        private ISocialMediaService _socialMediaService;

        public TeacherController(ITeacherService teacherService,
                                 ISocialMediaService socialMediaService)
        {
            _teacherService = teacherService;
            _socialMediaService = socialMediaService;
        }

        // GET: TeacherController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: TeacherController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: TeacherController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var dtoModel = new CreateManagementTeacherDto();

            dtoModel.GenderSelectList = Enum.GetValues<Gender>().Cast<byte>().ToList().
                               Select(x => new SelectListItem
                               {
                                   Value = x.ToString(),
                                   Text = string.Format("{0}Gender.Localize", ((Gender)x).ToString()).Translate()
                               }).ToList();

            dtoModel.ProfessionDegreeSelectList = Enum.GetValues<ProfessionDegree>().Cast<byte>().ToList().
                               Select(x => new SelectListItem
                               {
                                   Value = x.ToString(),
                                   Text = string.Format("{0}ProfessionDegree.Localize", ((ProfessionDegree)x).ToString()).Translate()
                               }).ToList();
            var socialMedias = _socialMediaService.GetDtoList().Data;
            if (socialMedias != null && socialMedias.Count > 0)
            {
                dtoModel.SocialMedias = socialMedias;
                dtoModel.TeacherSocialMedias = new System.Collections.Generic.List<CreateManagementTeacherSocialMediaDto>();
                foreach (var socialOne in socialMedias)
                {
                    dtoModel.TeacherSocialMedias.Add(new CreateManagementTeacherSocialMediaDto
                    {
                        SocialMediaId = socialOne.Id
                    });
                }
                
            }
                

            return View(dtoModel);
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, CreateManagementTeacherDto createModel)
        {
            var resultTeacherService = _teacherService.Add(createModel);

            if (resultTeacherService != null)
            {
                if (resultTeacherService.Success)
                {
                    var createTeacherDtoModel = new CreateManagementTeacherDto();

                    createTeacherDtoModel.GenderSelectList = Enum.GetValues<Gender>().Cast<byte>().ToList().
                               Select(x => new SelectListItem
                               {
                                   Value = x.ToString(),
                                   Text = string.Format("{0}Gender.Localize", ((Gender)x).ToString()).Translate()
                               }).ToList();

                    createTeacherDtoModel.ProfessionDegreeSelectList = Enum.GetValues<ProfessionDegree>().Cast<byte>().ToList().
                                       Select(x => new SelectListItem
                                       {
                                           Value = x.ToString(),
                                           Text = string.Format("{0}ProfessionDegree.Localize", ((ProfessionDegree)x).ToString()).Translate()
                                       }).ToList();
                    var socialMedias = (await _socialMediaService.GetDtoListAsync()).Data;
                    if (socialMedias != null && socialMedias.Count > 0)
                        createTeacherDtoModel.SocialMedias = socialMedias;

                    createTeacherDtoModel.ResponseMessages.Add(new AlertResult { AlertColor = "success", AlertMessages = resultTeacherService.Responses.Select(x=>x.Message).ToList() });

                    return View(createTeacherDtoModel);
                }
                else
                {
                    createModel.ResponseMessages.Add(new AlertResult { AlertColor = "danger", AlertMessages = resultTeacherService.Responses.Select(x=>x.Message).ToList() });

                    return View(createModel);
                }
            }

            return View("ServerErrorPage");
        }

        // GET: TeacherController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: TeacherController/Edit/5
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

        // GET: TeacherController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: TeacherController/Delete/5
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
