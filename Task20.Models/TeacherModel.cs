using Task20.Models.Base;

namespace Task20.Models
{
    public class TeacherModel : ManModel
    {
        public string Experience { get; set; } = default!;
        public GroupModel? Group { get; set; }
        public CourseModel? Course { get; set; }
    }
}
