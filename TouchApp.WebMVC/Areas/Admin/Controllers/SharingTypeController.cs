using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    public class SharingTypeController : Controller
    {
        // GET: SharingTypeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SharingTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SharingTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SharingTypeController/Create
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

        // GET: SharingTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SharingTypeController/Edit/5
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

        // GET: SharingTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SharingTypeController/Delete/5
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
