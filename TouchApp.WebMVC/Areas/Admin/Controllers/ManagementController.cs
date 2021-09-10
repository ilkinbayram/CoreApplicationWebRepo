using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManagementController : AdminBaseController
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}
