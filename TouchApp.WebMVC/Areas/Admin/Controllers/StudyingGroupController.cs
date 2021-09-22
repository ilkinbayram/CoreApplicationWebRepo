using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudyingGroupController : Controller
    {
        // GET: StudyingGroupController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: StudyingGroupController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: StudyingGroupController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: StudyingGroupController/Create
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

        // GET: StudyingGroupController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: StudyingGroupController/Edit/5
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

        // GET: StudyingGroupController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: StudyingGroupController/Delete/5
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
