using Task20.Models;
using Task20.Repositories;
using Task20.Repositories.Resources;
using Task20.Services.Resources;
using Task20.Services.Converters;

namespace Task20.Services
{
    public class CourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public List<CourseModel> GetAllCourseModels()
        {
            return _courseRepository.GetAllCourses().Select(c => c.EntityToModel()).ToList();
        }

        public CourseData? GetGroupAndStudentNumberAsCourseDataById(int courseId)
        {
            var courseEntity = _courseRepository.GetEntity(courseId);
            if (courseEntity == null)
            {
                return null;
            }

            var courseData = new CourseData();
            var statistics = _courseRepository.GetCourseStatisticsByCourseId(courseId);
            courseData.GroupsAmount = statistics.GroupsAmount;
            courseData.StudentsAmount = statistics.StudentsAmount;

            return courseData;
        }
    }
}
