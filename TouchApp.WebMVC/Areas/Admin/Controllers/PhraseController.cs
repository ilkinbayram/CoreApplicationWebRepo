using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhraseController : Controller
    {
        // GET: PhraseController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: PhraseController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: PhraseController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: PhraseController/Create
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

        // GET: PhraseController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: PhraseController/Edit/5
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

        // GET: PhraseController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: PhraseController/Delete/5
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
