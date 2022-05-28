using Task20.Repositories;
using Task20.Services.Converters;
using Task20.Models;

namespace Task20.Services
{
    public class TeacherService
    {
        private readonly TeacherRepository _teacherRepository;

        public TeacherService(TeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public TeacherModel? GetTeacherModel(int teacherId)
        {
            return _teacherRepository.GetEntity(teacherId)?.EntityToModel();
        }

        public List<TeacherModel> GetAllTeacherModels()
        {
            return _teacherRepository.GetAllTeachers().Select(t => t.EntityToModel()).ToList();
        }
    }
}
