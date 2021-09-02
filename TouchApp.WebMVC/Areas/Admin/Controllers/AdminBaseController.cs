using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBaseController : Controller
    {
        public AdminBaseController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> IndexManagement()
        {
            return View();
        }
    }
}
