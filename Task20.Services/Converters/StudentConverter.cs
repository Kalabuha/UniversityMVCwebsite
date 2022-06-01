using Task20.Models;
using Task20.Entities;

namespace Task20.Services.Converters
{
    public static class StudentConverter
    {
        public static StudentModel EntityToModel(this StudentEntity entity)
        {
            return new StudentModel
            {
                Id = entity.Id,
                Firstname = entity.Name,
                Middlename = entity.SacondName,
                Lastname = entity.LastName,
                DateBirth = entity.DateBirth,
                GroupId = entity.GroupId,
            };
        }

        public static StudentEntity ModelToEntity(this StudentModel model)
        {
            return new StudentEntity
            {
                Id = model.Id,
                Name = model.Firstname,
                SacondName = model.Middlename,
                LastName = model.Lastname,
                DateBirth = model.DateBirth,
                GroupId = model.GroupId,
            };
        }
    }
}
