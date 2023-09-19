using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Domain.Entities;

namespace Service.Abstractions;

public interface IGeoPointService
{
    public delegate void GeoPointHandler(IGeoPointService sender, GeoPoint e);
    public event GeoPointHandler? Notify;
    Task<IEnumerable<GeoPointDto>> GetAllByUserIdAsync(Guid userId);

    Task<GeoPointDto> GetByIdAsync(Guid userId, Guid geoPointId);

    Task<GeoPointDto> CreateAsync(Guid userId, GeoPointForCreationDto pointForCreationDto);

    Task DeleteAsync(Guid userId, Guid geoPointId);

    Task UpdateAsync(Guid userId, Guid geoPointId, GeoPointForUpdateDto geoPointForUpdateDto);
}

