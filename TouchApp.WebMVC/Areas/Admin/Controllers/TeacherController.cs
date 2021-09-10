using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : AdminBaseController
    {
        // GET: TeacherController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: TeacherController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: TeacherController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: TeacherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
