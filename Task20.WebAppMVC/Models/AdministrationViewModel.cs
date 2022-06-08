using Task20.Models;

namespace Task20.WebAppMVC.Models
{
    public class AdministrationViewModel
    {
        public List<CourseModel>? Courses { get; set; }
        public List<GroupModel>? Groups { get; set; }
    }
}
