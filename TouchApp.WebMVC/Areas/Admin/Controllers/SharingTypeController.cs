using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SharingTypeController : Controller
    {
        // GET: SharingTypeController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: SharingTypeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: SharingTypeController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: SharingTypeController/Create
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

        // GET: SharingTypeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: SharingTypeController/Edit/5
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

        // GET: SharingTypeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: SharingTypeController/Delete/5
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
