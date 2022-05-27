using Task20.Models;
using Task20.Services.Resources;

namespace Task20.WebAppMVC.Models
{
    public class CourseViewModel
    {
        public CourseModel Course { get; set; } = default!;
        public CourseData? CourseData { get; set; } = default!;
    }
}
