using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task20.WebAppMVC.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: AdministrationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdministrationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdministrationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministrationController/Create
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

        // GET: AdministrationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdministrationController/Edit/5
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

        // GET: AdministrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdministrationController/Delete/5
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
