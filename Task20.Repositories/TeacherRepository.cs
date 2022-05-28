using Task20.Repositories.Base;
using Task20.Entities;
using Task20.DataContext.DataBaseContext;

namespace Task20.Repositories
{
    public class TeacherRepository : BaseRepository<TeacherEntity>
    {
        public TeacherRepository(UniversityDbContext context) : base(context)
        {
        }

        public IList<TeacherEntity> GetAllTeachers()
        {
            return Context.Teachers.ToList();
        }
    }
}
