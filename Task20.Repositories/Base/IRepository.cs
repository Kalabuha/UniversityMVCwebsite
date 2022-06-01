using Task20.Entities.Base;

namespace Task20.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task AddEntityAsync(TEntity entity);

        Task UpdateEntityAsync(TEntity entity);

        Task RemoveEntityAsync(TEntity entity);

        TEntity? GetEntity(int id);
    }
}
