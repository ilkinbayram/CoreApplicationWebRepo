﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Areas.Global.Controllers
{
    public class StudyPackageController : Controller
    {
        [HttpGet]
        public IActionResult Touch()
        {
            return View();
        }
    }
}
