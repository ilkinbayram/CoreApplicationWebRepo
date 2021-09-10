using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    public class PhraseController : Controller
    {
        // GET: PhraseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PhraseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PhraseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhraseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhraseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PhraseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
