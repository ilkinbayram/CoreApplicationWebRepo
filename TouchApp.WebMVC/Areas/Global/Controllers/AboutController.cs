using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.WebMVC.Areas.Global.Models.ViewModel;
using TouchApp.WebMVC.Filters;

namespace TouchApp.WebMVC.Areas.Global.Controllers
{
    [Area("Global")]
    [LocalizationFilter]
    public class AboutController : Controller
    {
        private ITeacherService _teacherService;

        public AboutController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> Touch()
        {
            var aboutViewModel = new AboutViewModel
            {
                Teachers = _teacherService.GetDtoList().Data
            };
            return View(aboutViewModel);
        }
    }
}
