using AppCollection.Application.Interfaces.Repositories;
using AppCollection.Domain.Common;

namespace AppCollection.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
