using Task20.Entities;
using Task20.Models;

namespace Task20.Services.Converters
{
    public static class CourseConverter
    {
        public static CourseModel EntityToModel(this CourseEntity entity)
        {
            return new CourseModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreationDate = entity.CreationDate,
            };
        }

        public static CourseEntity ModelToEntity(this CourseModel model)
        {
            return new CourseEntity
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                CreationDate = model.CreationDate,
            };
        }
    }
}
