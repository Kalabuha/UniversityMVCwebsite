using Task20.Models;

namespace Task20.Services.Resources
{
    public class CourseData
    {
        public int GroupsAmount { get; set; }
        public int StudentsAmount { get; set; }
        public TeacherModel? CourseLeader { get; set; }
        public List<GroupModel>? Groups { get; set; }
        public List<StudentModel>? Students { get; set; }
    }
}
