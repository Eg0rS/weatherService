using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Mapster;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service;

public class GeoPointService : IGeoPointService
{
    private readonly IRepositoryManager _repositoryManager;
    public delegate void GeoPointHandler(GeoPointService sender, GeoPointDto e);
    public event IGeoPointService.GeoPointHandler? Notify;
    public GeoPointService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

    public async Task<IEnumerable<GeoPointDto>> GetAllByUserIdAsync(Guid userId)
    {
        var points = await _repositoryManager.GeoPointsRepository.GetAllByUserIdAsync(userId);

        var pointsDto = points.Adapt<IEnumerable<GeoPointDto>>();

        return pointsDto;
    }

    public async Task<GeoPointDto> GetByIdAsync(Guid userId, Guid geoPointId)
    {
        var user = await _repositoryManager.UserRepository.GetByIdAsync(userId);

        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }

        var geoPoint = await _repositoryManager.GeoPointsRepository.GetByIdAsync(geoPointId);

        if (geoPoint is null)
        {
            throw new GeoPointNotFoundException(geoPointId);
        }

        if (geoPoint.UserId != user.Id)
        {
            throw new GeoPointDoesNotBelongToUserException(user.Id, geoPoint.Id);
        }

        var geoPointDto = geoPoint.Adapt<GeoPointDto>();

        return geoPointDto;
    }

    public async Task<GeoPointDto> CreateAsync(Guid userId, GeoPointForCreationDto pointForCreationDto)
    {
        var user = await _repositoryManager.UserRepository.GetByIdAsync(userId);

        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }

        var geoPoint = pointForCreationDto.Adapt<GeoPoint>();

        geoPoint.UserId = user.Id;

        _repositoryManager.GeoPointsRepository.Insert(geoPoint);

        await _repositoryManager.UnitOfWork.SaveChangesAsync();
        
        Notify?.Invoke(this, geoPoint.Adapt<GeoPointDto>());

        return geoPoint.Adapt<GeoPointDto>();
    }

    public async Task DeleteAsync(Guid userId, Guid geoPointId)
    {
        var user = await _repositoryManager.UserRepository.GetByIdAsync(userId);

        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }

        var geoPoint = await _repositoryManager.GeoPointsRepository.GetByIdAsync(geoPointId);

        if (geoPoint is null)
        {
            throw new GeoPointNotFoundException(geoPointId);
        }

        if (geoPoint.UserId != user.Id)
        {
            throw new GeoPointDoesNotBelongToUserException(user.Id, geoPoint.Id);
        }

        _repositoryManager.GeoPointsRepository.Remove(geoPoint);
        
        Notify?.Invoke(this, geoPoint.Adapt<GeoPointDto>());
        
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid userId, Guid geoPointId, GeoPointForUpdateDto geoPointForUpdateDto)
    {
        var geoPoint = await _repositoryManager.GeoPointsRepository.GetByIdAsync(geoPointId);
        if (geoPoint is null)
        {
            throw new GeoPointNotFoundException(geoPointId);
        }

        geoPoint.Latitude = geoPointForUpdateDto.Latitude;
        geoPoint.Longitude = geoPointForUpdateDto.Longitude;
        geoPoint.PointType = geoPointForUpdateDto.PointType;
        
        Notify?.Invoke(this, geoPoint.Adapt<GeoPointDto>());
        
        await _repositoryManager.UnitOfWork.SaveChangesAsync();
    }
}