using Core.Utilities.Helpers.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace TouchApp.WebMVC.Areas.Global.Controllers
{
    [Area("Global")]
    public class SmpCredController : Controller
    {
        private readonly ISessionStorageHelper _sessionStorageHelper;

        public SmpCredController(ISessionStorageHelper sessionStorageHelper)
        {
            _sessionStorageHelper = sessionStorageHelper;
        }

        [HttpGet]
        public IActionResult SetCred()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetCred(string crd)
        {
            if (crd == "8833def")
            {
                _sessionStorageHelper.Set("IsAdmin", "true", 15);
            }
            return RedirectToAction("TouchIndex", "Home", new { area = "Global" });
        }

        [HttpGet]
        public IActionResult TrCred()
        {
            _sessionStorageHelper.Remove("IsAdmin");
            return RedirectToAction("TouchIndex","Home", new { area = "Global"});
        }
    }
}
