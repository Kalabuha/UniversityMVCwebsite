using Task20.Models;
using Task20.Entities;

namespace Task20.Services.Converters
{
    public static class GroupConverter
    {
        public static GroupModel EntityToModel(this GroupEntity entity)
        {
            return new GroupModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreationDate = entity.CreationDate,
                LeaderId = entity.LeaderId,
            };
        }

        public static GroupEntity ModelToEntity(this GroupModel model)
        {
            return new GroupEntity
            {
                Id = model.Id,
                Name = model.Name,
                Description= model.Description,
                CreationDate = model.CreationDate,
                LeaderId = model.LeaderId,
            };
        }
    }
}
