using Task20.Repositories.Base;
using Task20.Entities;
using Task20.DataContext.DataBaseContext;

namespace Task20.Repositories
{
    public class StudentRepository : BaseRepository<StudentEntity>
    {
        public StudentRepository(UniversityDbContext context) : base(context)
        {
        }

        public IList<StudentEntity> GetAllStudents()
        {
            return Context.Students.ToList();
        }

        public IList<StudentEntity> GetAllStudentsByGroupId(int groupId)
        {
            return Context.Students.Where(p => p.GroupId == groupId).ToList();
        }
    }
}
