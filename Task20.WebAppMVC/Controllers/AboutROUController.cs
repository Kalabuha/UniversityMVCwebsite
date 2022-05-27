using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task20.Services.AboutROUService;
using Task20.WebAppMVC.Models;

namespace Task20.WebAppMVC.Controllers
{
    public class AboutROUController : Controller
    {
        private readonly CourseService _courseService;
        public AboutROUController(CourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: AboutROUController
        //[HttpGet("")]
        public ActionResult Index()
        {
            var courseViewModels = new List<CourseViewModel>();
            var courseModels = _courseService.GetAllCourses();

            for (int i = 0; i < courseModels.Count; i++)
            {
                courseViewModels.Add(new CourseViewModel
                {
                    Course = courseModels[i],
                    CourseData = _courseService.GetCourseDataById(courseModels[i].Id)
                });
            }

            return View(courseViewModels);
        }

        // GET: AboutROUController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AboutROUController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutROUController/Create
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

        // GET: AboutROUController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AboutROUController/Edit/5
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

        // GET: AboutROUController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AboutROUController/Delete/5
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
