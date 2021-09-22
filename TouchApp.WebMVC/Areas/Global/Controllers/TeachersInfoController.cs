using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Areas.Global.Controllers
{
    [Area("Global")]
    public class TeachersInfoController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Touch()
        {
            return View();
        }
    }
}
