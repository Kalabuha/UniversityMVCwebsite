using Task20.Models;
using Task20.WebAppMVC.Models.SimpleModels;

namespace Task20.WebAppMVC.Models
{
    public class ForStudentsViewModel
    {
        public List<TeacherModel>? Teachers { get; set; }
        public List<GroupViewModel>? GroupViewModels { get; set; }
    }
}
