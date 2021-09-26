﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouchApp.WebMVC.Filters;

namespace TouchApp.WebMVC.Areas.Global.Controllers
{
    [Area("Global")]
    [LocalizationFilter]
    public class ExamController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Touch()
        {
            return View();
        }
    }
}