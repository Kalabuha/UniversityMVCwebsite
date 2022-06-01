using Task20.Models;
using Task20.WebAppMVC.Models.SimpleModels;

namespace Task20.WebAppMVC.Models
{
    public class AdmissionViewModel
    {
        public List<CourseModel>? Courses { get; set; } = default!;
        public List<GroupViewModel>? Groups { get; set; } = default!;
    }
}
