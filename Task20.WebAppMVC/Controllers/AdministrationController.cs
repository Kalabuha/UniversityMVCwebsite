using Microsoft.AspNetCore.Mvc;
using Task20.ServicesApi;
using Task20.WebAppMVC.Models;

namespace Task20.WebAppMVC.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly CourseServiceApi _courseServiceApi;
        private readonly GroupServiceApi _groupServiceApi;

        public AdministrationController(CourseServiceApi courseServiceApi, GroupServiceApi groupServiceApi)
        {
            _courseServiceApi = courseServiceApi;
            _groupServiceApi = groupServiceApi;
        }

        // GET: AdministrationController
        public async Task<ActionResult> Index()
        {
            var courses = await _courseServiceApi.GetAllCourseModelsAsync();
            var groups = await _groupServiceApi.GetAllGroupModelsAsync();

            var viewContainer = new AdministrationViewModel();
            viewContainer.Courses = courses;
            viewContainer.Groups = groups;

            return View(viewContainer);
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
