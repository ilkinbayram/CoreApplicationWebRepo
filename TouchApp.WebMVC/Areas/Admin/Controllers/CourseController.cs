using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        // GET: CourseController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: CourseController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: CourseController/Create
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

        // GET: CourseController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
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

        // GET: CourseController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
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
