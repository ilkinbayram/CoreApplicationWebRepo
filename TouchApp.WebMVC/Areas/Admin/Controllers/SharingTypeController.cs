using Core.Entities.Dtos.SharingType;
using Core.Utilities.UsableModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SharingTypeController : Controller
    {
        private readonly ISharingTypeService _sharingTypeService;

        public SharingTypeController(ISharingTypeService sharingTypeService)
        {
            _sharingTypeService = sharingTypeService;
        }

        // GET: SharingTypeController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: SharingTypeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: SharingTypeController/Create
        public async Task<ActionResult> Create()
        {
            var model = new CreateManagementSharingTypeDto();
            return View(model);
        }

        // POST: SharingTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, CreateManagementSharingTypeDto createModel)
        {
            var resulPhraseService = _sharingTypeService.Add(createModel);

            if (resulPhraseService != null)
            {
                if (resulPhraseService.Success)
                {
                    var createLocalizationDtoModel = new CreateManagementSharingTypeDto();
                    createLocalizationDtoModel.ResponseMessages.Add(new AlertResult { AlertColor = "success", AlertMessage = resulPhraseService.Message });

                    return View(createLocalizationDtoModel);
                }
                else
                {
                    createModel.ResponseMessages.Add(new AlertResult { AlertColor = "danger", AlertMessage = resulPhraseService.Message });

                    return View(createModel);
                }
            }

            return View("ServerErrorPage");
        }

        // GET: SharingTypeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: SharingTypeController/Edit/5
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

        // GET: SharingTypeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: SharingTypeController/Delete/5
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
