using Task20.Repositories;
using Task20.Services.Converters;
using Task20.Models;

namespace Task20.Services
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;

        public StudentService(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<StudentModel> GetAllStudentModels()
        {
            return _studentRepository.GetAllStudents().Select(g => g.EntityToModel()).ToList();
        }

        public List<StudentModel> GetStudentModelsByGroupId(int groupId)
        {
            return _studentRepository.GetAllStudentsByGroupId(groupId).Select(g => g.EntityToModel()).ToList();
        }

        public async Task EnterIntoDbNewStudentAsync(StudentModel studentModel)
        {
            await _studentRepository.AddEntityAsync(studentModel.ModelToEntity());
        }
    }
}
