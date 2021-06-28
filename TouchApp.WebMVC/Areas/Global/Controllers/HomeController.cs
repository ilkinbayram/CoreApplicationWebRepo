using Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Areas.Global.Controllers
{
    [Area("Global")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult TouchIndex()
        {
            return View();
        }



        #region OpenToGlobal
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Gallery()
        {
            return View();
        }

        [HttpGet]
        public IActionResult StudyPackage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TeachersInfo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BlogDetails()
        {
            return View();
        }
        #endregion
    }
}
