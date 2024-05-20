using AppCollection.Application.Interfaces.Repositories;
using AppCollection.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace AppCollection.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbContext;

        public WriteRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task HardDeleteRangeAsync(IList<T> entities)
        {
            await Task.Run(() => Table.RemoveRange(entities));
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
        }

        public async Task UpdateRangeAsync(IList<T> entities)
        {
            await Task.Run(() => Table.UpdateRange(entities));
        }
    }
}
