using Task20.Repositories.Base;
using Task20.Entities;
using Task20.DataContext.DataBaseContext;

namespace Task20.Repositories
{
    public class GroupRepository : BaseRepository<GroupEntity>
    {
        public GroupRepository(UniversityDbContext context) : base(context)
        {

        }

        public IList<GroupEntity> GetAllGroups()
        {
            return Context.Groups.ToList();
        }

        public IList<GroupEntity> GetAllGroupsByCourseId(int courseId)
        {
            return Context.Groups.Where(g => g.CourseId == courseId).ToList();
        }

        public int? GetGroupStatisticsByGroupId(int groupId)
        {
            var groups = Context.Students.Where(g => g.GroupId == groupId);
            return groups?.Count();
        }
    }
}
