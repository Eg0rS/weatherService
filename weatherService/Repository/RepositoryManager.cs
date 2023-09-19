using System;
using Persistence;
using Repository.Abstractions;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IUserRepository> _lazyUserRepository;
    private readonly Lazy<IGeoPointsRepository> _lazyGeoPointsRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
    private readonly Lazy<IWeatherForecastRepository> _lazyWeatherRepository;

    public RepositoryManager(Context dbContext)
    {
        _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
        _lazyGeoPointsRepository = new Lazy<IGeoPointsRepository>(() => new GeoPointsRepository(dbContext));
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        _lazyWeatherRepository = new Lazy<IWeatherForecastRepository>(() => new WeatherForecastRepository());
    }

    public IUserRepository UserRepository => _lazyUserRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    public IWeatherForecastRepository WeatherForecastForecastRepository => _lazyWeatherRepository.Value;

    public IGeoPointsRepository GeoPointsRepository => _lazyGeoPointsRepository.Value;
}