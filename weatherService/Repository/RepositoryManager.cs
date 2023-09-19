using Persistence;
using Repository.Abstractions;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IUserRepository> _lazyUserRepository;
    private readonly Lazy<IGeoPointsRepository> _lazyGeoPointsRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

    public RepositoryManager(Context dbContext)
    {
        _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
        _lazyGeoPointsRepository = new Lazy<IGeoPointsRepository>(() => new GeoPointsRepository(dbContext));
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
    }

    public IUserRepository UserRepository => _lazyUserRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;

    public IGeoPointsRepository GeoPointsRepository => _lazyGeoPointsRepository.Value;
}