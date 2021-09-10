using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TouchApp.WebMVC.Areas.Admin.Controllers
{
    public class ProfessionCourseCategoryController : Controller
    {
        // GET: ProfessionCourseCategoryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProfessionCourseCategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfessionCourseCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfessionCourseCategoryController/Create
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

        // GET: ProfessionCourseCategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfessionCourseCategoryController/Edit/5
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

        // GET: ProfessionCourseCategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfessionCourseCategoryController/Delete/5
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
