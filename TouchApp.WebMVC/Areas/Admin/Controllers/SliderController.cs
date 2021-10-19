using Core.Entities.Dtos.Slider;
using Core.Utilities.UsableModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        // GET: SliderController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: SliderController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: SliderController/Create
        public async Task<ActionResult> Create()
        {
            var model = new CreateManagementSliderDto();

            return View(model);
        }

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, CreateManagementSliderDto createModel)
        {
            var resultSliderService = _sliderService.Add(createModel);

            if (resultSliderService != null)
            {
                if (resultSliderService.Success)
                {
                    var createLocalizationDtoModel = new CreateManagementSliderDto();
                    createLocalizationDtoModel.ResponseMessages.Add(new AlertResult { AlertColor = "success", AlertMessage = resultSliderService.Message });

                    return View(createLocalizationDtoModel);
                }
                else
                {
                    createModel.ResponseMessages.Add(new AlertResult { AlertColor = "danger", AlertMessage = resultSliderService.Message });

                    return View(createModel);
                }
            }

            return View("ServerErrorPage");
        }

        // GET: SliderController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: SliderController/Edit/5
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

        // GET: SliderController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: SliderController/Delete/5
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
