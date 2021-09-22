using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfessionCourseCategoryController : Controller
    {
        // GET: ProfessionCourseCategoryController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: ProfessionCourseCategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: ProfessionCourseCategoryController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: ProfessionCourseCategoryController/Create
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

        // GET: ProfessionCourseCategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: ProfessionCourseCategoryController/Edit/5
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

        // GET: ProfessionCourseCategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: ProfessionCourseCategoryController/Delete/5
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
