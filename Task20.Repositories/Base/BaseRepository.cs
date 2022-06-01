using Task20.Entities;
using Task20.Entities.Base;
using Task20.DataContext.DataBaseContext;

namespace Task20.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected UniversityDbContext Context { get; }

        public BaseRepository(UniversityDbContext context)
        {
            Context = context;
        }

        public async Task AddEntityAsync(TEntity entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateEntityAsync(TEntity entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveEntityAsync(TEntity entity)
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public TEntity? GetEntity(int id)
        {
            return Context.Find<TEntity>(id);
        }
    }
}
