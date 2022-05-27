using Task20.Entities;
using Task20.Models;

namespace Task20.Services.Converters
{
    public static class TeacherConverter
    {
        public static TeacherModel EntityToModel(this TeacherEntity entity)
        {
            return new TeacherModel
            {
                Id = entity.Id,
                Firstname = entity.Name,
                Middlename = entity.SacondName,
                Lastname = entity.LastName,
                DateBirth = entity.DateBirth,
                Experience = entity.Experience,
            };
        }

        public static TeacherEntity ModelToEntity(this TeacherModel model)
        {
            return new TeacherEntity
            {
                Id = model.Id,
                Name = model.Firstname,
                SacondName = model.Middlename,
                LastName = model.Lastname,
                DateBirth = model.DateBirth,
                Experience = model.Experience,
            };
        }
    }
}
