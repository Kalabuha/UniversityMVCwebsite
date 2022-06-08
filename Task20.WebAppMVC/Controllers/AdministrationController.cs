using Microsoft.AspNetCore.Mvc;
using Task20.ServicesApi;
using Task20.WebAppMVC.Models;
using Task20.Models;
using Task20.ApiModels;

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
            var viewContainer = new AdministrationViewModel();

            try
            {
                var courses = await _courseServiceApi.GetAllCourseModelsAsync();
                var groups = await _groupServiceApi.GetAllGroupModelsAsync();

                viewContainer.Courses = courses;
                viewContainer.Groups = groups;
            }
            catch (Exception)
            {
                viewContainer = null;
            }

            return View(viewContainer);
        }


        // GET: AdministrationController/AddGroup
        [HttpGet]
        public ActionResult AddGroup(int courseId)
        {
            var group = new GroupModel
            {
                CourseId = courseId,
            };

            ViewBag.NameNotCorrect = "*";
            ViewBag.DescrNotCorrect = "*";

            return View(group);
        }

        // POST: AdministrationController/AddGroup
        [HttpPost]
        public async Task<ActionResult> AddGroup(GroupModel group)
        {
            bool isDataValid = true;
            string errorNameMessage;
            string errorDescMessage;

            (isDataValid, errorNameMessage) = IsNameValid(group.Name);
            (isDataValid, errorDescMessage) = IsDescValid(group.Description);

            if (!isDataValid)
            {
                return RedirectToAction(nameof(AddGroup), new { courseId = group.CourseId });
            }

            var creator = new GroupCreator
            {
                CourseId = group.CourseId,
                Name = group.Name,
                Description = group.Description,
                LeaderId = group.LeaderId != 0 ? group.LeaderId : null,
            };

            await _groupServiceApi.CraeteGroupAsync(creator);
            return RedirectToAction(nameof(Index));
        }

        // GET: AdministrationController/UpdateGroup/id
        public async Task<ActionResult> UpdateGroup(int groupId)
        {
            var group = await _groupServiceApi.GetGroupModelByGroupIdAsync(groupId);
            if (group == null)
            {
                return NotFound();
            }

            ViewBag.NameNotCorrect = "*";
            ViewBag.DescrNotCorrect = "*";

            return View(group);
        }

        // POST: AdministrationController/UpdateGroup/id
        [HttpPost]
        public async Task<ActionResult> UpdateGroup(GroupModel group)
        {
            var updater = new GroupUpdater
            {
                CourseId = group.CourseId,
                Name = IsTextNotNullOrEmptyOrWhiteSpaceCheck(group.Name) ? group.Name : null,
                Description = IsTextNotNullOrEmptyOrWhiteSpaceCheck(group.Description) ? group.Description : null,
                LeaderId = group.LeaderId
            };

            await _groupServiceApi.UpdateGroupByGroupIdAsync(group.Id, updater);
            return RedirectToAction(nameof(Index));
        }

        // GET: AdministrationController/DeleteGroup
        public async Task<ActionResult> DeleteGroup(int groupId)
        {
            var group = await _groupServiceApi.GetGroupModelByGroupIdAsync(groupId);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // POST: AdministrationController/DeleteGroup
        [HttpPost]
        public async Task<ActionResult> DeleteGroupСonfirm(int groupId)
        {
            await _groupServiceApi.DeleteGroupByGroupIdAsync(groupId);
            return RedirectToAction(nameof(Index));
        }

        private (bool, string) IsNameValid(string name)
        {
            string errorMessage;
            if (IsTextNotNullOrEmptyOrWhiteSpaceCheck(name))
            {
                if (IsTextNotExceedMaxLength(name, 50))
                {
                    errorMessage = " ";
                }
                else
                {
                    errorMessage = "Group name must not exceed 50 characters.";
                    return (false, errorMessage);
                }
            }
            else
            {
                errorMessage = "Group name cannot be empty.";
                return (false, errorMessage);
            }

            return (true, errorMessage);
        }

        private (bool, string) IsDescValid(string desc)
        {
            string errorMessage;
            if (IsTextNotNullOrEmptyOrWhiteSpaceCheck(desc))
            {
                if (IsTextNotExceedMaxLength(desc, 300))
                {
                    errorMessage = " ";
                }
                else
                {
                    errorMessage = "Group description must not exceed 300 characters.";
                    return (false, errorMessage);
                }
            }
            else
            {
                errorMessage = "Group description cannot be empty.";
                return (false, errorMessage);
            }

            return(true, errorMessage);
        }

        private bool IsTextNotNullOrEmptyOrWhiteSpaceCheck(string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return true;
        }

        private bool IsTextNotExceedMaxLength(string text, int textMaxLength)
        {
            if (text.Length > textMaxLength)
            {
                return false;
            }

            return true;
        }

    }
}
