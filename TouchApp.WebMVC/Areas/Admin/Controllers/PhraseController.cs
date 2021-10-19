using Core.Entities.Dtos.Phrase;
using Core.Utilities.UsableModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhraseController : Controller
    {
        private readonly IPhraseService _phraseService;
        public PhraseController(IPhraseService phraseService)
        {
            _phraseService = phraseService;
        }

        // GET: PhraseController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: PhraseController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: PhraseController/Create
        public async Task<ActionResult> Create()
        {
            var model = new CreateManagementPhraseDto();
            return View(model);
        }

        // POST: PhraseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, CreateManagementPhraseDto createModel)
        {
            var resulPhraseService = _phraseService.Add(createModel);

            if (resulPhraseService != null)
            {
                if (resulPhraseService.Success)
                {
                    var createLocalizationDtoModel = new CreateManagementPhraseDto();
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

        // GET: PhraseController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: PhraseController/Edit/5
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

        // GET: PhraseController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: PhraseController/Delete/5
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
