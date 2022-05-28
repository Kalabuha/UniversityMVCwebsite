using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task20.Models;
using Task20.Services;
using Task20.WebAppMVC.Models;
using Task20.WebAppMVC.Models.SimpleModels;

namespace Task20.WebAppMVC.Controllers
{
    public class AboutROUController : Controller
    {
        private readonly CourseService _courseService;
        private readonly TeacherService _teacherService;

        public AboutROUController(CourseService courseService, TeacherService teacherService)
        {
            _courseService = courseService;
            _teacherService = teacherService;
        }

        // GET: AboutROUController
        //[HttpGet("")]
        public ActionResult Index()
        {
            var viewContainer = new AboutRouViewModel { CourseViewModels = new List<CourseViewModel>() };

            var courseModels = _courseService.GetAllCourseModels();
            for (int i = 0; i < courseModels.Count; i++)
            {
                var courseViewModel = new CourseViewModel();
                courseViewModel.Course = courseModels[i];

                var courseData = _courseService.GetGroupAndStudentNumberAsCourseDataById(courseModels[i].Id);
                if (courseData != null)
                {
                    courseViewModel.CourseData = courseData;
                    if (courseModels[i].LeaderId.HasValue)
                    {
                        courseViewModel.CourseData.CourseLeader =
                            _teacherService.GetTeacherModel(courseModels[i].LeaderId!.Value);
                    }
                }

                viewContainer.CourseViewModels.Add(courseViewModel);
            }

            return View(viewContainer);
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
