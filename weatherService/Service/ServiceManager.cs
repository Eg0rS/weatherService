using System;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IUserService> _lazyUserService;
    private readonly Lazy<IGeoPointService> _lazyGeoPointService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager));
        _lazyGeoPointService = new Lazy<IGeoPointService>(() => new GeoPointService(repositoryManager));
    }

    public IUserService UserService => _lazyUserService.Value;
    public IGeoPointService GeoPointService => _lazyGeoPointService.Value;
}