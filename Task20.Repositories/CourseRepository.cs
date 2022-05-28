using Task20.Repositories.Base;
using Task20.Entities;
using Task20.DataContext.DataBaseContext;
using Task20.Repositories.Resources;

namespace Task20.Repositories
{
    public class CourseRepository : BaseRepository<CourseEntity>
    {
        public CourseRepository(UniversityDbContext context) : base(context)
        {

        }

        public IList<CourseEntity> GetAllCourses()
        {
            return Context.Set<CourseEntity>().ToList();
        }

        public CourseStatistics GetCourseStatisticsByCourseId(int courseId)
        {
            var statistics = Context.Courses.Where(c => c.Id == courseId)
                .Select(c => new CourseStatistics
                {
                    GroupsAmount = c.Groups == null ? 0 : c.Groups.Count(),
                    StudentsAmount = c.Groups.SelectMany(s => s.Students).Count()
                })
                .FirstOrDefault();

            return statistics ?? throw new ArgumentException($"Course {courseId} not found.", nameof(courseId));
        }
    }
}
