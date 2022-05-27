using Task20.Entities.Base;

namespace Task20.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void AddEntityAsync(TEntity entity);

        void UpdateEntityAsync(TEntity entity);

        void RemoveEntityAsync(TEntity entity);

        TEntity? GetEntity(int id);
    }
}
