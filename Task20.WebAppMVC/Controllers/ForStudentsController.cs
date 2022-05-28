using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task20.Services;
using Task20.WebAppMVC.Models;
using Task20.WebAppMVC.Models.SimpleModels;

namespace Task20.WebAppMVC.Controllers
{
    public class ForStudentsController : Controller
    {
        private readonly GroupService _groupService;
        private readonly TeacherService _teacherService;

        public ForStudentsController(TeacherService teacherService, GroupService groupService)
        {
            _teacherService = teacherService;
            _groupService = groupService;
        }

        // GET: ForStudentsController
        public ActionResult Index()
        {
            var viewContainer = new ForStudentsViewModel { GroupViewModels = new List<GroupViewModel>() };
            var groupModels = _groupService.GetAllGroupModels();

            for (int i = 0; i < groupModels.Count; i++)
            {
                var groupViewModel = new GroupViewModel();
                groupViewModel.Group = groupModels[i];

                var groupData = _groupService.GetStudentNumberAsGroupDataById(groupModels[i].Id);
                if (groupData != null)
                {
                    groupViewModel.GroupData = groupData;
                    if (groupModels[i].LeaderId.HasValue)
                    {
                        groupViewModel.GroupData.GroupLeader = 
                            _teacherService.GetTeacherModel(groupModels[i].LeaderId!.Value);
                    }
                }

                viewContainer.GroupViewModels.Add(groupViewModel);
            }

            viewContainer.Teachers = _teacherService.GetAllTeacherModels();

            return View(viewContainer);
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
