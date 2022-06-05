using Microsoft.EntityFrameworkCore;
using Microsoft.Identity;
using Task20.Entities;
using Task20.DataContext.TableConfigurations;

namespace Task20.DataContext.DataBaseContext
{
    public class UniversityDbContext : DbContext
    {
        #region DbSets
        public DbSet<TeacherEntity> Teachers => Set<TeacherEntity>();
        public DbSet<CourseEntity> Courses => Set<CourseEntity>();
        public DbSet<GroupEntity> Groups => Set<GroupEntity>();
        public DbSet<StudentEntity> Students => Set<StudentEntity>();
        public DbSet<UserEntity> Users => Set<UserEntity>();
        #endregion

        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CoursesConfig());
            modelBuilder.ApplyConfiguration(new GroupsConfig());
            modelBuilder.ApplyConfiguration(new StudentsConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
