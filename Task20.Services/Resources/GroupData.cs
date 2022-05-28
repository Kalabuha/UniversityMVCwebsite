using Task20.Models;

namespace Task20.Services.Resources
{
    public class GroupData
    {
        public int StudentsAmount { get; set; }
        public TeacherModel? GroupLeader { get; set; }
        public List<StudentModel>? Students { get; set; }
    }
}
