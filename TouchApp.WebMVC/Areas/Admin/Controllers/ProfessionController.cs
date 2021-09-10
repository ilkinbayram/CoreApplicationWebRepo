using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    public class ProfessionController : Controller
    {
        // GET: ProfessionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProfessionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfessionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfessionController/Create
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

        // GET: ProfessionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfessionController/Edit/5
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

        // GET: ProfessionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfessionController/Delete/5
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
