using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : AdminBaseController
    {
        // GET: SocialMediaController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: SocialMediaController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: SocialMediaController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: SocialMediaController/Create
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

        // GET: SocialMediaController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: SocialMediaController/Edit/5
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

        // GET: SocialMediaController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: SocialMediaController/Delete/5
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
