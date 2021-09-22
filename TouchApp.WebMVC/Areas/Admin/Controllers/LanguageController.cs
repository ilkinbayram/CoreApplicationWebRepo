using Core.Entities.Dtos.Language;
using Core.ViewUsableModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LanguageController : Controller
    {

        private ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        // GET: LanguageController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: LanguageController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: LanguageController/Create
        public async Task<ActionResult> Create()
        {
            try
            {
                var createLangDtoModel = new CreateManagementLanguageDto();

                return View(createLangDtoModel);
            }
            catch (System.Exception)
            {
                return View("ServerErrorPage");
            }
            
        }

        // POST: LanguageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, CreateManagementLanguageDto createModel)
        {
            var resultLang = _languageService.Add(createModel);

            if (resultLang != null)
            {
                if (resultLang.Success)
                {
                    var createLangDtoModel = new CreateManagementLanguageDto();
                    createLangDtoModel.ResponseMessages.Add(new AlertResult { AlertColor = "success", AlertMessage = resultLang.Message });

                    return View(createLangDtoModel);
                }
                else
                {
                    createModel.ResponseMessages.Add(new AlertResult { AlertColor = "danger", AlertMessage = resultLang.Message });

                    return View(createModel);
                }
            }

            return View("ServerErrorPage");
        }

        // GET: LanguageController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: LanguageController/Edit/5
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

        // GET: LanguageController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: LanguageController/Delete/5
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
