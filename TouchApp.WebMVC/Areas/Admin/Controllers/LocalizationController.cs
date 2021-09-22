using Core.Entities.Dtos.Localization;
using Core.ViewUsableModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocalizationController : AdminBaseController
    {
        private ILocalizationService _localizationService;
        public LocalizationController(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        // GET: LocalizationController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: LocalizationController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: LocalizationController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            try
            {
                CreateLocalizationDto createModel = new CreateLocalizationDto();
                return View(createModel);
            }
            catch (System.Exception)
            {
                return View("ServerErrorPage");
            }
        }

        // POST: LocalizationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, CreateLocalizationDto createModel)
        {
            var resultLocalizationService = _localizationService.Add(createModel);

            if (resultLocalizationService != null)
            {
                if (resultLocalizationService.Success)
                {
                    var createLocalizationDtoModel = new CreateLocalizationDto();
                    createLocalizationDtoModel.ResponseMessages.Add(new AlertResult { AlertColor = "success", AlertMessage = resultLocalizationService.Message });

                    return View(createLocalizationDtoModel);
                }
                else
                {
                    createModel.ResponseMessages.Add(new AlertResult { AlertColor = "danger", AlertMessage = resultLocalizationService.Message });

                    return View(createModel);
                }
            }

            return View("ServerErrorPage");
        }

        // GET: LocalizationController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: LocalizationController/Edit/5
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

        // GET: LocalizationController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: LocalizationController/Delete/5
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
