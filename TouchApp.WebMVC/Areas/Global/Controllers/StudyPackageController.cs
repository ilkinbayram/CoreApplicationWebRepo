using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouchApp.WebMVC.Filters;

namespace TouchApp.WebMVC.Areas.Global.Controllers
{
    [Area("Global")]
    [LocalizationFilter]
    public class StudyPackageController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Touch()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrent(long id)
        {
            return View();
        }
    }
}
