using Task20.Models;
using Task20.Repositories.Repositories;
using Task20.Repositories.Resources;
using Task20.Services.Resources;
using Task20.Services.Converters;

namespace Task20.Services.AboutROUService
{
    public class CourseService
    {
        private readonly CourseRepository _courseRepository;
        private readonly TeacherRepository _teacherRepository;

        public CourseService(CourseRepository courseRepository, TeacherRepository teacherRepository)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
        }



        public List<CourseModel> GetAllCourses()
        {
            var courses = _courseRepository.GetAllCourses().Select(c => c.EntityToModel()).ToList();

            return courses;
        }

        public CourseData? GetCourseDataById(int courseId)
        {
            var courseEntity = _courseRepository.GetEntity(courseId);
            if (courseEntity == null)
            {
                return null;
            }

            var courseData = new CourseData();

            if (courseEntity.LeaderId != null)
            {
                var courseLeaderEntity = _teacherRepository.GetEntity(courseEntity.LeaderId.Value);
                courseData.CourseLeader = courseLeaderEntity?.EntityToModel();
            }
            
            var statistics = _courseRepository.GetCourseStatisticsByCourseId(courseId);
            courseData.GroupsAmount = statistics.GroupsAmount;
            courseData.StudentsAmount = statistics.StudentsAmount;

            return courseData;
        }

    }
}
