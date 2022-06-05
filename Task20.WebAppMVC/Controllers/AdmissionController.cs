using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task20.Services;
using Task20.WebAppMVC.Models;
using Task20.WebAppMVC.Models.SimpleModels;
using Task20.Models;
using Task20.Services.Resources;

namespace Task20.WebAppMVC.Controllers
{
    public class AdmissionController : Controller
    {
        private readonly CourseService _courseService;
        private readonly GroupService _groupService;
        private readonly StudentService _studentService;

        public AdmissionController(CourseService courseService, GroupService groupService, StudentService studentService)
        {
            _courseService = courseService;
            _groupService = groupService;
            _studentService = studentService;
        }

        // GET: AdmissionController
        public ActionResult Index()
        {
            var viewContainer = new AdmissionViewModel
            {
                Groups = new List<GroupViewModel>()
            };

            var courseModels = _courseService.GetAllCourseModels();
            viewContainer.Courses = courseModels;
            for (int i = 0; i < courseModels.Count; i++)
            {
                var groupModels = _groupService.GetGroupModelsByCourseId(courseModels[i].Id);
                for (int j = 0; j < groupModels.Count; j++)
                {
                    var studentModels = _studentService.GetStudentModelsByGroupId(groupModels[j].Id);
                    viewContainer.Groups.Add(new GroupViewModel
                    {
                        Group = groupModels[j],
                        GroupData = new GroupData
                        {
                            StudentsAmount = studentModels.Count(),
                            Students = studentModels,
                        }
                    });
                }
            }

            return View(viewContainer);
        }

        // GET: AdmissionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult AddStudent(int groupId)
        {
            var groupModel = _groupService.GetGroupByGroupId(groupId);
            return View(groupModel);
        }

        // POST: AdmissionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddStudent(StudentModel studentModel)
        {
            bool isValidData = true;
            string? firstname = studentModel.Firstname?.Trim();
            string? middlename = studentModel.Middlename?.Trim();
            string? lastname = studentModel.Lastname?.Trim();

            string message = string.Empty;
            ValidateName(firstname, "first name");
            ValidateName(middlename, "middle name");
            ValidateName(lastname, "last name");
            ValidateDateBirth(studentModel.DateBirth);
            var group = ValidateGroupId(studentModel.GroupId);
            message = PrepareMessage(message);

            if (isValidData && group != null)
            {
                await _studentService.EnterIntoDbNewStudentAsync(studentModel);
                return RedirectToAction(nameof(AddStudentConfirm), new { nameGroup = group.Name, numberGroup = group.Description });
            }
            else
            {
                return RedirectToAction(nameof(AddStudentFail), new { message = message });
            }

            // local methods
            void ValidateName(string? name, string nameType)
            {
                if (string.IsNullOrEmpty(name))
                {
                    message = MessageDidNotEnter(nameType, message);
                    isValidData = false;
                    return;
                }
                else if (name.Length < 3)
                {
                    message = MessageEnteredTooShort(nameType, message);
                    isValidData = false;
                }

                foreach (var oneChar in name)
                {
                    if (!char.IsLetter(oneChar))
                    {
                        message = MessageContainsInvalidCharacters(nameType, message);
                        isValidData = false;
                        break;
                    }
                }
            }

            string MessageDidNotEnter(string nameType, string text)
            {
                text = ShouldAddComma(text);
                return text + $"you didn't enter your {nameType}";
            }

            string MessageEnteredTooShort(string nameType, string text)
            {
                text = ShouldAddComma(text);
                return text + $"you entered too short {nameType}";
            }

            string MessageContainsInvalidCharacters(string nameType, string text)
            {
                text = ShouldAddComma(text);
                return text + $"your {nameType} contains invalid characters";
            }

            string ShouldAddComma(string text)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    return text + ", ";
                }
                return text;
            }

            void ValidateDateBirth(DateTime dateBirth)
            {
                var zeroTime = new DateTime(1, 1, 1);
                var dateNow = DateTime.Now;

                var timeDifference = dateNow - dateBirth;
                int studentAge = (zeroTime + timeDifference).Year - 1;

                if (studentAge < 18)
                {
                    message = MessageTooYoung(message);
                    isValidData = false;
                }
                else if (studentAge > 70)
                {
                    message = MessageTooOld(message);
                    isValidData = false;
                }
            }

            string MessageTooYoung(string text)
            {
                text = ShouldAddComma(text);
                return text + "we are very sorry, but you are too young to enter our university. Come back a little later";
            }

            string MessageTooOld(string text)
            {
                text = ShouldAddComma(text);
                return text + "we are very sorry, but you are too old to enter our university";
            }

            GroupModel? ValidateGroupId(int id)
            {
                var group = _groupService.GetGroupByGroupId(id);
                if (group == null)
                {
                    message = MessageGroupNotFound(message);
                    isValidData = false;
                }
                return group;
            }

            string MessageGroupNotFound(string text)
            {
                text = ShouldAddComma(text);
                return text + "the group you selected could not be found";
            }

            string PrepareMessage(string text)
            {
                if (string.IsNullOrEmpty(text.Trim()))
                {
                    return string.Empty;
                }
                text = text[0].ToString().ToUpper() + text.Substring(1) + ".";
                return text;
            }
        }

        public ActionResult AddStudentConfirm(string nameGroup, string numberGroup)
        {
            var messageVM = new MessageViewModel
            {
                MessageText = $"Congratulations, you have been accepted to our university. Now you will study in group {nameGroup} {numberGroup}"
            };

            return View(messageVM);
        }

        public ActionResult AddStudentFail(string message)
        {
            var messageVM = new MessageViewModel
            {
                MessageText = message
            };

            return View(messageVM);
        }

        // GET: AdmissionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdmissionController/Edit/5
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

        // GET: AdmissionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdmissionController/Delete/5
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
