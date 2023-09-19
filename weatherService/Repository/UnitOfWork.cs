using Persistence;
using Repository.Abstractions;

namespace Repository;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly Context _dbContext;

    public UnitOfWork(Context dbContext) => _dbContext = dbContext;


    public Task<int> SaveChangesAsync()
    {
        return _dbContext.SaveChangesAsync();
    }
}