using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task20.WebAppMVC.Controllers
{
    public class ForStudentsController : Controller
    {
        // GET: ForStudentsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ForStudentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ForStudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForStudentsController/Create
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

        // GET: ForStudentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ForStudentsController/Edit/5
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

        // GET: ForStudentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ForStudentsController/Delete/5
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
