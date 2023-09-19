using Contracts;

namespace Service.Abstractions;

public interface IGeoPointService
{
    Task<IEnumerable<GeoPointDto>> GetAllByUserIdAsync(Guid userId);

    Task<GeoPointDto> GetByIdAsync(Guid userId, Guid geoPointId);

    Task<GeoPointDto> CreateAsync(Guid userId, GeoPointForCreationDto pointForCreationDto);

    Task DeleteAsync(Guid userId, Guid geoPointId);

    Task UpdateAsync(Guid userId, Guid geoPointId, GeoPointForUpdateDto geoPointForUpdateDto);
}