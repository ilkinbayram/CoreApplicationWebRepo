using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouchApp.WebMVC.Filters;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SimpleDefaultAdminAuthorizationFilter]
    public class ManagementController : AdminBaseController
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}
