using AppCollection.Application.Interfaces.Repositories;
using AppCollection.Application.Interfaces.UnitOfWorks;
using AppCollection.Persistence.Context;
using AppCollection.Persistence.Repositories;

namespace AppCollection.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();
        public int SaveChanges() => dbContext.SaveChanges();
        public Task<int> SaveChangesAsync() => dbContext.SaveChangesAsync();
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);
    }
}
