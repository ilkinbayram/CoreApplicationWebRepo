using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OurServiceController : Controller
    {
        // GET: OurServiceController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: OurServiceController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: OurServiceController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: OurServiceController/Create
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

        // GET: OurServiceController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: OurServiceController/Edit/5
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

        // GET: OurServiceController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: OurServiceController/Delete/5
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
