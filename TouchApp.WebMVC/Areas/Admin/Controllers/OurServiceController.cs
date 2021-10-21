using Core.Entities.Dtos.OurService;
using Core.Utilities.UsableModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.WebMVC.Filters;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SimpleDefaultAdminAuthorizationFilter]
    public class OurServiceController : Controller
    {
        private readonly ICourseServiceService _courseServiceService;

        public OurServiceController(ICourseServiceService courseServiceService)
        {
            _courseServiceService = courseServiceService;
        }
        // GET: OurServiceController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: OurServiceController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: OurServiceController/Create
        public async Task<ActionResult> Create()
        {
            var model = new CreateManagementCourseServiceDto();
            return View(model);
        }

        // POST: OurServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, CreateManagementCourseServiceDto createModel)
        {
            var resultCourseServiceService = _courseServiceService.Add(createModel);

            if (resultCourseServiceService != null)
            {
                if (resultCourseServiceService.Success)
                {
                    var createLocalizationDtoModel = new CreateManagementCourseServiceDto();
                    createLocalizationDtoModel.ResponseMessages.Add(new AlertResult { AlertColor = "success", AlertMessages = resultCourseServiceService.Responses.Select(x=>x.Message).ToList() });

                    return View(createLocalizationDtoModel);
                }
                else
                {
                    createModel.ResponseMessages.Add(new AlertResult { AlertColor = "danger", AlertMessages = resultCourseServiceService.Responses.Select(x=>x.Message).ToList() });

                    return View(createModel);
                }
            }

            return View("ServerErrorPage");
        }

        // GET: OurServiceController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: OurServiceController/Edit/5
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

        // GET: OurServiceController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: OurServiceController/Delete/5
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
